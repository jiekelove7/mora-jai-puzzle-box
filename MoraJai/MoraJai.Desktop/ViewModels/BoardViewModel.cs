using System.Collections.ObjectModel;
using MoraJai.Core;
using ReactiveUI;

namespace MoraJai.ViewModels;

public class BoardViewModel : ViewModelBase
{
    private ObservableCollection<ObservableCollection<TileViewModel>> _tiles;
    public ObservableCollection<ObservableCollection<TileViewModel>> Tiles
    {
        get => _tiles;
        set => this.RaiseAndSetIfChanged(ref _tiles, value);
    }

    public BoardViewModel()
    {
        // Design-time constructor
        var board = new Board(3);
        InitializeBoard(board);
    }

    public BoardViewModel(Board board)
    {
        InitializeBoard(board);
    }

    private void InitializeBoard(Board board)
    {
        Tiles = new ObservableCollection<ObservableCollection<TileViewModel>>();

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
                tile.RefreshTileType();
            }
        }
    }
}