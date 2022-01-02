using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_6_Wpf_Home_1
{
    class WeatherControl:DependencyObject
    {
        public static readonly DependencyProperty TemperaturaProperty;
        private string windDirection;
        private enum Precipition
        {
            Sunny,
            Cloudy,
            Rain,
            Snow
        }
        public int Temperatura
        {
            get=>(int)(GetValue(TemperaturaProperty));
            set => SetValue(TemperaturaProperty, value);
        }
        static WeatherControl()
        {
            TemperaturaProperty = DependencyProperty.Register(
                nameof(Temperatura),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            int t = (int)value;
            if (t>=-50 && t <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -50)
                return t;
            else
                return null;
        }
    }
}
