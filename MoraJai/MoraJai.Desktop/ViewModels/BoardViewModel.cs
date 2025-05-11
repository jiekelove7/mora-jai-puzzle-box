using System.Collections.ObjectModel;
using MoraJai.Core;

namespace MoraJai.ViewModels;

public class BoardViewModel : ViewModelBase
{
    public ObservableCollection<ObservableCollection<TileViewModel>> Tiles { get; }

    public BoardViewModel(Board board)
    {
        Tiles = [];

        for (var row = 0; row < board.GetSize(); row++)
        {
            var rowTiles = new ObservableCollection<TileViewModel>();
            for (var col = 0; col < board.GetSize(); col++)
            {
                var tile = new TileViewModel(board, row, col);
                rowTiles.Add(tile);
            }
            Tiles.Add(rowTiles);
        }
    }

    public void RefreshAllTiles()
    {
        foreach (var row in Tiles)
        {
            foreach (var tile in row)
            {
                /*tile.Refresh();*/
            }
        }
    }
}