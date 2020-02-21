using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ClassicUO.Configuration;
using ClassicUO.Game.Data;
using ClassicUO.Game.GameObjects;
using ClassicUO.Game.Managers;
using ClassicUO.Game.UI.Controls;
using ClassicUO.Input;
using ClassicUO.IO;
using ClassicUO.IO.Resources;
using ClassicUO.Network;
using ClassicUO.Renderer;

using Microsoft.Xna.Framework;

namespace ClassicUO.Game.UI.Gumps
{
    internal class GridLootGump : Gump
    {
        private readonly AlphaBlendControl _background;
        private readonly NiceButton _buttonPrev, _buttonNext;
        private readonly Item _corpse;
        private static uint _time;
        private int DELAY = 500;
        private int _currentPage = 1;
        private readonly Label _currentPageLabel;
        private int _pagesCount;
        private bool looting = false;
        private static int _lastX = ProfileManager.Current.GridLootType == 2 ? 200 : 100;
        private static int _lastY = 100;
        private uint c;
        public GridLootGump(uint local) : base(local, 0)
        {
            _corpse = World.Items.Get(local);
            c = local;
            //if (c == null)
            //{ c = local; }
            //else
            //{
            //    if(c != local)
            //    {
            //        X = _lastX += 10;
            //        Y = _lastY += 10;
            //        c = local;
            //    }
            //}
            if (_corpse == null)
            {
                Dispose();

                return;
            }
            GridLootGump gg = UIManager.Gumps.OfType<GridLootGump>().FirstOrDefault(s => s.LocalSerial == LocalSerial);

            if (gg == null)
            {
                X = _lastX += 10 * ProfileManager.Current.CorpseScale;
                Y = _lastY += 10 * ProfileManager.Current.CorpseScale;
            }
            else
            {
                X = gg.X;
                Y = gg.Y;
            }

            int gx = ProfileManager.Current.GameWindowPosition.X + ProfileManager.Current.GameWindowSize.X;
            int gy = ProfileManager.Current.GameWindowPosition.Y + ProfileManager.Current.GameWindowSize.Y;

            if (X > (gx - 50))
                X = 0;
            if (Y > (gy - 50))
                Y = 0;
            CanMove = true;
            AcceptMouseInput = true;

            _background = new AlphaBlendControl();
            _background.Width = 120 * ProfileManager.Current.CorpseScale;
            _background.Height = 160 * ProfileManager.Current.CorpseScale;
            Add(_background);

            Width = _background.Width;
            Height = _background.Height;

            NiceButton setLootBag = new NiceButton(3, Height - 23, 50 * ProfileManager.Current.CorpseScale, 10 * ProfileManager.Current.CorpseScale, ButtonAction.Activate, LanguageManager.Current.UI_GridLoot_SetBag) { ButtonParameter = 2, IsSelectable = false };
            Add(setLootBag);

            _buttonPrev = new NiceButton(Width - 50, Height - 20, 20, 20, ButtonAction.Activate, "<<") { ButtonParameter = 0, IsSelectable = false };
            _buttonNext = new NiceButton(Width - 20, Height - 20, 20, 20, ButtonAction.Activate, ">>") { ButtonParameter = 1, IsSelectable = false };

            _buttonNext.IsEnabled = _buttonPrev.IsEnabled = false;
            _buttonNext.IsVisible = _buttonPrev.IsVisible = false;
            if (_corpse.Items.Count ==0 && ProfileManager.Current.SkipEmptyCorpse)
            {
                IsVisible = false;
            }
            else
            {
                IsVisible = true;
            }

            Add(_buttonPrev);
            Add(_buttonNext);
            Add(_currentPageLabel = new Label("1", true, 999, align: IO.Resources.TEXT_ALIGN_TYPE.TS_CENTER)
            {
                X = Width / 2 - 5,
                Y = Height - 20,
            });
            _corpse.Items.Added += Items_Added;
            _corpse.Items.Removed += Items_Removed;

        }
        private void Items_Removed(object sender, CollectionChangedEventArgs<uint> e)
        {
            RedrawItems();
        }

        private void Items_Added(object sender, CollectionChangedEventArgs<uint> e)
        {
            RedrawItems();
        }
        public override void OnButtonClick(int buttonID)
        {
            if (buttonID == 0)
            {
                _currentPage--;

                if (_currentPage <= 1)
                {
                    _currentPage = 1;
                    _buttonPrev.IsEnabled = false;
                    _buttonNext.IsEnabled = true;
                    _buttonPrev.IsVisible = false;
                    _buttonNext.IsVisible = true;
                }

                ChangePage(_currentPage);
                _currentPageLabel.Text = ActivePage.ToString();
                _currentPageLabel.X = Width / 2 - _currentPageLabel.Width / 2;
            }
            else if (buttonID == 1)
            {
                _currentPage++;

                if (_currentPage >= _pagesCount)
                {
                    _currentPage = _pagesCount;
                    _buttonPrev.IsEnabled = true;
                    _buttonNext.IsEnabled = false;
                    _buttonPrev.IsVisible = true;
                    _buttonNext.IsVisible = false;
                }

                ChangePage(_currentPage);
                _currentPageLabel.Text = ActivePage.ToString();
                _currentPageLabel.X = Width / 2 - _currentPageLabel.Width / 2;
            }
            else if (buttonID == 2)
            {
                GameActions.Print(LanguageManager.Current.UI_GridLoot_ChooseContainer);
                TargetManager.SetTargeting(CursorTarget.SetGrabBag, 0, TargetType.Neutral);
            }
            else
                base.OnButtonClick(buttonID);
        }

        public void RedrawItems()
        {
            int st = 10 * ProfileManager.Current.CorpseScale;
            int size = (int)((Width - 10 * ProfileManager.Current.CorpseScale) / ProfileManager.Current.ItemScale - 10 * ProfileManager.Current.CorpseScale);

            int x = st;
            int y = st;

            foreach (GridLootItem gridLootItem in Children.OfType<GridLootItem>()) gridLootItem.Dispose();
            uint curtime = Time.Ticks;

            int count = 0;
            _pagesCount = 1;
            //_corpse.Items.Added -= ItemsOnAdded;
            ////_corpse.Items.Removed -= ItemsOnRemoved;
            //_corpse.Items.Added += ItemsOnAdded;
            ////_corpse.Items.Removed += ItemsOnRemoved;

            foreach (Item item in _corpse.Items)
            {
                //if (item.IsCoin && ProfileManager.Current.AutoLootGold && ProfileManager.Current.GridLootType < 2)
                //{
                //    //if (curtime - DELAY > time)
                //        GameActions.GrabItem(item, (ushort)item.Amount);
                //    //GameActions.Print("[格柵拾取]: 拾取" + item.Amount.ToString() + "金币。");
                //    looting = true;
                //    //time = curtime;
                //    return;

                //}
                //bool contain = false;
                //if (ProfileManager.Current.LootList == null)
                //    ProfileManager.Current.LootList = new List<ushort[]>();
                //foreach (ushort[] i in ProfileManager.Current.LootList)
                //{
                //    if (item.Graphic == i[0] && item.Hue == i[1])
                //    {
                //        contain = true;
                //        break;
                //    }

                //}
                //if (contain && ProfileManager.Current.AutoLootItem && ProfileManager.Current.GridLootType < 2)
                //{
                //    //if (curtime - DELAY > time)
                //        GameActions.GrabItem(item, (ushort)item.Amount);
                //    //time = curtime;
                //    looting = true;
                //    return;

                //}
                //looting = false;
                if (item == null || item.ItemData.Layer == (int)Layer.Hair || item.ItemData.Layer == (int)Layer.Beard || item.ItemData.Layer == (int)Layer.Face)
                    continue;

                GridLootItem gridItem = new GridLootItem(item, size);

                if (x > _background.Width - gridItem.Width - st)
                {
                    x = st;
                    y += gridItem.Height + st;

                    if (y > _background.Height - gridItem.Width - 2 * st - 20)
                    {
                        _pagesCount++;
                        y = st;

                        _buttonNext.IsEnabled = true;
                        _buttonNext.IsVisible = true;
                    }
                }

                gridItem.X = x;
                gridItem.Y = y;
                Add(gridItem, _pagesCount);

                x += gridItem.Width + st;

                count++;
            }

            //if (count == 0)
            //{
            //    //GameActions.Print("[格柵拾取]: 尸體是空的!");
            //    Dispose();
            //}


        }
        //private void ItemsOnRemoved(object sender, CollectionChangedEventArgs<Serial> e)
        //{
        //    foreach (GridLootGump v in Children.OfType<GridLootGump>().Where(s => e.Contains(s.LocalSerial)))
        //        v.Dispose();
        //}



        public override void Dispose()
        {
            if (_corpse != null)
            {
                if (_corpse == SelectedObject.CorpseObject)
                    SelectedObject.CorpseObject = null;
            }

            _lastX = X;
            _lastY = Y;

            base.Dispose();
        }

        public override bool Draw(UltimaBatcher2D batcher, int x, int y)
        {
            ResetHueVector();
            base.Draw(batcher, x, y);
            batcher.DrawRectangle(Texture2DCache.GetTexture(Color.Gray), x, y, Width, Height, ref _hueVector);

            return true;
        }


        public override void Update(double totalMS, double frameMS)
        {
            if (_corpse == null || _corpse.IsDestroyed || _corpse.OnGround && _corpse.Distance > 3)
            {
                Dispose();

                return;
            }


            base.Update(totalMS, frameMS);

            if (IsDisposed)
                return;

            if (_corpse != null && !_corpse.IsDestroyed && UIManager.MouseOverControl != null && (UIManager.MouseOverControl == this || UIManager.MouseOverControl.RootParent == this))
            {
                SelectedObject.Object = _corpse;
                SelectedObject.LastObject = _corpse;
                SelectedObject.CorpseObject = _corpse;
            }

        }

        protected override void OnMouseExit(int x, int y)
        {
            if (_corpse != null && !_corpse.IsDestroyed) SelectedObject.CorpseObject = null;
        }


        private class GridLootItem : Control
        {
            private readonly uint _serial;

            private readonly TextureControl _texture;

            public GridLootItem(uint serial, int size)
            {
                _serial = serial;

                Item item = World.Items.Get(serial);

                if (item == null)
                {
                    Dispose();

                    return;
                }

                int SIZE = size;

                CanMove = false;

                HSliderBar amount = new HSliderBar(0, 0, SIZE, 1, item.Amount, item.Amount, HSliderBarStyle.MetalWidgetRecessedBar, true, color: 0xFFFF, drawUp: true);
                Add(amount);

                amount.IsVisible = amount.IsEnabled = amount.MaxValue > 1;


                AlphaBlendControl background = new AlphaBlendControl();
                background.Y = 15;
                background.Width = SIZE;
                background.Height = SIZE;
                Add(background);


                _texture = new TextureControl();
                _texture.IsPartial = item.ItemData.IsPartialHue;
                _texture.ScaleTexture = true;
                _texture.Hue = item.Hue;
                _texture.Texture = ArtLoader.Instance.GetTexture(item.DisplayedGraphic);
                _texture.Y = 15;
                _texture.Width = SIZE;
                _texture.Height = SIZE;
                _texture.CanMove = false;

                if (World.ClientFeatures.TooltipsEnabled) _texture.SetTooltip(item);

                Add(_texture);


                _texture.MouseUp += (sender, e) =>
                {
                    if (e.Button == MouseButtonType.Left)
                    {
                        GameActions.GrabItem(item, (ushort)amount.Value);
                    }
                };

                Width = background.Width;
                Height = background.Height + 15;

                WantUpdateSize = false;

            }

            public override bool Draw(UltimaBatcher2D batcher, int x, int y)
            {
                ResetHueVector();
                base.Draw(batcher, x, y);
                batcher.DrawRectangle(Texture2DCache.GetTexture(Color.Gray), x, y + 15, Width, Height - 15, ref _hueVector);

                if (_texture.MouseIsOver)
                {
                    _hueVector.Z = 0.7f;
                    batcher.Draw2D(Texture2DCache.GetTexture(Color.Yellow), x + 1, y + 15, Width - 1, Height - 15, ref _hueVector);
                    _hueVector.Z = 0;
                }

                return true;
            }
        }
    }
}