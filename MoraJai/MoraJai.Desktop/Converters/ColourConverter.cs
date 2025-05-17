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
                TileType.None => new SolidColorBrush(Colors.LightSlateGray),
                TileType.MoraJai => new SolidColorBrush(Colors.White),
                TileType.OrindaAries => new SolidColorBrush(Colors.Black),
                TileType.FennAries => new SolidColorBrush(Colors.Red),
                TileType.Nuance => new SolidColorBrush(Colors.Green),
                TileType.Corarica => new SolidColorBrush(Colors.Orange),
                TileType.Verra => new SolidColorBrush(Colors.Pink),
                TileType.ArchAries => new SolidColorBrush(Colors.Yellow),
                TileType.Eraja => new SolidColorBrush(Colors.Purple),
                TileType.BluePrince => new SolidColorBrush(Colors.CornflowerBlue),
                _ => new SolidColorBrush(Colors.Gray)
            };
        }
        return new SolidColorBrush(Colors.DarkGray);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}