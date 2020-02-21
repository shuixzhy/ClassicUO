using System;
using System.IO;
using ClassicUO.Configuration;
using ClassicUO.Game.Managers;
using ClassicUO.Game.UI.Controls;

namespace ClassicUO.Game.UI.Gumps
{
    internal class TargetMenuGump : Gump
    {
        private const byte FONT = 0xFF;
        private const ushort HUE_FONT = 999;
        private const ushort HUE_TITLE = 34;
        private AlphaBlendControl _background;
        private Label _name1, _name2, _name3, _name4, _name5, _lastTarget, _lastHarmfulTarget, _lastBeneficialTarget,_selectTarget,_lastGump,_lastButton ,_obj1, _obj2, _obj3, _obj4, _obj5, _lastObjectGump;
        private static int _lastX = 150, _lastY = 150;
        public override GUMP_TYPE GumpType => GUMP_TYPE.GT_TARGETMENU;

        public TargetMenuGump() : base(0,0)
        {
            X = _lastX;
            Y = _lastY;
            CanMove = true;
            AcceptMouseInput = true;
            Add(_background = new AlphaBlendControl(0.3f) { Width = 180, Height = 500 });
            Add(new Label(LanguageManager.Current.UI_TargetMenu, true, HUE_FONT, 160, FONT, Renderer.FontStyle.BlackBorder, IO.Resources.TEXT_ALIGN_TYPE.TS_CENTER)
            {
                X = 10,
                Y  = 10
            });
            Add(new NiceButton(10, 50, 20, 20, ButtonAction.Activate, "1", 1) { ButtonParameter = (int)TargetButton.Target_1, IsSelected = (TargetManager.Target_1_name != null) });
            Add(new NiceButton(10, 90, 20, 20, ButtonAction.Activate, "2",2) { ButtonParameter = (int)TargetButton.Target_2 , IsSelected = (TargetManager.Target_2_name != null) });
            Add(new NiceButton(10, 130, 20, 20, ButtonAction.Activate, "3",3) { ButtonParameter = (int)TargetButton.Target_3 , IsSelected = (TargetManager.Target_3_name != null) });
            Add(new NiceButton(10, 170, 20, 20, ButtonAction.Activate, "4",4) { ButtonParameter = (int)TargetButton.Target_4 , IsSelected = (TargetManager.Target_4_name != null) });
            Add(new NiceButton(10, 210, 20, 20, ButtonAction.Activate, "5",5) { ButtonParameter = (int)TargetButton.Target_5 , IsSelected = (TargetManager.Target_5_name != null) });

            
       
            _name1 = new Label(TargetManager.Target_1_name, true, HUE_FONT, 80, FONT)
            {
                X = 90,
                Y = 50,
            };
            _name2 = new Label(TargetManager.Target_2_name, true, HUE_FONT, 80, FONT)
            {
                X = 90,
                Y = 90,
            };

            _name3 = new Label(TargetManager.Target_3_name, true, HUE_FONT, 80, FONT)
            {
                X = 90,
                Y = 130,
            };
            _name4 = new Label(TargetManager.Target_4_name, true, HUE_FONT, 80, FONT)
            {
                X = 90,
                Y = 170,
            };
            _name5 = new Label(TargetManager.Target_5_name, true, HUE_FONT, 80, FONT)
            {
                X = 90,
                Y = 210,
            };

            Add(_name1);
            Add(_name2);
            Add(_name3);
            Add(_name4);
            Add(_name5);
            Add(new Label("LastTarget:", true, 15, 70, FONT, Renderer.FontStyle.BlackBorder, IO.Resources.TEXT_ALIGN_TYPE.TS_LEFT)
            {
                X = 10,
                Y = 250
            });
            _lastTarget =(new Label(TargetManager.LastTarget_name, true, HUE_FONT, 80, FONT, Renderer.FontStyle.BlackBorder, IO.Resources.TEXT_ALIGN_TYPE.TS_LEFT)
            {
                X = 90,
                Y = 250
            });
            Add(new Label("LastHarmfulTarget:", true, HUE_TITLE, 70, FONT, Renderer.FontStyle.BlackBorder, IO.Resources.TEXT_ALIGN_TYPE.TS_LEFT)
            {
                X = 10,
                Y = 290
            });
            _lastHarmfulTarget =(new Label(TargetManager.LastHarmfulTarget_name, true, HUE_FONT, 80, FONT, Renderer.FontStyle.BlackBorder, IO.Resources.TEXT_ALIGN_TYPE.TS_LEFT)
            {
                X = 90,
                Y = 290
            });
            Add(new Label("LastBeneficialTarget:", true, 60, 70, FONT, Renderer.FontStyle.BlackBorder, IO.Resources.TEXT_ALIGN_TYPE.TS_LEFT)
            {
                X = 10,
                Y = 330
            });
            _lastBeneficialTarget = (new Label(TargetManager.LastBeneficialTarget_name, true, HUE_FONT, 80, FONT, Renderer.FontStyle.BlackBorder, IO.Resources.TEXT_ALIGN_TYPE.TS_LEFT)
            {
                X = 90,
                Y = 330
            });
            Add(new Label("SelectTarget:", true, 50, 70, FONT, Renderer.FontStyle.BlackBorder, IO.Resources.TEXT_ALIGN_TYPE.TS_LEFT)
            {
                X = 10,
                Y = 370
            });
            _selectTarget = (new Label(TargetManager.SelectedTarget_name, true, HUE_FONT, 80, FONT, Renderer.FontStyle.BlackBorder, IO.Resources.TEXT_ALIGN_TYPE.TS_LEFT)
            {
                X = 90,
                Y = 370
            });
            Add(_lastTarget);
            Add(_lastHarmfulTarget);
            Add(_lastBeneficialTarget);
            Add(_selectTarget);

            Add(new Label("LastGump:", true, 60, 70, FONT, Renderer.FontStyle.BlackBorder, IO.Resources.TEXT_ALIGN_TYPE.TS_LEFT)
            {
                X = 10,
                Y = 410
            });
            _lastGump = new Label("", true, HUE_FONT, 80, FONT, Renderer.FontStyle.BlackBorder, IO.Resources.TEXT_ALIGN_TYPE.TS_LEFT)
            {
                X = 90,
                Y = 410
            };
            Add(new Label("LastButton:", true, 60, 70, FONT, Renderer.FontStyle.BlackBorder, IO.Resources.TEXT_ALIGN_TYPE.TS_LEFT)
            {
                X = 10,
                Y = 450
            }
            );
            _lastButton = new Label(LastButton.ToString(), true, HUE_FONT, 80, FONT, Renderer.FontStyle.BlackBorder, IO.Resources.TEXT_ALIGN_TYPE.TS_LEFT)
            {
                X = 90,
                Y = 450
            };

            Add(_lastGump);
            Add(_lastButton);

            //Add(new NiceButton(10, 490, 20, 20, ButtonAction.Activate, "1", 6) { ButtonParameter = (int)TargetButton.Object_1, IsSelected = (TargetManager.Object_1 != 0) });
            //Add(new NiceButton(10, 530, 20, 20, ButtonAction.Activate, "2", 7) { ButtonParameter = (int)TargetButton.Object_2, IsSelected = (TargetManager.Object_2 != 0) });
            //Add(new NiceButton(10, 570, 20, 20, ButtonAction.Activate, "3", 8) { ButtonParameter = (int)TargetButton.Object_3, IsSelected = (TargetManager.Object_3 != 0) });
            //Add(new NiceButton(10, 610, 20, 20, ButtonAction.Activate, "4", 9) { ButtonParameter = (int)TargetButton.Object_4, IsSelected = (TargetManager.Object_4 != 0) });
            //Add(new NiceButton(10, 650, 20, 20, ButtonAction.Activate, "5", 10) { ButtonParameter = (int)TargetButton.Object_5, IsSelected = (TargetManager.Object_5 != 0) });

            //_obj1 = new Label("", true, HUE_FONT, 80, FONT)
            //{
            //    X = 90,
            //    Y = 490,
            //};
            //_obj2 = new Label("", true, HUE_FONT, 80, FONT)
            //{
            //    X = 90,
            //    Y = 530,
            //};

            //_obj3 = new Label("", true, HUE_FONT, 80, FONT)
            //{
            //    X = 90,
            //    Y = 570,
            //};
            //_obj4 = new Label("", true, HUE_FONT, 80, FONT)
            //{
            //    X = 90,
            //    Y = 610,
            //};
            //_obj5 = new Label("", true, HUE_FONT, 80, FONT)
            //{
            //    X = 90,
            //    Y = 650,
            //};
            //Add(_obj1);
            //Add(_obj2);
            //Add(_obj3);
            //Add(_obj4);
            //Add(_obj5);
            //Add(new Label("LastObject:", true, 60, 70, FONT, Renderer.FontStyle.BlackBorder, IO.Resources.TEXT_ALIGN_TYPE.TS_LEFT)
            //{
            //    X = 10,
            //    Y = 690
            //});
            //_lastObjectGump = new Label("", true, HUE_FONT, 80, FONT, Renderer.FontStyle.BlackBorder, IO.Resources.TEXT_ALIGN_TYPE.TS_LEFT)
            //{
            //    X = 90,
            //    Y = 690
            //};
            //Add(_lastObjectGump);
        }
        public void SetName()
        {
            _name1.Text = TargetManager.Target_1_name;
            _name2.Text = TargetManager.Target_2_name;
            _name3.Text = TargetManager.Target_3_name;
            _name4.Text = TargetManager.Target_4_name;
            _name5.Text = TargetManager.Target_5_name;

            //_obj1.Text = TargetManager.Object_1_name;
            //_obj2.Text = TargetManager.Object_2_name;
            //_obj3.Text = TargetManager.Object_3_name;
            //_obj4.Text = TargetManager.Object_4_name;
            //_obj5.Text = TargetManager.Object_5_name;

            //_lastObjectGump.Text = GameActions.LastObject_name;

            _lastTarget.Text = TargetManager.LastTarget_name;
            _lastHarmfulTarget.Text = TargetManager.LastHarmfulTarget_name;
            _lastBeneficialTarget.Text = TargetManager.LastBeneficialTarget_name;
            _selectTarget.Text = TargetManager.SelectedTarget_name;
            if (LastGump != 0)
                _lastGump.Text = LastGump.ToString();
            else
                _lastGump.Text = "";
            _lastButton.Text = LastButton.ToString();

        }
        public override void OnButtonClick(int buttonID)
        {
            switch ((TargetButton)buttonID)
            {
                case TargetButton.Target_1:
                    if (!TargetManager.IsTargeting)
                        TargetManager.SetTargeting(CursorTarget.Target_1, 0, TargetType.Neutral);
                    else
                        TargetManager.CancelTarget();
                    break;

                case TargetButton.Target_2:
                    if (!TargetManager.IsTargeting)
                        TargetManager.SetTargeting(CursorTarget.Target_2, 0, TargetType.Neutral);
                    else
                        TargetManager.CancelTarget();
                    break;


                case TargetButton.Target_3:
                    if (!TargetManager.IsTargeting)
                        TargetManager.SetTargeting(CursorTarget.Target_3, 0, TargetType.Neutral);
                    else
                        TargetManager.CancelTarget();
                    break;

                case TargetButton.Target_4:
                    if (!TargetManager.IsTargeting)
                        TargetManager.SetTargeting(CursorTarget.Target_4, 0, TargetType.Neutral);
                    else
                        TargetManager.CancelTarget();
                    break;
                case TargetButton.Target_5:
                    if (!TargetManager.IsTargeting)
                        TargetManager.SetTargeting(CursorTarget.Target_5, 0, TargetType.Neutral);
                    else
                        TargetManager.CancelTarget();
                    break;
                //case TargetButton.Object_1:
                //    if (!TargetManager.IsTargeting)
                //        TargetManager.SetTargeting(CursorTarget.Object_1, 0, TargetType.Neutral);
                //    else
                //        TargetManager.CancelTarget();
                //    break;
                //case TargetButton.Object_2:
                //    if (!TargetManager.IsTargeting)
                //        TargetManager.SetTargeting(CursorTarget.Object_2, 0, TargetType.Neutral);
                //    else
                //        TargetManager.CancelTarget();
                //    break;
                //case TargetButton.Object_3:
                //    if (!TargetManager.IsTargeting)
                //        TargetManager.SetTargeting(CursorTarget.Object_3, 0, TargetType.Neutral);
                //    else
                //        TargetManager.CancelTarget();
                //    break;
                //case TargetButton.Object_4:
                //    if (!TargetManager.IsTargeting)
                //        TargetManager.SetTargeting(CursorTarget.Object_4, 0, TargetType.Neutral);
                //    else
                //        TargetManager.CancelTarget();
                //    break;
                //case TargetButton.Object_5:
                //    if (!TargetManager.IsTargeting)
                //        TargetManager.SetTargeting(CursorTarget.Object_5, 0, TargetType.Neutral);
                //    else
                //        TargetManager.CancelTarget();
                //    break;
            }
            SetName();
        }

        private enum TargetButton
        {
            Target_1,
            Target_2,
            Target_3,
            Target_4,
            Target_5,
            //Object_1,
            //Object_2,
            //Object_3,
            //Object_4,
            //Object_5
        }
        protected override void OnDragEnd(int x, int y)
        {
            _lastX = ScreenCoordinateX;
            _lastY = ScreenCoordinateY;
            SetInScreen();

            base.OnDragEnd(x, y);
        }
    }
}
