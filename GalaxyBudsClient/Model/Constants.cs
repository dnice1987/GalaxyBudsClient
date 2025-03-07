﻿using System;
using System.ComponentModel;
using GalaxyBudsClient.Model.Attributes;
using GalaxyBudsClient.Platform;
using Serilog;

namespace GalaxyBudsClient.Model
{
    namespace Constants
    {
        public static class Uuids
        {
            public static readonly Guid Buds = new Guid("{00001102-0000-1000-8000-00805f9b34fd}");
            public static readonly Guid BudsPlus = new Guid("{00001101-0000-1000-8000-00805F9B34FB}");
            public static readonly Guid BudsLive = new Guid("{00001101-0000-1000-8000-00805F9B34FB}");
            public static readonly Guid BudsPro = new Guid("{00001101-0000-1000-8000-00805F9B34FB}");
            public static readonly Guid Buds2 = new Guid("{2e73a4ad-332d-41fc-90e2-16bef06523f2}");
            public static readonly Guid Buds2Pro = new Guid("{2e73a4ad-332d-41fc-90e2-16bef06523f2}");
            public static readonly Guid BudsFe = new Guid("{2e73a4ad-332d-41fc-90e2-16bef06523f2}");
        }
        public static class Bixby
        {
            public static (byte, string)[] Languages =
            {
                (0, "de-DE"),
                (1, "en-GB"),
                (2, "en-US"),
                (3, "es-ES"),
                (4, "fr-FR"),
                (5, "it-IT"),
                (6, "ko-KR"),
                (7, "pt-BR"),
                (8, "zh-CN"),
                (9, "hu-HU"),
            };
        }
        
        public enum Locales
        {
            [Description("English")]
            en,
            [Description("German")]
            de,
            [Description("Spanish")]
            es,
            [Description("Portuguese")]
            pt,
            [Description("Italian")]
            it,
            [Description("Korean")]
            ko,
            [Description("Japanese")]
            ja,
            [Description("Russian")]
            ru,
            [Description("Ukrainian")]
            ua,
            [Description("Czech")]
            cz,
            [Description("Turkish")]
            tr,
            [Description("Simplified-Chinese")]
            cn,
            [Description("Traditional-Chinese")]
            tw,
            [Description("Indonesian")]
            in_,
            [Description("Vietnamese")]
            vn_,
            [Description("Greek")]
            gr,
            [Description("Romanian")]
            ro,
            [Description("Hebrew")]
            il,
            [Description("French")]
            fr,
            [Description("Magyar")]
            hu,
			[Description("Nederlands")]
			nl,
            [Description("custom_language.xaml")]
            custom
        }
        
        public enum SpatialAudioControl
        {
            Attach = 0,
            Detach = 1,
            AttachSuccess = 2,
            DetachSuccess = 3,
            KeepAlive = 4,
            WearOnOff = 5
        }
        
        public enum SpatialAudioData
        {
            Unknown,
            BudGrv = 32,
            BudGyrocal = 35,
            BudSensorStuck = 36,
            WearOff = 34,
            WearOn = 33
        }
        
        public enum TemperatureUnits
        {
            Fahrenheit,
            Celsius
        }
        
        public enum DarkModes
        {
            [LocalizedDescription("darkmode_disabled")]
            Light,
            [LocalizedDescription("darkmode_enabled")]
            Dark
        }

        public enum PopupPlacement
        {
            [LocalizedDescription("connpopup_placement_tl")]
            TopLeft,
            [LocalizedDescription("connpopup_placement_tc")]
            TopCenter,
            [LocalizedDescription("connpopup_placement_tr")]
            TopRight,
            [LocalizedDescription("connpopup_placement_bl")]
            BottomLeft,
            [LocalizedDescription("connpopup_placement_bc")]
            BottomCenter,
            [LocalizedDescription("connpopup_placement_br")]
            BottomRight,
        }

        public enum Models
        {
            NULL = 0,
            [ModelMetadata(Name = "Galaxy Buds", FwPattern = "R170", BuildPrefix = "R170")]
            Buds = 1,
            [ModelMetadata(Name = "Galaxy Buds+", FwPattern = "SM-R175", BuildPrefix = "R175")]
            BudsPlus = 2,
            [ModelMetadata(Name = "Galaxy Buds Live", FwPattern = "SM-R180", BuildPrefix = "R180")]
            BudsLive = 3,
            [ModelMetadata(Name = "Galaxy Buds Pro", FwPattern = "SM-R190", BuildPrefix = "R190")]
            BudsPro = 4,
            [ModelMetadata(Name = "Galaxy Buds2", FwPattern = "SM-R177", BuildPrefix = "R177")]
            Buds2 = 5,
            [ModelMetadata(Name = "Galaxy Buds2 Pro", FwPattern = "SM-R510", BuildPrefix = "R510")]
            Buds2Pro = 6,
            [ModelMetadata(Name = "Galaxy Buds FE", FwPattern = "SM-R400N", BuildPrefix = "R400N")]
            BudsFe = 7
        }

        public enum Color
        {
            Blue = 258,
            Pink = 259,
            Black = 260,
            White = 261,
            Thom_Brown = 262,
            Red = 263,
            Deep_Blue = 264,
            Olympic = 265,
            Purple = 266
        }

        public enum PlacementStates
        {
            [LocalizedDescription("placement_disconnected")]
            Disconnected = 0,
            [LocalizedDescription("placement_wearing")]
            Wearing = 1,
            [LocalizedDescription("placement_not_wearing")]
            Idle = 2,
            [LocalizedDescription("placement_in_case")]
            Case = 3,
            ClosedCase = 4
        }

        public enum WearStates
        {
            None = 0,
            R = 1,
            L = 16,
            Both = 17
        }
        public enum DeviceInv
        {
            L = 1,
            R = 0
        }
        public enum Devices
        {
            L = 0,
            R = 1
        }
        public enum SppRoleStates
        {
            Done = 0,
            Changing = 1,
            Unknown = 2
        }
        
        public enum NoiseControlMode
        {
            Off = 0,
            AmbientSound = 2,
            NoiseReduction = 1
        }
        
        public enum TouchOptions
        {
            [LocalizedDescription("touchoption_voice")]
            VoiceAssistant,
            [LocalizedDescription("touchoption_quickambientsound")]
            QuickAmbientSound,
            [LocalizedDescription("touchoption_volume")]
            Volume,
            [LocalizedDescription("touchoption_ambientsound")]
            AmbientSound,
            [LocalizedDescription("anc")]
            Anc,
            [LocalizedDescription("touchoption_switch_noisecontrols")]
            NoiseControl,
            [LocalizedDescription("touchoption_spotify")]
            SpotifySpotOn,
            [Hidden]
            OtherL,
            [Hidden]
            OtherR
        }
        
        public enum ClientDeviceType
        {
            Samsung = 1,
            Other = 2
        }
        public enum EqPreset
        {
            BassBoost = 0,
            Soft = 1,
            Dynamic = 2,
            Clear = 3,
            TrebleBoost = 4
        }
        public enum AmbientType
        {
            Default = 0,
            VoiceFocus = 1
        }
        
        public enum DynamicTrayIconModes
        {
            [LocalizedDescription("settings_dyn_tray_mode_off")]
            Disabled = 0,
            [LocalizedDescription("settings_dyn_tray_mode_battery_min")]
            BatteryMin = 1,
            [LocalizedDescription("settings_dyn_tray_mode_battery_avg")]
            BatteryAvg = 2
        }
    }
}
