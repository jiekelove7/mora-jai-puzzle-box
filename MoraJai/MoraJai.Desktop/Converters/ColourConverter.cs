using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;
using MoraJai.Core.Tiles;

namespace MoraJai.Converters;

public class ColourConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is TileType tileType)
        {
            return tileType switch
            {
                TileType.None => new SolidColorBrush(Colors.Gray),
                TileType.MoraJai => new SolidColorBrush(Colors.Blue),
                TileType.OrindaAries => new SolidColorBrush(Colors.Green),
                TileType.FennAries => new SolidColorBrush(Colors.Red),
                TileType.Nuance => new SolidColorBrush(Colors.Purple),
                TileType.Corarica => new SolidColorBrush(Colors.Orange),
                TileType.Verra => new SolidColorBrush(Colors.Yellow),
                TileType.ArchAries => new SolidColorBrush(Colors.Cyan),
                TileType.Eraja => new SolidColorBrush(Colors.Magenta),
                _ => new SolidColorBrush(Colors.DarkGray)
            };
        }
        return new SolidColorBrush(Colors.DarkGray);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}