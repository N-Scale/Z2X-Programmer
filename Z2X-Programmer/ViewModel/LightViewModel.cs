﻿/*

Z2X-Programmer
Copyright (C) 2024
PeterK78

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program. If not, see:

https://github.com/PeterK78/Z2X-Programmer?tab=GPL-3.0-1-ov-file.

*/

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2XProgrammer.Converter;
using Z2XProgrammer.DataStore;
using Z2XProgrammer.Helper;
using Z2XProgrammer.Messages;

namespace Z2XProgrammer.ViewModel
{
    public partial class LightViewModel : ObservableObject
    {
        #region REGION: DECODER FEATURES
    
        [ObservableProperty]
        bool zIMO_LIGHT_EFFECTS_CV125X;

        [ObservableProperty]
        bool zIMO_LIGHT_DIM_CV60;

        #endregion

        #region REGION: PUBLIC PROPERTIES

        [ObservableProperty]
        bool anyDecoderFeatureAvailable;

        [ObservableProperty]
        bool dataStoreDataValid;

        [ObservableProperty]
        internal ObservableCollection<string> availableZIMOLightEffects;

        [ObservableProperty]
        internal string selectedZIMOLightEffect0v;
        partial void OnSelectedZIMOLightEffect0vChanged(string value)
        {       
            DecoderConfiguration.ZIMO.LightEffectOutput0v = ZIMOEnumConverter.GetLightEffectType(value);
        }
        
        [ObservableProperty]
        internal string selectedZIMOLightEffect0r;
        partial void OnSelectedZIMOLightEffect0rChanged(string value)
        {
            DecoderConfiguration.ZIMO.LightEffectOutput0r = ZIMOEnumConverter.GetLightEffectType(value);
        }


        [ObservableProperty]
        bool dimmingEnabled;
        partial void OnDimmingEnabledChanged(bool value)
        {
            if(value == false)
            {
                DecoderConfiguration.ZIMO.DimmingFunctionOutputMasterValue = 0;
            }
            else
            {
                DecoderConfiguration.ZIMO.DimmingFunctionOutputMasterValue = DecoderConfiguration.ZIMOBackup.DimmingFunctionOutputMasterValue;
            }
        }

        [ObservableProperty]
        bool dimmingOutput0frontEnabled;
        partial void OnDimmingOutput0frontEnabledChanged(bool value)
        {
            byte temp = DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled;
            temp = Bit.Set(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 0, !value);
            DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled = temp;
        }


        [ObservableProperty]
        bool dimmingOutput0rearEnabled;
        partial void OnDimmingOutput0rearEnabledChanged(bool value)
        {
            byte temp = DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled;
            temp = Bit.Set(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 1, !value);
            DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled = temp;
        }

        [ObservableProperty]
        bool dimmingOutput1Enabled;
        partial void OnDimmingOutput1EnabledChanged(bool value)
        {
            byte temp = DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled;
            temp = Bit.Set(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 2, !value);
            DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled = temp;
        }

        [ObservableProperty]
        bool dimmingOutput2Enabled;
        partial void OnDimmingOutput2EnabledChanged(bool value)
        {
            byte temp = DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled;
            temp = Bit.Set(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 3, !value);
            DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled = temp;
        }

        [ObservableProperty]
        bool dimmingOutput3Enabled;
        partial void OnDimmingOutput3EnabledChanged(bool value)
        {
            byte temp = DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled;
            temp = Bit.Set(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 4, !value);
            DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled = temp;
        }

        [ObservableProperty]
        bool dimmingOutput4Enabled;
        partial void OnDimmingOutput4EnabledChanged(bool value)
        {
            byte temp = DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled;
            temp = Bit.Set(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 5, !value);
            DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled = temp;
        }

        [ObservableProperty]
        bool dimmingOutput5Enabled;
        partial void OnDimmingOutput5EnabledChanged(bool value)
        {
            byte temp = DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled;
            temp = Bit.Set(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 6, !value);
            DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled = temp;
        }

        [ObservableProperty]
        bool dimmingOutput6Enabled;
        partial void OnDimmingOutput6EnabledChanged(bool value)
        {
            byte temp = DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled;
            temp = Bit.Set(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 7, !value);
            DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled = temp;
        }

        [ObservableProperty]
        bool dimmingOutput7Enabled;
        partial void OnDimmingOutput7EnabledChanged(bool value)
        {
            byte temp = DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled;
            temp = Bit.Set(DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled, 0, !value);
            DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled = temp;
        }

        [ObservableProperty]
        bool dimmingOutput8Enabled;
        partial void OnDimmingOutput8EnabledChanged(bool value)
        {
            byte temp = DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled;
            temp = Bit.Set(DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled, 1, !value);
            DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled = temp;
        }

        [ObservableProperty]
        bool dimmingOutput9Enabled;
        partial void OnDimmingOutput9EnabledChanged(bool value)
        {
            byte temp = DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled;
            temp = Bit.Set(DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled, 2, !value);
            DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled = temp;
        }

        [ObservableProperty]
        bool dimmingOutput10Enabled;
        partial void OnDimmingOutput10EnabledChanged(bool value)
        {
            byte temp = DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled;
            temp = Bit.Set(DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled, 3, !value);
            DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled = temp;
        }

        [ObservableProperty]
        bool dimmingOutput11Enabled;
        partial void OnDimmingOutput11EnabledChanged(bool value)
        {
            byte temp = DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled;
            temp = Bit.Set(DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled, 4, !value);
            DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled = temp;
        }

        [ObservableProperty]
        bool dimmingOutput12Enabled;
        partial void OnDimmingOutput12EnabledChanged(bool value)
        {
            byte temp = DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled;
            temp = Bit.Set(DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled, 5, !value);
            DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled = temp;
        }


        [ObservableProperty]
        byte brightness;
        partial void OnBrightnessChanged(byte value)
        {
            DecoderConfiguration.ZIMO.DimmingFunctionOutputMasterValue = value;
            BrightnessLabelText = GetBrightnessLabelText();
        }

        [ObservableProperty]
        string brightnessLabelText = "";

        #endregion

        #region REGION: CONSTRUCTOR
        public LightViewModel()
        {

            AvailableZIMOLightEffects = new ObservableCollection<string>();
            SelectedZIMOLightEffect0v = string.Empty;
            SelectedZIMOLightEffect0r = string.Empty;

            OnGetDecoderConfiguration();
            OnGetDataFromDecoderSpecification();

            WeakReferenceMessenger.Default.Register<DecoderConfigurationUpdateMessage>(this, (r, m) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    OnGetDecoderConfiguration();
                });
            });

            WeakReferenceMessenger.Default.Register<DecoderSpecificationUpdatedMessage>(this, (r, m) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    OnGetDataFromDecoderSpecification();
                });
            });

        }
        #endregion

        #region REGION: PRIVATE FUNCTIONS

        /// <summary>
        /// Converts the current brightness value of CV60 to a label text (value + percentage).
        /// </summary>
        /// <returns></returns>
        private string GetBrightnessLabelText()
        {
        
            float percentage = ((float)100 / (float)255) * (float)Brightness;
            return Brightness.ToString() + " (" + string.Format("{0:N0}", percentage) + " %)";
        }

        /// <summary>
        /// The OnGetDecoderConfiguration message handler is called when the DecoderConfigurationUpdateMessage message has been received.
        /// OnGetDecoderConfiguration updates the local variables with the new decoder configuration.
        /// </summary>
        private void OnGetDecoderConfiguration()
        {
            DataStoreDataValid = DecoderConfiguration.IsValid;
            DimmingEnabled = DecoderConfiguration.ZIMO.DimmingFunctionOutputMasterValue == 0 ? false : true;
            Brightness = DecoderConfiguration.ZIMO.DimmingFunctionOutputMasterValue;
            BrightnessLabelText = GetBrightnessLabelText();
            DimmingOutput0frontEnabled = !Bit.IsSet(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 0);
            DimmingOutput0rearEnabled = !Bit.IsSet(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 1);
            DimmingOutput1Enabled = !Bit.IsSet(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 2);
            DimmingOutput2Enabled = !Bit.IsSet(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 3);
            DimmingOutput3Enabled = !Bit.IsSet(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 4);
            DimmingOutput4Enabled = !Bit.IsSet(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 5);
            DimmingOutput5Enabled = !Bit.IsSet(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 6);
            DimmingOutput6Enabled = !Bit.IsSet(DecoderConfiguration.ZIMO.DimmingFunctionFA0FA06OutputsEnabled, 7);
            DimmingOutput7Enabled = !Bit.IsSet(DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled, 0);
            DimmingOutput8Enabled = !Bit.IsSet(DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled, 1);
            DimmingOutput9Enabled = !Bit.IsSet(DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled, 2);
            DimmingOutput10Enabled = !Bit.IsSet(DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled, 3);
            DimmingOutput11Enabled = !Bit.IsSet(DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled, 4);
            DimmingOutput12Enabled = !Bit.IsSet(DecoderConfiguration.ZIMO.DimmingFunctionFA7FA12OutputsEnabled, 5);
            AvailableZIMOLightEffects = new ObservableCollection<String>(ZIMOEnumConverter.GetAvailableLightEffects());
            SelectedZIMOLightEffect0v = ZIMOEnumConverter.GetLightEffectDescription(DecoderConfiguration.ZIMO.LightEffectOutput0v);
            SelectedZIMOLightEffect0r = ZIMOEnumConverter.GetLightEffectDescription(DecoderConfiguration.ZIMO.LightEffectOutput0r);
        }

        /// <summary>
        /// The OnGetDataFromDecoderSpecification message handler is called when the DecoderSpecificationUpdatedMessage message has been received.
        /// OnGetDataFromDecoderSpecification updates the local variables with the new decoder specification.
        /// </summary>
        private void OnGetDataFromDecoderSpecification()
        {
            ZIMO_LIGHT_DIM_CV60 = DecoderSpecification.ZIMO_LIGHT_DIM_CV60;
            ZIMO_LIGHT_EFFECTS_CV125X = DecoderSpecification.ZIMO_LIGHT_EFFECTS_CV125X;

            if ((ZIMO_LIGHT_DIM_CV60 == true) ||
                             (ZIMO_LIGHT_EFFECTS_CV125X == true))
            {
                AnyDecoderFeatureAvailable = true;
            }
            else
            {
                AnyDecoderFeatureAvailable = false;
            }
        }

        #endregion
    }
}
