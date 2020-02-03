using System.Collections.Generic;
using System.Linq;

using ClassicUO.Game.Data;
using ClassicUO.Game.GameObjects;
using ClassicUO.Game.Managers;
using ClassicUO.Game.UI.Controls;
using ClassicUO.Input;
using ClassicUO.IO;
using ClassicUO.Network;
using ClassicUO.Renderer;

using Microsoft.Xna.Framework;

namespace ClassicUO.Game.UI.Gumps
{
    internal class LootListGump : Gump
    {
        private readonly AlphaBlendControl _background;
        private readonly NiceButton _buttonPrev, _buttonNext;
        private List<ushort[]> _items;
        private ushort _item;

        private int _currentPage = 1;
        private int _pagesCount;

        public LootListGump() : base(0,0)
        {
            if (Engine.Profile.Current.LootList == null)
                Engine.Profile.Current.LootList = new List<ushort[]>();
            _items = Engine.Profile.Current.LootList;

            //if (_items == null)
            //{
            //    Dispose();

            //    return;
            //}

            X = 100;
            Y = 100;

            CanMove = true;
            AcceptMouseInput = true;

            _background = new AlphaBlendControl();
            _background.Width = 120 * Engine.Profile.Current.CorpseScale;
            _background.Height = 160 * Engine.Profile.Current.CorpseScale;
            Add(_background);

            Width = _background.Width;
            Height = _background.Height;

            NiceButton setLootBag = new NiceButton(3, Height - 23, 50 * Engine.Profile.Current.CorpseScale, 10 * Engine.Profile.Current.CorpseScale, ButtonAction.Activate, Language.Language.UI_Add) { ButtonParameter = 2, IsSelectable = false };
            Add(setLootBag);

            _buttonPrev = new NiceButton(Width - 50, Height - 20, 20, 20, ButtonAction.Activate, "<<") { ButtonParameter = 0, IsSelectable = false };
            _buttonNext = new NiceButton(Width - 20, Height - 20, 20, 20, ButtonAction.Activate, ">>") { ButtonParameter = 1, IsSelectable = false };

            _buttonNext.IsEnabled = _buttonPrev.IsEnabled = false;
            _buttonNext.IsVisible = _buttonPrev.IsVisible = false;


            Add(_buttonPrev);
            Add(_buttonNext);
            if (_items != null)
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
            }
            else if (buttonID == 2)
            {
                GameActions.Print(Language.Language.UI_AddItem);
                TargetManager.SetTargeting(CursorTarget.AddToLootlist, Serial.INVALID, TargetType.Neutral);
            }
            else
                base.OnButtonClick(buttonID);
        }
        public void RedrawItems()
        {
            int st = 10 * Engine.Profile.Current.CorpseScale;
            int size = (int)((Width - 10 * Engine.Profile.Current.CorpseScale) / Engine.Profile.Current.ItemScale - 10 * Engine.Profile.Current.CorpseScale);

            int x = st;
            int y = st;
            
            foreach (LootListItem lootListItem in Children.OfType<LootListItem>())
            {
                lootListItem.Dispose();
            }

            int count = 0;
            _pagesCount = 1;

            foreach (ushort[] item in _items)
            {
                LootListItem lootitem = new LootListItem(item, size);

                if (x > _background.Width - lootitem.Width - st)
                {
                    x = st;
                    y += lootitem.Height + st;

                    if (y > _background.Height - lootitem.Width - 2 * st - 20)
                    {
                        _pagesCount++;
                        y = st;

                        _buttonNext.IsEnabled = true;
                        _buttonNext.IsVisible = true;
                    }
                }

                lootitem.X = x;
                lootitem.Y = y;
                Add(lootitem, _pagesCount);

                x += lootitem.Width + st;

                count++;
            }

            //if (count == 0)
            //{
            //    //GameActions.Print("[格柵拾取]: 尸體是空的!");
            //    Dispose();
            //}
        }
        public override void Dispose()
        {
            base.Dispose();
        }

        public override bool Draw(UltimaBatcher2D batcher, int x, int y)
        {
            ResetHueVector();
            base.Draw(batcher, x, y);
            batcher.DrawRectangle(Textures.GetTexture(Color.Gray), x, y, Width, Height, ref _hueVector);

            return true;
        }


        //public override void Update(double totalMS, double frameMS)
        //{

        //    base.Update(totalMS, frameMS);

        //    if (IsDisposed)
        //        return;

        //}

        //protected override void OnMouseExit(int x, int y)
        //{
           
        //}


        private class LootListItem : Control
        {
            private readonly Serial _serial;

            private readonly TextureControl _texture;

            public LootListItem(ushort[] item, int size)
            {

                if (item == null)
                {
                    Dispose();

                    return;
                }

                int SIZE = size;

                CanMove = false;


                AlphaBlendControl background = new AlphaBlendControl();
                background.Y = 15;
                background.Width = SIZE;
                background.Height = SIZE;
                Add(background);

                _texture = new TextureControl
                {
                    IsPartial = false,
                    ScaleTexture = true,
                    Hue = item[1],
                    Texture = FileManager.Art.GetTexture(item[0]),
                    Y = 15,
                    Width = SIZE,
                    Height = SIZE,
                    CanMove = false
                };

                Add(_texture);


                _texture.MouseUp += (sender, e) =>
                {
                    if (e.Button == MouseButton.Left)
                    {
                        Engine.Profile.Current.LootList.Remove(item);
                        Dispose();
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
                batcher.DrawRectangle(Textures.GetTexture(Color.Gray), x, y + 15, Width, Height - 15, ref _hueVector);

                if (_texture.MouseIsOver)
                {
                    _hueVector.Z = 0.7f;
                    batcher.Draw2D(Textures.GetTexture(Color.Yellow), x + 1, y + 15, Width - 1, Height - 15, ref _hueVector);
                    _hueVector.Z = 0;
                }

                return true;
            }
        }
    }
}
