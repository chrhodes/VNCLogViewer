﻿using System;
using System.Windows.Data;
using System.Windows.Media;

namespace VNCLogViewer.Presentation.Converters
{
    [ValueConversion(typeof(System.Drawing.Color), typeof(SolidColorBrush))]
    public class SystemColorToSolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            System.Drawing.Color color = (System.Drawing.Color)value;
            System.Windows.Media.Color converted = Color.FromArgb(color.A, color.R, color.G, color.B);
            return new SolidColorBrush(converted);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static System.Drawing.Color RGBToColor(string rgb)
        {
            //Trim to RRGGBB
            if (rgb.Length > 6)
            {
                rgb = rgb.Substring(rgb.Length - 6);
            }

            if (rgb.Length != 6)
                throw new ArgumentException("Invalid rgb value given");

            int red = 0;
            int green = 0;
            int blue = 0;

            red = System.Convert.ToInt32(rgb.Substring(0, 2), 16);
            green = System.Convert.ToInt32(rgb.Substring(2, 2), 16);
            blue = System.Convert.ToInt32(rgb.Substring(4, 2), 16);

            return System.Drawing.Color.FromArgb(red, green, blue);
        }

        public static string ColorToRGB(System.Drawing.Color color)
        {
            string red = color.R.ToString("X2");
            string green = color.G.ToString("X2");
            string blue = color.B.ToString("X2");
            return String.Format("{0}{1}{2}", red, green, blue);
        }

        public static System.Windows.Media.Color ColorToColor(System.Drawing.Color color)
        {
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static System.Drawing.Color ColorToColor(System.Windows.Media.Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}