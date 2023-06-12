using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FonctionUtil
{
    public static class MyRegistryParam
    {
        private static readonly string RegistryKeyPath = "SOFTWARE\\HEPL\\PingView";
        public static int PositionX
        {
            get => GetValueOrDefault();
            set => SetValue(value);
        }

        public static int PositionY
        {
            get => GetValueOrDefault();
            set => SetValue(value);
        }

        public static int DimensionX
        {
            get => GetValueOrDefault();
            set => SetValue(value);
        }

        public static int DimensionY
        {
            get => GetValueOrDefault();
            set => SetValue(value);
        }

        private static int GetValueOrDefault([CallerMemberName] string propertyName = "")
        {
            using (var registryKey = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                if (registryKey != null)
                {
                    var value = registryKey.GetValue(propertyName);
                    if (value != null && int.TryParse(value.ToString(), out int propertyValue))
                    {
                        return propertyValue;
                    }
                }
            }

            return -1; // Valeur par défaut si la clé ou la valeur n'existent pas
        }

        private static void SetValue(int value, [CallerMemberName] string propertyName = "")
        {
            using (var registryKey = Registry.CurrentUser.CreateSubKey(RegistryKeyPath))
            {
                if (registryKey != null)
                {
                    registryKey.SetValue(propertyName, value);
                }
            }
        }
    }
}
