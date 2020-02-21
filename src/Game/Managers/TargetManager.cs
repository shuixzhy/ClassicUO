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

using System;
using System.Collections.Generic;
using ClassicUO.Configuration;
using ClassicUO.Data;
using ClassicUO.Game.Data;
using ClassicUO.Game.GameObjects;
using ClassicUO.Game.Scenes;
using ClassicUO.Game.UI.Gumps;
using ClassicUO.Input;
using ClassicUO.IO;
using ClassicUO.IO.Resources;
using ClassicUO.Network;

namespace ClassicUO.Game.Managers
{
    enum CursorTarget
    {
        Invalid = -1,
        Object = 0,
        Position = 1,
        MultiPlacement = 2,
        SetTargetClientSide = 3,
        Grab,
        SetGrabBag,
        HueCommandTarget,
        AddToLootlist,
        AddToSelllist,
        AddToBuylist,
        Target_1,
        Target_2,
        Target_3,
        Target_4,
        Target_5,
        Clear,
        //Object_1,
        //Object_2,
        //Object_3,
        //Object_4,
        //Object_5,
        Supply
    }

    internal class CursorType
    {
        public static readonly uint Target = 6983686;
    }

    enum TargetType
    {
        Neutral,
        Harmful,
        Beneficial,
        Cancel
    }

    internal class MultiTargetInfo
    {
        public readonly ushort XOff, YOff, ZOff, Model, Hue;

        public MultiTargetInfo(ushort model, ushort x, ushort y, ushort z, ushort hue)
        {
            Model = model;
            XOff = x;
            YOff = y;
            ZOff = z;
            Hue = hue;
        }
    }

    internal static class TargetManager
    {
        private static uint _targetCursorId;

        private static byte[] _lastDataBuffer = new byte[19];


        public static MultiTargetInfo MultiTargetInfo { get; private set; }

        public static CursorTarget TargetingState { get; private set; } = CursorTarget.Invalid;

        public static uint LastTarget, LastAttack, SelectedTarget;
        public static uint LastHarmfulTarget { get; set; }
        public static uint LastBeneficialTarget { get; set; }

        public static bool IsTargeting { get; private set; }

        public static TargetType TargeringType { get; private set; }
        public static uint Target_1 { get; set; }
        public static uint Target_2 { get; set; }
        public static uint Target_3 { get; set; }
        public static uint Target_4 { get; set; }
        public static uint Target_5 { get; set; }
        public static string Target_1_name { get; set; }
        public static string Target_2_name { get; set; }
        public static string Target_3_name { get; set; }
        public static string Target_4_name { get; set; }
        public static string Target_5_name { get; set; }
        public static ushort Object_1 { get; set; }
        public static ushort Object_2 { get; set; }
        public static ushort Object_3 { get; set; }
        public static ushort Object_4 { get; set; }
        public static ushort Object_5 { get; set; }
        //public static string Object_1_name { get; set; }
        //public static string Object_2_name  { get; set; }
        //public static string Object_3_name { get; set; }
        //public static string Object_4_name { get; set; }
        //public static string Object_5_name { get; set; }
        public static string LastHarmfulTarget_name { get; set; }
        public static string LastBeneficialTarget_name { get; set; }
        public static string LastTarget_name { get; set; }
        public static string SelectedTarget_name { get; set; }


        public static void ClearTargetingWithoutTargetCancelPacket()
        {
            if (TargetingState == CursorTarget.MultiPlacement) World.HouseManager.Remove(0);
            IsTargeting = false;
        }

        public static void Reset()
        {
            ClearTargetingWithoutTargetCancelPacket();

            TargetingState = 0;
            _targetCursorId = 0;
            MultiTargetInfo = null;
            TargeringType = 0;
        }

        public static void SetTargeting(CursorTarget targeting, uint cursorID, TargetType cursorType)
        {
            if (targeting == CursorTarget.Invalid)
                return;

            TargetingState = targeting;
            _targetCursorId = cursorID;
            TargeringType = cursorType;

            bool lastTargetting = IsTargeting;
            IsTargeting = cursorType < TargetType.Cancel;

            if (IsTargeting)
                UIManager.RemoveTargetLineGump(LastTarget);
            else if (lastTargetting)
            {
                CancelTarget();
            }
        }


        public static void CancelTarget()
        {
            if (TargetingState == CursorTarget.MultiPlacement)
            {
                World.HouseManager.Remove(0);

                if (World.CustomHouseManager != null)
                {
                    World.CustomHouseManager.Erasing = false;
                    World.CustomHouseManager.SeekTile = false;
                    World.CustomHouseManager.SelectedGraphic = 0;
                    World.CustomHouseManager.CombinedStair = false;

                    UIManager.GetGump<HouseCustomizationGump>()?.Update();
                }
            }
            NetClient.Socket.Send(new PTargetCancel(TargetingState, _targetCursorId, (byte) TargeringType));
            IsTargeting = false;
        }

        public static void SetTargetingMulti(uint deedSerial, ushort model, ushort x, ushort y, ushort z, ushort hue)
        {
            SetTargeting(CursorTarget.MultiPlacement, deedSerial, TargetType.Neutral);

            //if (model != 0)
                MultiTargetInfo = new MultiTargetInfo(model, x, y, z, hue);
        }


        public static void Target(uint serial)
        {
            if (!IsTargeting)
                return;

            Entity entity = World.InGame ? World.Get(serial) : null;

            if (entity != null)
            {

                switch (TargetingState)
                {
                    case CursorTarget.Invalid:                     
                        return;
                    case CursorTarget.MultiPlacement:
                    case CursorTarget.Position:
                    case CursorTarget.Object:
                    case CursorTarget.HueCommandTarget:
                    case CursorTarget.SetTargetClientSide:
                        Mobile m = World.Mobiles.Get(entity);
                        if (entity != World.Player)
                        {
                            UIManager.RemoveTargetLineGump(LastAttack);
                            UIManager.RemoveTargetLineGump(LastTarget);
                            LastTarget = entity.Serial;
                            LastTarget_name = entity.Name;
                            TargetMenuGump tm = UIManager.GetGump<TargetMenuGump>();
                            if (tm != null)
                            {
                                tm.SetName();
                            }
                        }
                        if (m != null && m != World.Player)
                        {
                            switch (m.NotorietyFlag)
                            {
                                case NotorietyFlag.Ally:
                                case NotorietyFlag.Innocent:
                                    LastBeneficialTarget = entity.Serial;
                                    LastBeneficialTarget_name = entity.Name;
                                    TargetMenuGump tm = UIManager.GetGump<TargetMenuGump>();
                                    if (tm != null)
                                    {
                                        tm.SetName();
                                    }
                                    break;
                                case NotorietyFlag.Enemy:
                                case NotorietyFlag.Gray:
                                case NotorietyFlag.Murderer:
                                case NotorietyFlag.Unknown:
                                case NotorietyFlag.Criminal:

                                    LastHarmfulTarget = entity.Serial;
                                    LastHarmfulTarget_name = entity.Name;
                                    tm = UIManager.GetGump<TargetMenuGump>();
                                    if (tm != null)
                                    {
                                        tm.SetName();
                                    }
                                    break;
                            }

                        }
                        if (TargeringType == TargetType.Harmful && SerialHelper.IsMobile(serial) &&
                            ProfileManager.Current.EnabledCriminalActionQuery)
                        {
                            Mobile mobile = entity as Mobile;

                            if (((World.Player.NotorietyFlag == NotorietyFlag.Innocent ||
                                  World.Player.NotorietyFlag == NotorietyFlag.Ally) && mobile.NotorietyFlag == NotorietyFlag.Innocent && serial != World.Player))
                            {
                                QuestionGump messageBox = new QuestionGump(LanguageManager.Current.UI_Public_Criminal,
                                                                           s =>
                                                                           {
                                                                               if (s)
                                                                               {
                                                                                   NetClient.Socket.Send(new PTargetObject(entity, entity.Graphic, entity.X, entity.Y, entity.Z, _targetCursorId, (byte) TargeringType));
                                                                                   ClearTargetingWithoutTargetCancelPacket();
                                                                               }
                                                                           });

                                UIManager.Add(messageBox);

                                return;
                            }
                        }

                        var packet = new PTargetObject(entity, entity.Graphic, entity.X, entity.Y, entity.Z, _targetCursorId, (byte) TargeringType);
                       
                        for (int i = 0; i < _lastDataBuffer.Length; i++)
                        {
                            _lastDataBuffer[i] = packet[i];
                        }

                        NetClient.Socket.Send(packet);
                        ClearTargetingWithoutTargetCancelPacket();

                        Mouse.CancelDoubleClick = true;
                        break;
                    case CursorTarget.Grab:

                        if (SerialHelper.IsItem(serial))
                        {
                            GameActions.GrabItem(serial, ((Item) entity).Amount);
                        }

                        ClearTargetingWithoutTargetCancelPacket();

                        return;
                    case CursorTarget.SetGrabBag:

                        if (SerialHelper.IsItem(serial))
                        {
                            ProfileManager.Current.GrabBagSerial = serial;
                            GameActions.Print(LanguageManager.Current.UI_GrabBagSet+ $"{ serial}");
                        }

                        ClearTargetingWithoutTargetCancelPacket();

                        return;
                    case CursorTarget.AddToLootlist:
                        Item item = World.Items.Get(serial);
                        if (SerialHelper.IsItem(serial))
                        {
                            
                            ushort[] obj = new ushort[2];
                            obj[0] = item.Graphic;
                            obj[1] = item.Hue;

                            if (ProfileManager.Current.LootList == null)
                            {
                                ProfileManager.Current.LootList = new List<ushort[]>();
                            }
                            bool contain = false;
                            foreach (ushort[] i in ProfileManager.Current.LootList)
                            {
                                if (obj[0] == i[0] && obj[1] == i[1])
                                {
                                    contain = true;
                                    break;
                                }

                            }
                            if (!contain)
                            {
                                ProfileManager.Current.LootList.Add(obj);
                                UIManager.GetGump<LootListGump>()?.Dispose();
                                UIManager.Add(new LootListGump());
                            }

                        }
                        ClearTargetingWithoutTargetCancelPacket();
                        return;
                    case CursorTarget.AddToSelllist:
                        
                        if (SerialHelper.IsItem(serial))
                        {
                            item = World.GetOrCreateItem(serial);
                            ushort[] obj = new ushort[3];
                            obj[0] = item.Graphic;
                            obj[1] = item.Hue;
                            obj[2] = (ushort)ProfileManager.Current.AutoBuyAmount;

                            if (ProfileManager.Current.SellList == null)
                            {
                                ProfileManager.Current.SellList = new List<ushort[]>();
                            }
                            bool contain = false;
                            foreach (ushort[] i in ProfileManager.Current.SellList)
                            {
                                if (obj[0] == i[0] && obj[1] == i[1])
                                {
                                    contain = true;
                                    break;
                                }

                            }
                            if (!contain)
                            {
                                ProfileManager.Current.SellList.Add(obj);
                                UIManager.GetGump<SellListGump>()?.Dispose();
                                UIManager.Add(new SellListGump(false));
                            }

                        }
                        ClearTargetingWithoutTargetCancelPacket();
                        return;
                    case CursorTarget.AddToBuylist:

                        if (SerialHelper.IsItem(serial))
                        {
                            item = World.GetOrCreateItem(serial);
                            ushort[] obj = new ushort[3];
                            obj[0] = item.Graphic;
                            obj[1] = item.Hue;
                            obj[2] = (ushort)ProfileManager.Current.AutoBuyAmount;

                            if (ProfileManager.Current.BuyList == null)
                            {
                                ProfileManager.Current.BuyList = new List<ushort[]>();
                            }
                            bool contain = false;
                            foreach (ushort[] i in ProfileManager.Current.BuyList)
                            {
                                if (obj[0] == i[0] && obj[1] == i[1])
                                {
                                    contain = true;
                                    break;
                                }

                            }
                            if (!contain)
                            {
                                ProfileManager.Current.BuyList.Add(obj);
                                UIManager.GetGump<SellListGump>()?.Dispose();
                                UIManager.Add(new SellListGump(true));
                            }

                        }
                        ClearTargetingWithoutTargetCancelPacket();
                        return;
                    case CursorTarget.Target_1:
                        if (SerialHelper.IsMobile(serial))
                        {
                            m = World.GetOrCreateMobile(serial);
                            Target_1 = m;
                            Target_1_name = entity.Name;
                            TargetMenuGump tm = UIManager.GetGump<TargetMenuGump>();
                            if (tm != null)
                            {
                                tm.SetName();
                            }

                        }

                        ClearTargetingWithoutTargetCancelPacket();

                        return;
                    case CursorTarget.Target_2:
                        if (SerialHelper.IsMobile(serial))
                        {
                            m = World.GetOrCreateMobile(serial);
                            Target_2 = m;
                            Target_2_name = entity.Name;
                            TargetMenuGump tm = UIManager.GetGump<TargetMenuGump>();
                            if (tm != null)
                            {
                                tm.SetName();
                            }
                        }

                        ClearTargetingWithoutTargetCancelPacket();

                        return;
                    case CursorTarget.Target_3:
                        if (SerialHelper.IsMobile(serial))
                        {
                            m = World.GetOrCreateMobile(serial);
                            Target_3 = m;
                            Target_3_name = entity.Name;
                            TargetMenuGump tm = UIManager.GetGump<TargetMenuGump>();
                            if (tm != null)
                            {
                                tm.SetName();
                            }
                        }

                        ClearTargetingWithoutTargetCancelPacket();

                        return;
                    case CursorTarget.Target_4:
                        if (SerialHelper.IsMobile(serial))
                        {
                            m = World.GetOrCreateMobile(serial);
                            Target_4 = m;
                            Target_4_name = m.Name;
                            TargetMenuGump tm = UIManager.GetGump<TargetMenuGump>();
                            if (tm != null)
                            {
                                tm.SetName();
                            }
                        }

                        ClearTargetingWithoutTargetCancelPacket();

                        return;
                    case CursorTarget.Target_5:

                        if (SerialHelper.IsMobile(serial))
                        {
                            m = World.GetOrCreateMobile(serial);
                            Target_5 = m;
                            Target_5_name = m.Name;
                            TargetMenuGump tm = UIManager.GetGump<TargetMenuGump>();
                            if (tm != null)
                            {
                                tm.SetName();
                            }
                        }

                        ClearTargetingWithoutTargetCancelPacket();

                        return;
                    case CursorTarget.Clear:
                        if (SerialHelper.IsItem(serial))
                        {
                            PlayerMobile.MoveObject = true;
                            PlayerMobile.MoveType = 0;
                            PlayerMobile.MoveBag = World.GetOrCreateItem(serial);
                        }
                        ClearTargetingWithoutTargetCancelPacket();
                        return;
                    case CursorTarget.Supply:
                        if (SerialHelper.IsItem(serial))
                        {
                            PlayerMobile.MoveObject = true;
                            PlayerMobile.MoveType = 1;
                            PlayerMobile.MoveBag = World.GetOrCreateItem(serial);
                        }
                        ClearTargetingWithoutTargetCancelPacket();
                        return;
//                    case CursorTarget.Object_1:
//                        if (SerialHelper.IsItem(serial))
//                        {
//                            item = World.GetOrCreateItem(serial);
//                            Object_1 = item.Graphic;
////                            Object_1_name = item.Name;
//                            TargetMenuGump tm = UIManager.GetGump<TargetMenuGump>();
//                            if (tm != null)
//                            {
//                                tm.SetName();
//                            }
//                        }
//                        ClearTargetingWithoutTargetCancelPacket();
//                        return;
                    
//                    case CursorTarget.Object_2:
//                        if (SerialHelper.IsItem(serial))
//                        {
//                            item = World.GetOrCreateItem(serial);
//                            Object_2 = item.Graphic;
//                            //Object_2_name = item.Name;
//                            TargetMenuGump tm = UIManager.GetGump<TargetMenuGump>();
//                            if (tm != null)
//                            {
//                                tm.SetName();
//                            }
//                        }
//                        ClearTargetingWithoutTargetCancelPacket();
//                        return;
//                    case CursorTarget.Object_3:
//                        if (SerialHelper.IsItem(serial))
//                        {
//                            item = World.GetOrCreateItem(serial);
//                            Object_3 = item.Graphic;
//                            //Object_3_name = item.Name;
//                            TargetMenuGump tm = UIManager.GetGump<TargetMenuGump>();
//                            if (tm != null)
//                            {
//                                tm.SetName();
//                            }
//                        }
//                        ClearTargetingWithoutTargetCancelPacket();
//                        return;
//                    case CursorTarget.Object_4:
//                        if (SerialHelper.IsItem(serial))
//                        {
//                            item = World.GetOrCreateItem(serial);
//                            Object_4 = item.Graphic;
//                            //Object_4_name = item.Name;
//                            TargetMenuGump tm = UIManager.GetGump<TargetMenuGump>();
//                            if (tm != null)
//                            {
//                                tm.SetName();
//                            }
//                        }
//                        ClearTargetingWithoutTargetCancelPacket();
//                        return;
//                    case CursorTarget.Object_5:
//                        if (SerialHelper.IsItem(serial))
//                        {
//                            item = World.GetOrCreateItem(serial);
//                            Object_5 = item.Graphic;
//                            //Object_5_name = item.Name;
//                            TargetMenuGump tm = UIManager.GetGump<TargetMenuGump>();
//                            if (tm != null)
//                            {
//                                tm.SetName();
//                            }
//                        }
//                        ClearTargetingWithoutTargetCancelPacket();
//                        return;
                }
            }
        }

        public static void Target(ushort graphic, ushort x, ushort y, short z, bool wet = false)
        {
            if (!IsTargeting)
                return;

            if (graphic == 0)
            {
                if (TargeringType != TargetType.Neutral && !wet)
                    return;
            }
            else
            {
                if (graphic >= TileDataLoader.Instance.StaticData.Length)
                    return;

                ref readonly var itemData = ref TileDataLoader.Instance.StaticData[graphic];

                if (Client.Version >= ClientVersion.CV_7090 && itemData.IsSurface)
                {
                    z += itemData.Height;
                }
            }

            TargetPacket(graphic, x, y, (sbyte) z);
        }

        public static void SendMultiTarget(ushort x, ushort y, sbyte z)
        {
            TargetPacket(0, x, y, z);
            MultiTargetInfo = null;
        }

        public static void TargetLast()
        {
            if (!IsTargeting)
                return;

            _lastDataBuffer[0] = 0x6C;
            _lastDataBuffer[1] = (byte) TargetingState;
            _lastDataBuffer[2] = (byte) (_targetCursorId >> 24);
            _lastDataBuffer[3] = (byte) (_targetCursorId >> 16);
            _lastDataBuffer[4] = (byte) (_targetCursorId >> 8);
            _lastDataBuffer[5] = (byte) _targetCursorId;
            _lastDataBuffer[6] = (byte) TargeringType;

            NetClient.Socket.Send(_lastDataBuffer);
            Mouse.CancelDoubleClick = true;
            ClearTargetingWithoutTargetCancelPacket();
        }

        private static void TargetPacket(ushort graphic, ushort x, ushort y, sbyte z)
        {
            if (!IsTargeting)
                return;

            var packet = new PTargetXYZ(x, y, z, graphic, _targetCursorId, (byte) TargeringType);       
            NetClient.Socket.Send(packet);
            for (int i = 0; i < _lastDataBuffer.Length; i++)
            {
                _lastDataBuffer[i] = packet[i];
            }

            Mouse.CancelDoubleClick = true;
            ClearTargetingWithoutTargetCancelPacket();
        }
    }
}
