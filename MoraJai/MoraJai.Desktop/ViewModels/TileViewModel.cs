using System.Reactive;
using MoraJai.Core;
using MoraJai.Core.Tiles;
using ReactiveUI;

namespace MoraJai.ViewModels;

public class TileViewModel : ViewModelBase
{
    private readonly Board _board;
    private readonly int _row;
    private readonly int _col;
    private TileType _tileType;
    
    public ReactiveCommand<Unit, Unit> ClickCommand { get; }
    
    public TileType TileType
    {
        get => _tileType;
        private set => this.RaiseAndSetIfChanged(ref _tileType, value);
    }

    public TileViewModel(Board board, int row, int col)
    {
        _board = board;
        _row = row;
        _col = col;
        _tileType = board.GetTile(row, col).TileType;

        ClickCommand = ReactiveCommand.Create(() =>
        {
            var nextBoard = _board.OnTileClick(_row, _col);
            RefreshTileType();
        });
    }

    public void RefreshTileType()
    {
        TileType = _board.GetTile(_row, _col).TileType;
    }
}