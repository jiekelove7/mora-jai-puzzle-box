// MoraJai/MoraJai.Desktop/ViewModels/BoardViewModel.cs
using System.Collections.ObjectModel;
using MoraJai.Core;
using ReactiveUI;

namespace MoraJai.ViewModels;

public class BoardViewModel : ViewModelBase
{
    private ObservableCollection<TileViewModel> _tiles;
    public ObservableCollection<TileViewModel> Tiles
    {
        get => _tiles;
        set => this.RaiseAndSetIfChanged(ref _tiles, value);
    }

    public BoardViewModel()
    {
        // Design-time constructor
        var board = new Board(3); // This creates a 3x3 grid
        InitializeBoard(board);
    }

    public BoardViewModel(Board board)
    {
        InitializeBoard(board);
    }

    private void InitializeBoard(Board board)
    {
        Tiles = new ObservableCollection<TileViewModel>();

        for (var row = 0; row < board.GetSize(); row++)
        {
            for (var col = 0; col < board.GetSize(); col++)
            {
                var tile = new TileViewModel(board, row, col);
                Tiles.Add(tile);
            }
        }
    }
}