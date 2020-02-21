
using System.IO;
using Newtonsoft.Json;

using static ClassicUO.Configuration.LanguageManager;

namespace ClassicUO.Configuration
{
    internal sealed class Language
    {
        [JsonConstructor]
        public Language()
        {

        }
        [JsonProperty] public string UI_Updata { get; set; } = "Updata Client";
        [JsonProperty] public string UI_Apply { get; set; } = "Apply";
        [JsonProperty] public string UI_Cancel { get; set; } = "Cancel";
        [JsonProperty] public string UI_OK { get; set; } = "OK";
        [JsonProperty] public string UI_Default { get; set; } = "Default";
        [JsonProperty] public string UI_Delete { get; set; } = "Delete";
        [JsonProperty] public string UI_Add { get; set; } = "Add";
        [JsonProperty] public string UI_Looting { get; set; } = "Looting:";
        [JsonProperty] public string UI_TryOpen { get; set; } = "Try open corpse of:";
        [JsonProperty] public string UI_AddMacroButton { get; set; } = "+ Create macro button";
        [JsonProperty] public string UI_Remove { get; set; } = "Remove";
        [JsonProperty] public string UI_HELP { get; set; } = "HELP";
        [JsonProperty] public string UI_OPTIONS { get; set; } = "OPTIONS";
        [JsonProperty] public string UI_LOGOUT { get; set; } = "LOG OUT";
        [JsonProperty] public string UI_QUESTS { get; set; } = "QUESTS";
        [JsonProperty] public string UI_SKILLS { get; set; } = "SKILLS";
        [JsonProperty] public string UI_GUILD { get; set; } = "GUILD";

        [JsonProperty] public string UI_TargetMenu { get; set; } = "Target List";
        

        [JsonProperty] public string UI_Options_MainBtn_General { get; set; } = "General";
        [JsonProperty] public string UI_Options_MainBtn_Sounds { get; set; } = "Sounds";
        [JsonProperty] public string UI_Options_MainBtn_Video { get; set; } = "Video";
        [JsonProperty] public string UI_Options_MainBtn_Macro { get; set; } = "Macro";
        [JsonProperty] public string UI_Options_MainBtn_Fonts { get; set; } = "Fonts";
        [JsonProperty] public string UI_Options_MainBtn_Speech { get; set; } = "Speech";
        [JsonProperty] public string UI_Options_MainBtn_CombatSpells { get; set; } = "Combat / Spells";
        [JsonProperty] public string UI_Options_MainBtn_Counters { get; set; } = "Counters";
        [JsonProperty] public string UI_Options_MainBtn_Experimental { get; set; } = "Experimental";
        [JsonProperty] public string UI_Options_MainBtn_Network { get; set; } = "Network";
        [JsonProperty] public string UI_Options_MainBtn_InfoBar { get; set; } = "Info Bar";
        [JsonProperty] public string UI_Options_MainBtn_Container { get; set; } = "Container";
        [JsonProperty] public string UI_Options_MainBtn_Autopilot { get; set; } = "AutoPilot";
        //general
        [JsonProperty] public string UI_Options_General_Language { get; set; } = "Language";
        [JsonProperty] public string UI_Options_General_FPS { get; set; } = "- FPS:";
        [JsonProperty] public string UI_Options_General_FPSLogin { get; set; } = "- Login FPS:";
        [JsonProperty] public string UI_Options_General_ReduceFPSWhenInactive { get; set; } = "Reduce FPS when game is inactive";
        [JsonProperty] public string UI_Options_General_HighlightGameObjects { get; set; } = "Highlight game objects";
        [JsonProperty] public string UI_Options_General_EnablePathfind { get; set; } = "Enable pathfinding";
        [JsonProperty] public string UI_Options_General_ShiftPathfind { get; set; } = "Press Shift pathfinding";
        [JsonProperty] public string UI_Options_General_AlwaysRun { get; set; } = "Always run";
        [JsonProperty] public string UI_Options_General_Unlesshidden { get; set; } = "Unless hidden";
        [JsonProperty] public string UI_Options_General_TopbarGumpIsDisabled { get; set; } = "Disable the Menu Bar";
        [JsonProperty] public string UI_Options_General_HoldDownKeyTab { get; set; } = "Hold TAB key for combat";
        [JsonProperty] public string UI_Options_General_HoldDownKeyAltToCloseAnchored { get; set; } = "Hold ALT key + right click to close Anchored gumps";
        [JsonProperty] public string UI_Options_General_HoldShiftForContext { get; set; } = "Hold Shift for Context Menus";
        [JsonProperty] public string UI_Options_General_CloseAnchoredWhenRight { get; set; } = "Close all Anchored gumps when right click on a group";
        [JsonProperty] public string UI_Options_General_HoldAltToMove { get; set; } = "Hold ALT key to move gumps";
        [JsonProperty] public string UI_Options_General_HoldShiftSplit { get; set; } = "Hold Shift for Split";
        [JsonProperty] public string UI_Options_General_HighlightMobilesByFlags { get; set; } = "Highlight by state (poisoned, yellow hits, paralyzed)";
        [JsonProperty] public string UI_Options_General_PoisonHue { get; set; } = "Poisoned Color";
        [JsonProperty] public string UI_Options_General_ParalyzedHue { get; set; } = "Paralyzed Color";
        [JsonProperty] public string UI_Options_General_InvulnerableHue { get; set; } = "Invulnerable Color";
        [JsonProperty] public string UI_Options_General_NoColorObjectsOutOfRange { get; set; } = "No color for object out of range";
        [JsonProperty] public string UI_Options_General_StandardSkillsGump { get; set; } = "Use standard skills gump";
        [JsonProperty] public string UI_Options_General_ObjectsFading { get; set; } = "Objects fading";
        [JsonProperty] public string UI_Options_General_ShowNewNameInChat { get; set; } = "Show names in message area";
        [JsonProperty] public string UI_Options_General_ShowNewMobileNameIncoming { get; set; } = "Show incoming new mobiles";
        [JsonProperty] public string UI_Options_General_ShowNewCorpseNameIncoming { get; set; } = "Show incoming new corpses";
        [JsonProperty] public string UI_Options_General_SallosEasyGrab { get; set; } = "Sallos easy grab";
        [JsonProperty] public string UI_Options_General_ShowPartyGump { get; set; } = "Show party inviting gump";
        [JsonProperty] public string UI_Options_General_ShowHousesContent { get; set; } = "Show houses content";

        [JsonProperty] public string UI_Options_General_UseCircleOfTransparency { get; set; } = "Enable circle of transparency";
        [JsonProperty] public string UI_Options_General_TransparencyType { get; set; } = "Transparency type:";
        [JsonProperty] public string UI_Options_General_TransparencyFull { get; set; } = "Full";
        [JsonProperty] public string UI_Options_General_TransparencyGradient { get; set; } = "Gradient";
        [JsonProperty] public string UI_Options_General_DrawRoofs { get; set; } = "Hide roof tiles";
        [JsonProperty] public string UI_Options_General_TreeToStumps { get; set; } = "Tree to stumps";
        [JsonProperty] public string UI_Options_General_HideVegetation { get; set; } = "Hide vegetation";
        [JsonProperty] public string UI_Options_General_EnableCaveBorder { get; set; } = "Mark cave tiles";
        [JsonProperty] public string UI_Options_General_ShowMobilesHP { get; set; } = "Show HP";
        [JsonProperty] public string UI_Options_General_ShowMobilesHP_Percentage { get; set; } = "Percentage";
        [JsonProperty] public string UI_Options_General_ShowMobilesHP_Line { get; set; } = "Line";
        [JsonProperty] public string UI_Options_General_ShowMobilesHP_Both { get; set; } = "Both";
        [JsonProperty] public string UI_Options_General_ShowMobilesHP_MobileHPShowWhen { get; set; } = "mode:";
        [JsonProperty] public string UI_Options_General_ShowMobilesHP_MobileHPShowWhen_Always { get; set; } = "Always";
        [JsonProperty] public string UI_Options_General_ShowMobilesHP_MobileHPShowWhen_LessThan100 { get; set; } = "Less than 100%";
        [JsonProperty] public string UI_Options_General_ShowMobilesHP_MobileHPShowWhen_Smart { get; set; } = "Smart";
        [JsonProperty] public string UI_Options_General_CloseHealthbarGumpWhen { get; set; } = "Close healthbar gump when:";
        [JsonProperty] public string UI_Options_General_CloseHealthbarGumpWhen_None { get; set; } = "None";
        [JsonProperty] public string UI_Options_General_CloseHealthbarGumpWhen_MobileOutOfRange { get; set; } = "Mobile Out of Range";
        [JsonProperty] public string UI_Options_General_CloseHealthbarGumpWhen_MobileIsDead { get; set; } = "Mobile is Dead";
        [JsonProperty] public string UI_Options_General_FieldsType { get; set; } = "Fields:";
        [JsonProperty] public string UI_Options_General_FieldsType_NormalFields { get; set; } = "Normal fields";
        [JsonProperty] public string UI_Options_General_FieldsType_StaticFields { get; set; } = "Static fields";
        [JsonProperty] public string UI_Options_General_FieldsType_TileFields { get; set; } = "Tile fields";
        [JsonProperty] public string UI_Options_General_ShopGumpSize { get; set; } = "Shop Gump Size (multiple of 60):";
        [JsonProperty] public string UI_Options_Sounds_Sounds { get; set; } = "Sounds";
        [JsonProperty] public string UI_Options_Sounds_Music { get; set; } = "Music";
        [JsonProperty] public string UI_Options_Sounds_LoginMusic { get; set; } = "Login music";
        [JsonProperty] public string UI_Options_Sounds_Footsteps { get; set; } = "Play Footsteps";
        [JsonProperty] public string UI_Options_Sounds_CombatMusic { get; set; } = "Combat music";
        [JsonProperty] public string UI_Options_Sounds_ReproduceSoundsInBackground { get; set; } = "Reproduce music when ClassicUO is not focused";
        [JsonProperty] public string UI_Options_Video_Debug { get; set; } = "Debugging mode";
        [JsonProperty] public string UI_Options_Video_Borderless { get; set; } = "Borderless window";
        [JsonProperty] public string UI_Options_Video_GameWindowFullSize { get; set; } = "Always use fullsize game window";
        [JsonProperty] public string UI_Options_Video_GameWindowLock { get; set; } = "Lock game window moving/resizing";
        [JsonProperty] public string UI_Options_Video_GameWindowSize { get; set; } = "Game Play Window Size:";
        [JsonProperty] public string UI_Options_Video_GameWindowPosition { get; set; } = "Game Play Window Position:";
        [JsonProperty] public string UI_Options_Video_EnableScaleZoom { get; set; } = "Enable in game zoom scaling (Ctrl + Scroll)";
        [JsonProperty] public string UI_Options_Video_SaveScaleAfterClose { get; set; } = "Save scale after exit";
        [JsonProperty] public string UI_Options_Video_RestoreScaleAfterUnpressCtrl { get; set; } = "Releasing Ctrl Restores Scale";
        [JsonProperty] public string UI_Options_Video_EnableDeathScreen { get; set; } = "Enable Death Screen";
        [JsonProperty] public string UI_Options_Video_EnableBlackWhiteEffect { get; set; } = "Black & White mode for dead player";
        [JsonProperty] public string UI_Options_Video_ShardType { get; set; } = "- Status gump type:";
        [JsonProperty] public string UI_Options_Video_ShardType_Modern { get; set; } = "Modern";
        [JsonProperty] public string UI_Options_Video_ShardType_Old { get; set; } = "Old";
        [JsonProperty] public string UI_Options_Video_ShardType_Outlands { get; set; } = "Outlands";
        [JsonProperty] public string UI_Options_Video_Brighlight { get; set; } = "- Brighlight:";
        [JsonProperty] public string UI_Options_Video_AlternativeLights { get; set; } = "Alternative lights";
        [JsonProperty] public string UI_Options_Video_AltLightsTooltip { get; set; } = "Sets light level to max but still renders lights";
        [JsonProperty] public string UI_Options_Video_LightLevel { get; set; } = "Light level";
        [JsonProperty] public string UI_Options_Video_UseColoredLights { get; set; } = "Use colored lights";
        [JsonProperty] public string UI_Options_Video_UseDarkNights { get; set; } = "Dark nights";
        [JsonProperty] public string UI_Options_Video_ShadowsEnabled { get; set; } = "Shadows";
        [JsonProperty] public string UI_Options_Video_AuraUnderFeet { get; set; } = "- Aura under feet:";
        [JsonProperty] public string UI_Options_Video_AuraUnderFeet_None { get; set; } = "None";
        [JsonProperty] public string UI_Options_Video_AuraUnderFeet_Warmode { get; set; } = "Warmode";
        [JsonProperty] public string UI_Options_Video_AuraUnderFeet_CtrlShift { get; set; } = "Ctrl+Shift";
        [JsonProperty] public string UI_Options_Video_AuraUnderFeet_Always { get; set; } = "Always";
        [JsonProperty] public string UI_Options_Video_PartyAura { get; set; } = "Custom color aura for party members";
        [JsonProperty] public string UI_Options_Video_PartyAuraHue { get; set; } = "Party Aura Color";
        [JsonProperty] public string UI_Options_Video_RunMouseInASeparateThread { get; set; } = "Run mouse in a separate thread";
        [JsonProperty] public string UI_Options_Video_AuraOnMouse { get; set; } = "Aura on mouse target";
        [JsonProperty] public string UI_Options_Video_UseXBR { get; set; } = "Use xBR effect [BETA]";
        [JsonProperty] public string UI_Options_Video_HideChatGradient { get; set; } = "Hide Chat Gradient";
        [JsonProperty] public string UI_Options_Macro_NewMacro { get; set; } = "New macro";
        [JsonProperty] public string UI_Options_Macro_MacroName { get; set; } = "Macro name:";
        [JsonProperty] public string UI_Options_Macro_DeleteMacro { get; set; } = "Delete macro";
        [JsonProperty] public string UI_Options_Macro_QuestionText { get; set; } = "Do you want\ndelete it?";
        [JsonProperty] public string UI_Options_Fonts_OverrideAllFonts { get; set; } = "Override game font";
        [JsonProperty] public string UI_Options_Fonts_Encoded_ASCII { get; set; } = "ASCII";
        [JsonProperty] public string UI_Options_Fonts_Encoded_Unicode { get; set; } = "Unicode";
        [JsonProperty] public string UI_Options_Fonts_SpeechFont { get; set; } = "Force Unicode in journal";
        [JsonProperty] public string UI_Options_Speech_ScaleSpeechDelay { get; set; } = "Scale speech delay";
        [JsonProperty] public string UI_Options_Speech_SaveJournalToFile { get; set; } = "Save Journal to file in game folder";
        [JsonProperty] public string UI_Options_Speech_ActivateChatAfterEnter { get; set; } = "Press `Enter` to activate chat";
        [JsonProperty] public string UI_Options_Speech_ActivateChatAdditionalButtons { get; set; } = "Additional buttons activate chat: ! ; : / \\ , . [ | -";
        [JsonProperty] public string UI_Options_Speech_ActivateChatShiftEnterSupport { get; set; } = "Shift+Enter send message without closing chat";
        [JsonProperty] public string UI_Options_Speech_ActivateChatIgnoreHotkeys { get; set; } = "If chat active - ignores hotkeys from:";
        [JsonProperty] public string UI_Options_Speech_ActivateChatIgnoreHotkeys_Client { get; set; } = "Client (macro system)";
        [JsonProperty] public string UI_Options_Speech_ActivateChatIgnoreHotkeys_Plugins { get; set; } = "Plugins (Razor)";
        [JsonProperty] public string UI_Options_Speech_SpeechHue { get; set; } = "Speech Color";
        [JsonProperty] public string UI_Options_Speech_EmoteHue { get; set; } = "Emote Color";
        [JsonProperty] public string UI_Options_Speech_YellHue { get; set; } = "Yell Color";
        [JsonProperty] public string UI_Options_Speech_WhisperHue { get; set; } = "Whisper Color";
        [JsonProperty] public string UI_Options_Speech_PartyMessageHue { get; set; } = "Party Message Color";
        [JsonProperty] public string UI_Options_Speech_GuildMessageHue { get; set; } = "GuildMessageHue";
        [JsonProperty] public string UI_Options_Speech_AllyMessageHue { get; set; } = "Alliance Message Color";
        [JsonProperty] public string UI_Options_Speech_ChatMessageHue { get; set; } = "Chat Message Color";
        [JsonProperty] public string UI_Options_Combat_EnabledCriminalActionQuery { get; set; } = "Query before attack";
        [JsonProperty] public string UI_Options_Combat_EnabledSpellFormat { get; set; } = "Enable Overhead Spell Format";
        [JsonProperty] public string UI_Options_Combat_EnabledSpellHue { get; set; } = "Enable Overhead Spell Hue";
        [JsonProperty] public string UI_Options_Combat_CastSpellsByOneClick { get; set; } = "Cast spells by one click";
        [JsonProperty] public string UI_Options_Combat_ShowBuffDuration { get; set; } = "Show buff duration";
        [JsonProperty] public string UI_Options_Combat_InnocentHue { get; set; } = "Innocent Color";
        [JsonProperty] public string UI_Options_Combat_FriendHue { get; set; } = "Friend Color";
        [JsonProperty] public string UI_Options_Combat_CriminalHue { get; set; } = "Criminal Color";
        [JsonProperty] public string UI_Options_Combat_AnimalHue { get; set; } = "Animal Color";
        [JsonProperty] public string UI_Options_Combat_MurdererHue { get; set; } = "Murderer Color";
        [JsonProperty] public string UI_Options_Combat_EnemyHue { get; set; } = "Enemy Color";
        [JsonProperty] public string UI_Options_Combat_BeneficHue { get; set; } = "Benefic Spell Hue";
        [JsonProperty] public string UI_Options_Combat_HarmfulHue { get; set; } = "Harmful Spell Hue";
        [JsonProperty] public string UI_Options_Combat_NeutralHue { get; set; } = "Neutral Spell Hue";
        [JsonProperty] public string UI_Options_Combat_SpellDisplayFormat { get; set; } = "Spell Overhead format: ({power} for powerword - {spell} for spell name)";
        [JsonProperty] public string UI_Options_Counters_CounterBarEnabled { get; set; } = "Enable Counters";
        [JsonProperty] public string UI_Options_Counters_CounterBarHighlightOnUse { get; set; } = "Highlight On Use";
        [JsonProperty] public string UI_Options_Counters_CounterBarDisplayAbbreviatedAmount { get; set; } = "Enable abbreviated amount values when amount is or exceeds";
        [JsonProperty] public string UI_Options_Counters_CounterBarHighlightOnAmount { get; set; } = "Highlight red when amount is below";
        [JsonProperty] public string UI_Options_Counters_CounterLayout { get; set; } = "Counter Layout:";
        [JsonProperty] public string UI_Options_Counters_CellSize { get; set; } = "Cell size:";
        [JsonProperty] public string UI_Options_Counters_Rows { get; set; } = "Rows:";
        [JsonProperty] public string UI_Options_Counters_Columns { get; set; } = "Columns:";
        [JsonProperty] public string UI_Options_Experimental_EnableSelectionArea { get; set; } = "Enable Text Selection Area";
        [JsonProperty] public string UI_Options_Experimental_DebugGumpIsDisabled { get; set; } = "Disable Debug Gump";
        [JsonProperty] public string UI_Options_Experimental_RestoreLastGameSize { get; set; } = "Disable automatic maximize. Restore windows size after re-login";

        [JsonProperty] public string UI_Options_Experimental_DisableDefaultHotkeys { get; set; } = "Disable default UO hotkeys";
        [JsonProperty] public string UI_Options_Experimental_DisableArrowBtn { get; set; } = "Disable arrows & numlock arrows (player moving)";
        [JsonProperty] public string UI_Options_Experimental_DisableTabBtn { get; set; } = "Disable TAB (toggle warmode)";
        [JsonProperty] public string UI_Options_Experimental_DisableCtrlQWBtn { get; set; } = "Disable Ctrl + Q/W (messageHistory)";
        [JsonProperty] public string UI_Options_Experimental_EnableDragSelect { get; set; } = "Enable drag-select to open health bars";
        [JsonProperty] public string UI_Options_Experimental_EnableDragSelect_Key { get; set; } = "Drag-select modifier key";
        [JsonProperty] public string UI_Options_Experimental_EnableDragSelect_Key_None { get; set; } = "None";
        [JsonProperty] public string UI_Options_Experimental_EnableDragSelect_Key_Ctrl { get; set; } = "Ctrl";
        [JsonProperty] public string UI_Options_Experimental_EnableDragSelect_Key_Shift { get; set; } = "Shift";
        [JsonProperty] public string UI_Options_Experimental_EnableDragSelect_DragSelectHumanoidsOnly { get; set; } = "Select humanoids only";
        [JsonProperty] public string UI_Options_Experimental_OverrideContainerLocation { get; set; } = "Override container gump location";
        [JsonProperty] public string UI_Options_Experimental_OverrideContainerLocation_NearContainerPosition { get; set; } = "Near container position";
        [JsonProperty] public string UI_Options_Experimental_OverrideContainerLocation_TopRight { get; set; } = "Top right";
        [JsonProperty] public string UI_Options_Experimental_OverrideContainerLocation_LastDraggedPosition { get; set; } = "Last dragged position";
        [JsonProperty] public string UI_Options_Experimental_OverrideContainerLocation_RememberEveryContainer { get; set; } = "Remember every container";
        [JsonProperty] public string UI_Options_Experimental_ShowTargetRange { get; set; } = "Show target range";
        [JsonProperty] public string UI_Options_Experimental_UseCustomHealthBars { get; set; } = "Use Custom Health Bars";
        [JsonProperty] public string UI_Options_Experimental_UseAllBlakBackgrounds { get; set; } = "Use All Black Backgrounds";

        [JsonProperty] public string UI_Options_Network_ShowNetworkStats { get; set; } = "Show network stats";
        [JsonProperty] public string UI_Options_InfoBar_ShowInfoBar { get; set; } = "Show Info Bar";
        [JsonProperty] public string UI_Options_InfoBar_InfoBarHighlightType { get; set; } = "Data highlight type:";
        [JsonProperty] public string UI_Options_InfoBar_InfoBarHighlightType_TextColor { get; set; } = "Text color";
        [JsonProperty] public string UI_Options_InfoBar_InfoBarHighlightType_ColoredBars { get; set; } = "Colored bars";
        [JsonProperty] public string UI_Options_InfoBar_AddItem { get; set; } = "+ Add item";
        [JsonProperty] public string UI_Options_InfoBar_Label { get; set; } = "Label";
        [JsonProperty] public string UI_Options_InfoBar_Color { get; set; } = "Color";
        [JsonProperty] public string UI_Options_InfoBar_Data { get; set; } = "Data";


        [JsonProperty] public string UI_Options_Container_Scale { get; set; } = "- Containers scale:";
        [JsonProperty] public string UI_Options_Container_ItemScale { get; set; } = "Scale items inside containers";
        [JsonProperty] public string UI_Options_Container_DoubleLoot { get; set; } = "Double click to loot items inside containers";
        [JsonProperty] public string UI_Options_Container_RelativeDragDrop { get; set; } = "Relative drag and drop items in containers";

        //autopilot
        [JsonProperty] public string UI_Options_AutoPilot_AutoOpenDoors { get; set; } = "Auto Open Doors";
        [JsonProperty] public string UI_Options_AutoPilot_SmoothDoors { get; set; } = "Smooth doors";
        [JsonProperty] public string UI_Options_AutoPilot_AutoOpenCorpses { get; set; } = "Auto Open Corpses";
        [JsonProperty] public string UI_Options_AutoPilot_SkipEmptyCorpse { get; set; } = "Skip empty corpses";
        [JsonProperty] public string UI_Options_AutoPilot_AutoOpenCorpseRange { get; set; } = "Corpse Open Range:";
        [JsonProperty] public string UI_Options_AutoPilot_CorpseOpenOptions { get; set; } = "Corpse Open Options:";
        [JsonProperty] public string UI_Options_AutoPilot_CorpseOpenOptions_None { get; set; } = "None";
        [JsonProperty] public string UI_Options_AutoPilot_CorpseOpenOptions_NotTargeting { get; set; } = "Not Targeting";
        [JsonProperty] public string UI_Options_AutoPilot_CorpseOpenOptions_NotHiding { get; set; } = "Not Hiding";
        [JsonProperty] public string UI_Options_AutoPilot_CorpseOpenOptions_Both { get; set; } = "Both";
        [JsonProperty] public string UI_Options_AutoPilot_GridLoot { get; set; } = "Grid Loot";
        [JsonProperty] public string UI_Options_AutoPilot_GridLoot_None { get; set; } = "None";
        [JsonProperty] public string UI_Options_AutoPilot_GridLoot_GridLootOnly { get; set; } = "Grid loot only";
        [JsonProperty] public string UI_Options_AutoPilot_GridLoot_Both { get; set; } = "Both";
        [JsonProperty] public string UI_Options_AutoPilot_GridLoot_Scale { get; set; } = "Grid loot Scale:";
        [JsonProperty] public string UI_Options_AutoPilot_GridLoot_ItemInOneLine { get; set; } = "Items in a line:";
        [JsonProperty] public string UI_Options_AutiPilot_AutoLootCoin { get; set; } = "Auto loot coins";
        [JsonProperty] public string UI_Options_AutiPilot_AutoLootItem { get; set; } = "Auto loot items";
        [JsonProperty] public string UI_Options_AutoPilot_AutoLoot_Delay { get; set; } = "Auto loot delay:";
        [JsonProperty] public string UI_Options_AutiPilot_AutoSellItem { get; set; } = "Auto sell/buy items";
        [JsonProperty] public string UI_Options_AutiPilot_AutoLootSet { get; set; } = "Set Loot list";
        [JsonProperty] public string UI_Options_AutiPilot_AutoSellSet { get; set; } = "Set sell list";
        [JsonProperty] public string UI_Options_AutiPilot_AutoBuySet { get; set; } = "Set buy list";
        [JsonProperty] public string UI_Options_AutiPilot_NeedOpenCorpse { get; set; } = "Need open corpse to loot.";
        [JsonProperty] public string UI_Options_AutiPilot_SellAmount { get; set; } = "Maintenance quantity";
        [JsonProperty] public string UI_Options_AutiPilot_MinRange { get; set; } = "Minimum search range(Hostile only)";
        [JsonProperty] public string UI_Options_AutiPilot_MaxRange { get; set; } = "Maximum search range";

        [JsonProperty] public string UI_SureUpdate { get; set; } = "Are you sure \nupdate?";

        [JsonProperty] public string UI_TopBar_Map { get; set; } = "Map";
        [JsonProperty] public string UI_TopBar_Paperdoll { get; set; } = "Paperdoll";
        [JsonProperty] public string UI_TopBar_Inventory { get; set; } = "Inventory";
        [JsonProperty] public string UI_TopBar_Journal { get; set; } = "Journal";
        [JsonProperty] public string UI_TopBar_Chat { get; set; } = "Chat";
        [JsonProperty] public string UI_TopBar_Help { get; set; } = "Help";
        [JsonProperty] public string UI_TopBar_Debug { get; set; } = "Debug";
        [JsonProperty] public string UI_TopBar_WorldMap { get; set; } = "WorldMap";
        [JsonProperty] public string UI_TopBar_UOStore { get; set; } = "UOStore";
        [JsonProperty] public string UI_TopBar_GlobalChat { get; set; } = "Global Chat";

        [JsonProperty] public string UI_WorldMap_Load { get; set; } = "WorldMap loading...";
        [JsonProperty] public string UI_WorldMap_Loaded { get; set; } = "WorldMap loaded!";
        [JsonProperty] public string UI_WorldMap_Flip { get; set; } = "Flip map";
        [JsonProperty] public string UI_WorldMap_TopMost { get; set; } = "Top Most";
        [JsonProperty] public string UI_WorldMap_FreeView { get; set; } = "Free view";
        [JsonProperty] public string UI_WorldMap_ShowPartyMembers { get; set; } = "Show party members";
        [JsonProperty] public string UI_WorldMap_Close { get; set; } = "Close";

        [JsonProperty] public string UI_GridLoot_SetBag { get; set; } = "Set loot bag";
        [JsonProperty] public string UI_GridLoot_ChooseContainer { get; set; } = "Choose your container to loot.";
        [JsonProperty] public string UI_GrabItem { get; set; } = "Target an Item to grab it.";
        [JsonProperty] public string UI_AddItem { get; set; } = "Target an Item to Add in Loot list.";
        [JsonProperty] public string UI_NoGrabBag { get; set; } = "Grab Bag not found, setting to Backpack.";
        [JsonProperty] public string UI_SetClearBag { get; set; } = "Set clear bag.";
        [JsonProperty] public string UI_BagsAreSame { get; set; } = "Grab bag and clear bag are same.";
        [JsonProperty] public string UI_ClearFinish { get; set; } = "Clear bag finished.";
        [JsonProperty] public string UI_GrabBagSet { get; set; } = "Grab Bag set:";

        [JsonProperty] public string UI_Macro_Repeat { get; set; } = "Repeat(Press again or other to stop.)";
        [JsonProperty] public string UI_Macro_Exists { get; set; } = "This key combination\nalready exists.";

        [JsonProperty] public string UI_NameOverHead_All { get; set; } = "All";
        [JsonProperty] public string UI_NameOverHead_MobilesOnly { get; set; } = "Mobiles only";
        [JsonProperty] public string UI_NameOverHead_ItemsOnly { get; set; } = "Items only";
        [JsonProperty] public string UI_NameOverHead_MobielAndCorpsesOnly { get; set; } = "Mobiles and Corpses only";

        [JsonProperty] public string UI_Skill_Name { get; set; } = "Name";
        [JsonProperty] public string UI_Skill_Real { get; set; } = "Real";
        [JsonProperty] public string UI_Skill_Base { get; set; } = "Base";
        [JsonProperty] public string UI_Skill_Cap { get; set; } = "Cap";
        [JsonProperty] public string UI_Skill_Total { get; set; } = "Total:";

        [JsonProperty] public string UI_Public_FindObj { get; set; } = "No found:";
        [JsonProperty] public string UI_Public_Friend { get; set; } = "Friend";
        [JsonProperty] public string UI_Public_Obj { get; set; } = "Object";
        [JsonProperty] public string UI_Public_Enemy { get; set; } = "Hostile";
        [JsonProperty] public string UI_Public_Follower { get; set; } = "Follower";
        [JsonProperty] public string UI_Public_Party { get; set; } = "Party";
        [JsonProperty] public string UI_Public_Mobile { get; set; } = "Mobile";
        [JsonProperty] public string UI_Public_Target { get; set; } = "Target:";
        [JsonProperty] public string UI_Public_AlwaysRun { get; set; } = "Always run is now ";
        [JsonProperty] public string UI_Public_On { get; set; } = "On";
        [JsonProperty] public string UI_Public_Off { get; set; } = "Off";
        [JsonProperty] public string UI_Public_Criminal { get; set; } = "This may flag\nyou criminal!";

        [JsonProperty] public string UI_SkillName_Alchemy { get; set; } = "Alchemy";
        [JsonProperty] public string UI_SkillName_Anatomy { get; set; } = "Anatomy";
        [JsonProperty] public string UI_SkillName_AnimalLore { get; set; } = "Animal Lore";
        [JsonProperty] public string UI_SkillName_ItemIdentification { get; set; } = "Item Identification";
        [JsonProperty] public string UI_SkillName_ArmsLore { get; set; } = "Arms Lore";
        [JsonProperty] public string UI_SkillName_Parrying { get; set; } = "Parrying";
        [JsonProperty] public string UI_SkillName_Begging { get; set; } = "Begging";
        [JsonProperty] public string UI_SkillName_Blacksmithy { get; set; } = "Blacksmithy";
        [JsonProperty] public string UI_SkillName_BowcraftFletching { get; set; } = "Bowcraft/Fletching";
        [JsonProperty] public string UI_SkillName_Peacemaking { get; set; } = "Peacemaking";
        [JsonProperty] public string UI_SkillName_Camping { get; set; } = "Camping";
        [JsonProperty] public string UI_SkillName_Carpentry { get; set; } = "Carpentry";
        [JsonProperty] public string UI_SkillName_Cartography { get; set; } = "Cartography";
        [JsonProperty] public string UI_SkillName_Cooking { get; set; } = "Cooking";
        [JsonProperty] public string UI_SkillName_DetectingHidden { get; set; } = "Detecting Hidden";
        [JsonProperty] public string UI_SkillName_Discordance { get; set; } = "Discordance";
        [JsonProperty] public string UI_SkillName_EvaluatingIntelligence { get; set; } = "Evaluating Intelligence";
        [JsonProperty] public string UI_SkillName_Healing { get; set; } = "Healing";
        [JsonProperty] public string UI_SkillName_Fishing { get; set; } = "Fishing";
        [JsonProperty] public string UI_SkillName_ForensicEvaluation { get; set; } = "Forensic Evaluation";
        [JsonProperty] public string UI_SkillName_Herding { get; set; } = "Herding";
        [JsonProperty] public string UI_SkillName_Hiding { get; set; } = "Hiding";
        [JsonProperty] public string UI_SkillName_Provocation { get; set; } = "Provocation";
        [JsonProperty] public string UI_SkillName_Inscription { get; set; } = "Inscription";
        [JsonProperty] public string UI_SkillName_Lockpicking { get; set; } = "Lockpicking";
        [JsonProperty] public string UI_SkillName_Magery { get; set; } = "Magery";
        [JsonProperty] public string UI_SkillName_ResistingSpells { get; set; } = "Resisting Spells";
        [JsonProperty] public string UI_SkillName_Tactics { get; set; } = "Tactics";
        [JsonProperty] public string UI_SkillName_Snooping { get; set; } = "Snooping";
        [JsonProperty] public string UI_SkillName_Musicianship { get; set; } = "Musicianship";
        [JsonProperty] public string UI_SkillName_Poisoning { get; set; } = "Poisoning";
        [JsonProperty] public string UI_SkillName_Archery { get; set; } = "Archery";
        [JsonProperty] public string UI_SkillName_SpiritSpeak { get; set; } = "Spirit Speak";
        [JsonProperty] public string UI_SkillName_Stealing { get; set; } = "Stealing";
        [JsonProperty] public string UI_SkillName_Tailoring { get; set; } = "Tailoring";
        [JsonProperty] public string UI_SkillName_AnimalTaming { get; set; } = "Animal Taming";
        [JsonProperty] public string UI_SkillName_TasteIdentification { get; set; } = "Taste Identification";
        [JsonProperty] public string UI_SkillName_Tinkering { get; set; } = "Tinkering";
        [JsonProperty] public string UI_SkillName_Tracking { get; set; } = "Tracking";
        [JsonProperty] public string UI_SkillName_Veterinary { get; set; } = "Veterinary";
        [JsonProperty] public string UI_SkillName_Swordsmanship { get; set; } = "Swordsmanship";
        [JsonProperty] public string UI_SkillName_MaceFighting { get; set; } = "Mace Fighting";
        [JsonProperty] public string UI_SkillName_Fencing { get; set; } = "Fencing";
        [JsonProperty] public string UI_SkillName_Wrestling { get; set; } = "Wrestling";
        [JsonProperty] public string UI_SkillName_Lumberjacking { get; set; } = "Lumberjacking";
        [JsonProperty] public string UI_SkillName_Mining { get; set; } = "Mining";
        [JsonProperty] public string UI_SkillName_Meditation { get; set; } = "Meditation";
        [JsonProperty] public string UI_SkillName_Stealth { get; set; } = "Stealth";
        [JsonProperty] public string UI_SkillName_RemoveTrap { get; set; } = "Remove Trap";
        [JsonProperty] public string UI_SkillName_Necromancy { get; set; } = "Necromancy";
        [JsonProperty] public string UI_SkillName_Focus { get; set; } = "Focus";
        [JsonProperty] public string UI_SkillName_Chivalry { get; set; } = "Chivalry";
        [JsonProperty] public string UI_SkillName_Bushido { get; set; } = "Bushido";
        [JsonProperty] public string UI_SkillName_Ninjitsu { get; set; } = "Ninjitsu";
        [JsonProperty] public string UI_SkillName_Spellweaving { get; set; } = "Spellweaving";
        [JsonProperty] public string UI_SkillName_Mysticism { get; set; } = "Mysticism";
        [JsonProperty] public string UI_SkillName_Imbuing { get; set; } = "Imbuing";
        [JsonProperty] public string UI_SkillName_Throwing { get; set; } = "Throwing";

        //魔法
        [JsonProperty] public string UI_SpellName_Clumsy { get; set; } = "Clumsy";
        [JsonProperty] public string UI_SpellName_CreateFood { get; set; } = "Create Food";
        [JsonProperty] public string UI_SpellName_Feeblemind { get; set; } = "Feeblemind";
        [JsonProperty] public string UI_SpellName_Heal { get; set; } = "Heal";
        [JsonProperty] public string UI_SpellName_MagicArrow { get; set; } = "Magic Arrow";
        [JsonProperty] public string UI_SpellName_NightSight { get; set; } = "Night Sight";
        [JsonProperty] public string UI_SpellName_ReactiveArmor { get; set; } = "Reactive Armor";
        [JsonProperty] public string UI_SpellName_Weaken { get; set; } = "Weaken";
        [JsonProperty] public string UI_SpellName_Agility { get; set; } = "Agility";
        [JsonProperty] public string UI_SpellName_Cunning { get; set; } = "Cunning";
        [JsonProperty] public string UI_SpellName_Cure { get; set; } = "Cure";
        [JsonProperty] public string UI_SpellName_Harm { get; set; } = "Harm";
        [JsonProperty] public string UI_SpellName_MagicTrap { get; set; } = "Magic Trap";
        [JsonProperty] public string UI_SpellName_MagicUntrap { get; set; } = "Magic Untrap";
        [JsonProperty] public string UI_SpellName_Protection { get; set; } = "Protection";
        [JsonProperty] public string UI_SpellName_Strength { get; set; } = "Strength";
        [JsonProperty] public string UI_SpellName_Bless { get; set; } = "Bless";
        [JsonProperty] public string UI_SpellName_Fireball { get; set; } = "Fireball";
        [JsonProperty] public string UI_SpellName_MagicLock { get; set; } = "Magic Lock";
        [JsonProperty] public string UI_SpellName_Poison { get; set; } = "Poison";
        [JsonProperty] public string UI_SpellName_Telekinesis { get; set; } = "Telekinesis";
        [JsonProperty] public string UI_SpellName_Teleport { get; set; } = "Teleport";
        [JsonProperty] public string UI_SpellName_Unlock { get; set; } = "Unlock";
        [JsonProperty] public string UI_SpellName_WallofStone { get; set; } = "Wall of Stone";
        [JsonProperty] public string UI_SpellName_ArchCure { get; set; } = "Arch Cure";
        [JsonProperty] public string UI_SpellName_ArchProtection { get; set; } = "Arch Protection";
        [JsonProperty] public string UI_SpellName_Curse { get; set; } = "Curse";
        [JsonProperty] public string UI_SpellName_FireField { get; set; } = "Fire Field";
        [JsonProperty] public string UI_SpellName_GreaterHeal { get; set; } = "Greater Heal";
        [JsonProperty] public string UI_SpellName_Lightning { get; set; } = "Lightning";
        [JsonProperty] public string UI_SpellName_ManaDrain { get; set; } = "Mana Drain";
        [JsonProperty] public string UI_SpellName_Recall { get; set; } = "Recall";
        [JsonProperty] public string UI_SpellName_BladeSpirits { get; set; } = "Blade Spirits";
        [JsonProperty] public string UI_SpellName_DispelField { get; set; } = "Dispel Field";
        [JsonProperty] public string UI_SpellName_Incognito { get; set; } = "Incognito";
        [JsonProperty] public string UI_SpellName_MagicReflection { get; set; } = "Magic Reflection";
        [JsonProperty] public string UI_SpellName_MindBlast { get; set; } = "Mind Blast";
        [JsonProperty] public string UI_SpellName_Paralyze { get; set; } = "Paralyze";
        [JsonProperty] public string UI_SpellName_PoisonField { get; set; } = "Poison Field";
        [JsonProperty] public string UI_SpellName_SummonCreature { get; set; } = "Summon Creature";
        [JsonProperty] public string UI_SpellName_Dispel { get; set; } = "Dispel";
        [JsonProperty] public string UI_SpellName_EnergyBolt { get; set; } = "Energy Bolt";
        [JsonProperty] public string UI_SpellName_Explosion { get; set; } = "Explosion";
        [JsonProperty] public string UI_SpellName_Invisibility { get; set; } = "Invisibility";
        [JsonProperty] public string UI_SpellName_Mark { get; set; } = "Mark";
        [JsonProperty] public string UI_SpellName_MassCurse { get; set; } = "Mass Curse";
        [JsonProperty] public string UI_SpellName_ParalyzeField { get; set; } = "Paralyze Field";
        [JsonProperty] public string UI_SpellName_Reveal { get; set; } = "Reveal";
        [JsonProperty] public string UI_SpellName_ChainLightning { get; set; } = "Chain Lightning";
        [JsonProperty] public string UI_SpellName_EnergyField { get; set; } = "Energy Field";
        [JsonProperty] public string UI_SpellName_Flamestrike { get; set; } = "Flamestrike";
        [JsonProperty] public string UI_SpellName_GateTravel { get; set; } = "Gate Travel";
        [JsonProperty] public string UI_SpellName_ManaVampire { get; set; } = "Mana Vampire";
        [JsonProperty] public string UI_SpellName_MassDispel { get; set; } = "Mass Dispel";
        [JsonProperty] public string UI_SpellName_MeteorSwarm { get; set; } = "Meteor Swarm";
        [JsonProperty] public string UI_SpellName_Polymorph { get; set; } = "Polymorph";
        [JsonProperty] public string UI_SpellName_Earthquake { get; set; } = "Earthquake";
        [JsonProperty] public string UI_SpellName_EnergyVortex { get; set; } = "Energy Vortex";
        [JsonProperty] public string UI_SpellName_Resurrection { get; set; } = "Resurrection";
        [JsonProperty] public string UI_SpellName_AirElemental { get; set; } = "Air Elemental";
        [JsonProperty] public string UI_SpellName_SummonDaemon { get; set; } = "Summon Daemon";
        [JsonProperty] public string UI_SpellName_EarthElemental { get; set; } = "Earth Elemental";
        [JsonProperty] public string UI_SpellName_FireElemental { get; set; } = "Fire Elemental";
        [JsonProperty] public string UI_SpellName_WaterElemental { get; set; } = "Water Elemental";

        //巫术
        [JsonProperty] public string UI_SpellName_AnimateDead { get; set; } = "Animate Dead";
        [JsonProperty] public string UI_SpellName_BloodOath { get; set; } = "Blood Oath";
        [JsonProperty] public string UI_SpellName_CorpseSkin { get; set; } = "Corpse Skin";
        [JsonProperty] public string UI_SpellName_CurseWeapon { get; set; } = "Curse Weapon";
        [JsonProperty] public string UI_SpellName_EvilOmen { get; set; } = "Evil Omen";
        [JsonProperty] public string UI_SpellName_HorrificBeast { get; set; } = "Horrific Beast";
        [JsonProperty] public string UI_SpellName_LichForm { get; set; } = "Lich Form";
        [JsonProperty] public string UI_SpellName_MindRot { get; set; } = "Mind Rot";
        [JsonProperty] public string UI_SpellName_PainSpike { get; set; } = "Pain Spike";
        [JsonProperty] public string UI_SpellName_PoisonStrike { get; set; } = "Poison Strike";
        [JsonProperty] public string UI_SpellName_Strangle { get; set; } = "Strangle";
        [JsonProperty] public string UI_SpellName_SummonFamiliar { get; set; } = "Summon Familiar";
        [JsonProperty] public string UI_SpellName_VampiricEmbrace { get; set; } = "Vampiric Embrace";
        [JsonProperty] public string UI_SpellName_VengefulSpirit { get; set; } = "Vengeful Spirit";
        [JsonProperty] public string UI_SpellName_Wither { get; set; } = "Wither";
        [JsonProperty] public string UI_SpellName_WraithForm { get; set; } = "Wraith Form";
        [JsonProperty] public string UI_SpellName_Exorcism { get; set; } = "Exorcism";

        //圣骑
        [JsonProperty] public string UI_SpellName_CleansebyFire { get; set; } = "Cleanse by Fire";
        [JsonProperty] public string UI_SpellName_CloseWounds { get; set; } = "Close Wounds";
        [JsonProperty] public string UI_SpellName_ConsecrateWeapon { get; set; } = "Consecrate Weapon";
        [JsonProperty] public string UI_SpellName_DispelEvil { get; set; } = "Dispel Evil";
        [JsonProperty] public string UI_SpellName_DivineFury { get; set; } = "Divine Fury";
        [JsonProperty] public string UI_SpellName_EnemyofOne { get; set; } = "Enemy of One";
        [JsonProperty] public string UI_SpellName_HolyLight { get; set; } = "Holy Light";
        [JsonProperty] public string UI_SpellName_NobleSacrifice { get; set; } = "Noble Sacrifice";
        [JsonProperty] public string UI_SpellName_RemoveCurse { get; set; } = "Remove Curse";
        [JsonProperty] public string UI_SpellName_SacredJourney { get; set; } = "Sacred Journey";

        //忍术
        [JsonProperty] public string UI_SpellName_FocusAttack { get; set; } = "Focus Attack";
        [JsonProperty] public string UI_SpellName_DeathStrike { get; set; } = "Death Strike";
        [JsonProperty] public string UI_SpellName_AnimalForm { get; set; } = "Animal Form";
        [JsonProperty] public string UI_SpellName_KiAttack { get; set; } = "Ki Attack";
        [JsonProperty] public string UI_SpellName_SurpriseAttack { get; set; } = "Surprise Attack";
        [JsonProperty] public string UI_SpellName_Backstab { get; set; } = "Backstab";
        [JsonProperty] public string UI_SpellName_Shadowjump { get; set; } = "Shadowjump";
        [JsonProperty] public string UI_SpellName_MirrorImage { get; set; } = "Mirror Image";

        //集成法术
        [JsonProperty] public string UI_SpellName_ArcaneCircle { get; set; } = "Arcane Circle";
        [JsonProperty] public string UI_SpellName_GiftofRenewal { get; set; } = "Gift of Renewal";
        [JsonProperty] public string UI_SpellName_ImmolatingWeapon { get; set; } = "Immolating Weapon";
        [JsonProperty] public string UI_SpellName_AttuneWeapon { get; set; } = "Attune Weapon";
        [JsonProperty] public string UI_SpellName_Thunderstorm { get; set; } = "Thunderstorm";
        [JsonProperty] public string UI_SpellName_NaturesFury { get; set; } = "Nature's Fury";
        [JsonProperty] public string UI_SpellName_SummonFey { get; set; } = "Summon Fey";
        [JsonProperty] public string UI_SpellName_SummonFiend { get; set; } = "Summon Fiend";
        [JsonProperty] public string UI_SpellName_ReaperForm { get; set; } = "Reaper Form";
        [JsonProperty] public string UI_SpellName_Wildfire { get; set; } = "Wildfire";
        [JsonProperty] public string UI_SpellName_EssenceofWind { get; set; } = "Essence of Wind";
        [JsonProperty] public string UI_SpellName_DryadAllure { get; set; } = "Dryad Allure";
        [JsonProperty] public string UI_SpellName_EtherealVoyage { get; set; } = "Ethereal Voyage";
        [JsonProperty] public string UI_SpellName_WordofDeath { get; set; } = "Word of Death";
        [JsonProperty] public string UI_SpellName_GiftofLife { get; set; } = "Gift of Life";
        [JsonProperty] public string UI_SpellName_ArcaneEmpowerment { get; set; } = "Arcane Empowerment";

        //秘术
        [JsonProperty] public string UI_SpellName_NetherBolt { get; set; } = "Nether Bolt";
        [JsonProperty] public string UI_SpellName_HealingStone { get; set; } = "Healing Stone";
        [JsonProperty] public string UI_SpellName_PurgeMagic { get; set; } = "Purge Magic";
        [JsonProperty] public string UI_SpellName_Enchant { get; set; } = "Enchant";
        [JsonProperty] public string UI_SpellName_Sleep { get; set; } = "Sleep";
        [JsonProperty] public string UI_SpellName_EagleStrike { get; set; } = "Eagle Strike";
        [JsonProperty] public string UI_SpellName_AnimatedWeapon { get; set; } = "Animated Weapon";
        [JsonProperty] public string UI_SpellName_StoneForm { get; set; } = "Stone Form";
        [JsonProperty] public string UI_SpellName_SpellTrigger { get; set; } = "Spell Trigger";
        [JsonProperty] public string UI_SpellName_MassSleep { get; set; } = "Mass Sleep";
        [JsonProperty] public string UI_SpellName_CleansingWinds { get; set; } = "Cleansing Winds";
        [JsonProperty] public string UI_SpellName_Bombard { get; set; } = "Bombard";
        [JsonProperty] public string UI_SpellName_SpellPlague { get; set; } = "Spell Plague";
        [JsonProperty] public string UI_SpellName_HailStorm { get; set; } = "Hail Storm";
        [JsonProperty] public string UI_SpellName_NetherCyclone { get; set; } = "Nether Cyclone";
        [JsonProperty] public string UI_SpellName_RisingColossus { get; set; } = "Rising Colossus";

        //武士道
        [JsonProperty] public string UI_SpellName_HonorableExecution { get; set; } = "Honorable Execution";
        [JsonProperty] public string UI_SpellName_Confidence { get; set; } = "Confidence";
        [JsonProperty] public string UI_SpellName_Evasion { get; set; } = "Evasion";
        [JsonProperty] public string UI_SpellName_CounterAttack { get; set; } = "Counter Attack";
        [JsonProperty] public string UI_SpellName_LightningStrike { get; set; } = "Lightning Strike";
        [JsonProperty] public string UI_SpellName_MomentumStrike { get; set; } = "Momentum Strike";

        //诗人法术
        [JsonProperty] public string UI_SpellName_Inspire { get; set; } = "Inspire";
        [JsonProperty] public string UI_SpellName_Invigorate { get; set; } = "Invigorate";
        [JsonProperty] public string UI_SpellName_Resilience { get; set; } = "Resilience";
        [JsonProperty] public string UI_SpellName_Perseverance { get; set; } = "Perseverance";
        [JsonProperty] public string UI_SpellName_Tribulation { get; set; } = "Tribulation";
        [JsonProperty] public string UI_SpellName_Despair { get; set; } = "Despair";



    }
    
}
