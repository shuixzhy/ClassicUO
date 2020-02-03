
using System.Text;

using ClassicUO.Game.GameObjects;
using ClassicUO.Game.Scenes;
using ClassicUO.Game.UI.Controls;
using ClassicUO.Input;
using ClassicUO.Renderer;

namespace ClassicUO.Game.UI.Gumps
{
    internal class LootingGump :Gump
    {


        private string _name ;
        private Label _renderedText;
        private AlphaBlendControl alpha;

        public LootingGump(string name): base(0,0)
        {
            CanMove = false;
            AcceptMouseInput = false;

            

            ControlInfo.Layer = UILayer.Over;




            if (name == null || name == string.Empty)
            {
                _name = string.Empty;
                IsVisible = false;
            }
            else
            {
                _name = Language.Language.UI_Looting + name;
                IsVisible = true;
            }

            Add(alpha = new AlphaBlendControl(0.3f)
            {
                Hue = 34
            });
            _renderedText = new Label(_name, true, 0xFFFF, font: 1, style: FontStyle.BlackBorder)
            {
                X = 2
            };

           
            alpha.Width = _renderedText.Width +5;
            alpha.Height = _renderedText.Height +5;

            Width = alpha.Width;
            Height = alpha.Height;
            Add(_renderedText);
            X = Engine.Profile.Current.GameWindowSize.X / 2 - Width/2;
            Y = Engine.Profile.Current.GameWindowSize.Y / 2 + 20;

        }
        public void ChangeName(string name)
        {
            if (name == null || name == string.Empty)
            {
                _name = string.Empty;
                IsVisible = false;
                return;
            }
            else
            {
                _name = Language.Language.UI_Looting + name;
                IsVisible = true;
            }
            _renderedText.Text = _name;
            alpha.Width = _renderedText.Width + 5;
            alpha.Height = _renderedText.Height + 5;

            Width = alpha.Width;
            Height = alpha.Height;
            Width = _renderedText.Width;
            Height = _renderedText.Height;
            X = Engine.Profile.Current.GameWindowSize.X / 2 - Width / 2;
            Y = Engine.Profile.Current.GameWindowSize.Y / 2 + 20;
        }
        //protected override void OnDragEnd(int x, int y)
        //{
        //    _lastX = ScreenCoordinateX;
        //    _lastY = ScreenCoordinateY;
        //    SetInScreen();

        //    base.OnDragEnd(x, y);
        //}
        public override void Dispose()
        {
          
            base.Dispose();
        }
    }
}
