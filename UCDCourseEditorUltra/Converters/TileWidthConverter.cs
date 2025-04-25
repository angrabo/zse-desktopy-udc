using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace UCDCourseEditorUltra.Converters;

public class TileWidthConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double width)
        {
            int tilesPerRow = Math.Max(1, (int)(width / 320)); // 320px target width with margin
            double tileWidth = (width / tilesPerRow) - 20;     // Subtract margin
            
            // Constrain between min and max widths
            return Math.Min(500, Math.Max(280, tileWidth));
        }
        return 320;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}