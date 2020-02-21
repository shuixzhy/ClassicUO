#region license
// Copyright (C) 2020 ClassicUO Development Community on Github
// 
// This project is an alternative client for the game Ultima Online.
// The goal of this is to develop a lightweight client considering
// new technologies.
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.
#endregion

using System.IO;
using System.Linq;
using System.Xml;

using ClassicUO.Configuration;
using ClassicUO.Game.Data;
using ClassicUO.Game.GameObjects;
using ClassicUO.Game.Managers;
using ClassicUO.Game.Scenes;
using ClassicUO.Game.UI.Controls;
using ClassicUO.Input;
using ClassicUO.IO;
using ClassicUO.IO.Resources;
using ClassicUO.Renderer;
using ClassicUO.Utility.Logging;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClassicUO.Game.UI.Gumps
{
    internal class ObjectBarGump : Gump
    {
        private AlphaBlendControl _background;
        private static int _lastX, _lastY;
        private int _columns = 5, _rectSize;
        //private bool _isVertical;

        public ObjectBarGump() : base(0, 0)
        {
        }

        public ObjectBarGump(int rectSize = 30) : base(0, 0)
        {
            X =_lastX;
            Y =_lastY;

            if (rectSize < 30)
                rectSize = 30;
            else if (rectSize > 80)
                rectSize = 80;

            //_rows = 1;
            //_columns = 5;
            _rectSize = rectSize;
            //_isVertical = vertical;

            BuildGump();
        }

        public override GUMP_TYPE GumpType => GUMP_TYPE.GT_OBJECTMENU;

        private void BuildGump()
        {
            CanMove = true;
            AcceptMouseInput = true;
            AcceptKeyboardInput = false;
            CanCloseWithRightClick = false;
            WantUpdateSize = false;

            Width = _rectSize * _columns + 1;
            Height = _rectSize  + 1;

            Add(_background = new AlphaBlendControl(0.3f) { Width = Width, Height = Height+20,Y = -20 });

            
            for (int col = 0; col < _columns; col++)
            {
                Add(new Label((col+1).ToString(),false,0x034E,_rectSize,2,FontStyle.BlackBorder,TEXT_ALIGN_TYPE.TS_CENTER)
                    {
                        X = col*_rectSize,
                        Y = -20,
                    });
                Add(new CounterItem(col * _rectSize + 2, 2, _rectSize - 4, _rectSize - 4, col));
            }
            
        }

        public void SetLayout(int size)
        {
            bool ok = false;

            //if (_isVertical != isvertical)
            //{
            //    _isVertical = isvertical;
            //    int temp = _rows;
            //    _rows = _columns;
            //    _columns = temp;
            //    ok = true;
            //}


            if (size < 30)
                size = 30;
            else if (size > 80)
                size = 80;

            if (_rectSize != size)
            {
                ok = true;
                _rectSize = size;
            }


            if (ok) ApplyLayout();
        }

        private void ApplyLayout()
        {
            Width = _rectSize * _columns + 1;
            Height = _rectSize  + 1;

            _background.Width = Width;
            _background.Height = Height;

            CounterItem[] items = GetControls<CounterItem>();

            int[] indices = new int[items.Length];

                for (int col = 0; col < _columns; col++)
                {

                    if (col < items.Length)
                    {
                        CounterItem c = items[col];

                        c.X = col * _rectSize + 2;
                        c.Y = _rectSize + 2;
                        c.Width = _rectSize - 4;
                        c.Height = _rectSize - 4;

                        c.SetGraphic(c.Graphic, c.Hue);

                        indices[col] = -1;
                    }
                    else
                        Add(new CounterItem(col * _rectSize + 2,  2, _rectSize - 4, _rectSize - 4,col));
                }
            

            for (int i = 0; i < indices.Length; i++)
            {
                int index = indices[i];

                if (index >= 0 && index < items.Length)
                {
                    items[i].Parent = null;
                    items[i].Dispose();
                }
            }

            SetInScreen();
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);

            writer.Write((byte)2);

            writer.Write(_rectSize);

            CounterItem[] controls = GetControls<CounterItem>();

            writer.Write(controls.Length);

            foreach (CounterItem c in controls)
            {
                writer.Write(c.Graphic);
                writer.Write(c.Hue);
            }
        }

        public override void Restore(BinaryReader reader)
        {
            base.Restore(reader);

            byte version = reader.ReadByte();

            _rectSize = reader.ReadInt32();

            int count = reader.ReadInt32();

            BuildGump();

            CounterItem[] items = GetControls<CounterItem>();

            for (int i = 0; i < count; i++)
                items[i].SetGraphic(reader.ReadUInt16(), version > 1 ? reader.ReadUInt16() : (ushort)0);

            IsEnabled = IsVisible = ProfileManager.Current.CounterBarEnabled;
        }


        public override void Save(XmlTextWriter writer)
        {
            base.Save(writer);

            writer.WriteAttributeString("rectsize", _rectSize.ToString());

            var controls = FindControls<CounterItem>();

            writer.WriteStartElement("controls");
            foreach (CounterItem control in controls)
            {
                writer.WriteStartElement("control");
                writer.WriteAttributeString("graphic", control.Graphic.ToString());
                writer.WriteAttributeString("hue", control.Hue.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public override void Restore(XmlElement xml)
        {
            base.Restore(xml);

            _rectSize = int.Parse(xml.GetAttribute("rectsize"));

            BuildGump();

            XmlElement controlsXml = xml["controls"];

            if (controlsXml != null)
            {
                var items = GetControls<CounterItem>();
                int index = 0;

                foreach (XmlElement controlXml in controlsXml.GetElementsByTagName("control"))
                {
                    if (index < items.Length)
                    {
                        items[index++]?.SetGraphic(ushort.Parse(controlXml.GetAttribute("graphic")), ushort.Parse(controlXml.GetAttribute("hue")));
                    
                    }
                    else
                    {
                        Log.Error("Index outbounds when parsing counter bar items");
                    }
                }
            }

            IsEnabled = IsVisible = ProfileManager.Current.CounterBarEnabled;
        }


        private class CounterItem : Control
        {
            private int _amount;
            private ushort _graphic;
            private ushort _hue;
            private uint _time;
            private int _index;

            private ImageWithText _image;

            public CounterItem(int x, int y, int w, int h,int index)
            {
                AcceptMouseInput = true;
                WantUpdateSize = false;
                CanMove = true;
                CanCloseWithRightClick = false;

                X = x;
                Y = y;
                Width = w;
                Height = h;
                _index = index;
                _image = new ImageWithText();
                
                Add(_image);
                ContextMenu = new ContextMenuControl();
                ContextMenu.Add("Use object (Double click)", Use);
                ContextMenu.Add("Remove (ALT + Right click)", RemoveItem);
            }

            public ushort Graphic => _graphic;
            public ushort Hue => _hue;

            public void SetGraphic(ushort graphic, ushort hue)
            {
                _image.ChangeGraphic(graphic, hue);
                switch (_index)
                {
                    case 0:
                        TargetManager.Object_1 = graphic;
                        break;
                    case 1:
                        TargetManager.Object_2 = graphic;
                        break;
                    case 2:
                        TargetManager.Object_3 = graphic;
                        break;
                    case 3:
                        TargetManager.Object_4 = graphic;
                        break;
                    case 4:
                        TargetManager.Object_5 = graphic;
                        break;
                }
                if (graphic == 0)
                    return;

                _graphic = graphic;
                _hue = hue;
                
            }

            public void RemoveItem()
            {
                _image?.ChangeGraphic(0, 0);
                _amount = 0;
                _graphic = 0;
            }

            public void Use()
            {
                if (_graphic == 0)
                    return;

                Item backpack = World.Player.Equipment[(int) Layer.Backpack];
                Item item = backpack.FindItem(_graphic, _hue);

                if (item != null)
                    GameActions.DoubleClick(item);
            }

            protected override void OnMouseUp(int x, int y, MouseButtonType button)
            {
                if (button == MouseButtonType.Left)
                {
                    GameScene gs = Client.Game.GetScene<GameScene>();

                    if (!ItemHold.Enabled || !gs.IsMouseOverUI)
                        return;

                    Item item = World.Items.Get(ItemHold.Container);

                    if (item == null)
                        return;

                    SetGraphic(ItemHold.Graphic, ItemHold.Hue);

                    gs.DropHeldItemToContainer(item, ItemHold.X, ItemHold.Y);
                }
                else if (button == MouseButtonType.Right && Keyboard.Alt && _graphic != 0)
                {
                    RemoveItem();
                }
                else if (_graphic != 0)
                    base.OnMouseUp(x, y, button);
            }

            protected override bool OnMouseDoubleClick(int x, int y, MouseButtonType button)
            {
                if (button == MouseButtonType.Left)
                {
                    Use();
                }

                return true;
            }

            public override void Update(double totalMS, double frameMS)
            {
                base.Update(totalMS, frameMS);

                if (_time < Time.Ticks)
                {
                    _time = Time.Ticks + 100;

                    if (_graphic == 0)
                    {
                        _image.SetAmount(string.Empty);
                    }
                    else
                    {
                        _amount = 0;
                        GetAmount(World.Player.Equipment[(int)Layer.Backpack], _graphic, _hue, ref _amount);

                        if (ProfileManager.Current.CounterBarDisplayAbbreviatedAmount)
                        {
                            if (_amount >= ProfileManager.Current.CounterBarAbbreviatedAmount)
                            {
                                _image.SetAmount(Utility.StringHelper.IntToAbbreviatedString(_amount));
                                return;
                            }
                        }
                        _image.SetAmount(_amount.ToString());
                    }
                }
            }

            private static void GetAmount(Item parent, ushort graphic, ushort hue, ref int amount)
            {
                if (parent == null)
                    return;

                foreach (Item item in parent.Items)
                {
                    GetAmount(item, graphic, hue, ref amount);

                    if (item.Graphic == graphic && item.Hue == hue && item.Exists)
                        amount += item.Amount;
                }
            }

            public override bool Draw(UltimaBatcher2D batcher, int x, int y)
            {
                base.Draw(batcher, x, y);


                Texture2D color = Texture2DCache.GetTexture(MouseIsOver ? Color.Yellow : ProfileManager.Current.CounterBarHighlightOnAmount &&
                                                      _amount < ProfileManager.Current.CounterBarHighlightAmount && _graphic != 0 ? Color.Red : Color.Gray);
                ResetHueVector();
                batcher.DrawRectangle(color, x, y, Width, Height, ref _hueVector);

                return true;
            }


            private class ImageWithText : Control
            {
                private readonly TextureControl _textureControl;
                private readonly Label _label;

                public ImageWithText()
                {
                    CanMove = true;
                    WantUpdateSize = true;
                    AcceptMouseInput = false;
                    _textureControl = new TextureControl()
                    {
                        ScaleTexture = true,
                        AcceptMouseInput = false
                    };
                    Add(_textureControl);


                    _label = new Label("", true, 0x35, 0, 1, FontStyle.BlackBorder)
                    {
                        X = 2,
                        Y = Height - 15,
                    };
                    Add(_label);
                }


                public void ChangeGraphic(ushort graphic, ushort hue)
                {
                    if (graphic != 0)
                    {
                        _textureControl.Texture = ArtLoader.Instance.GetTexture(graphic);
                        _textureControl.Hue = hue;
                        _textureControl.Width = Parent.Width;
                        _textureControl.Height = Parent.Height;
                        _label.Y = Parent.Height - 15;
                    }
                    else
                        _textureControl.Texture = null;
                }



                public void SetAmount(string amount)
                    => _label.Text = amount;

            }
        }
    }
}