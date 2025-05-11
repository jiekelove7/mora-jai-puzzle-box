using System.ComponentModel;
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
    
    public ReactiveCommand<Unit, Unit> ClickCommand { get; }
    
    public TileType TileType => _board.GetTile(_row, _col).TileType;

    public TileViewModel(Board board, int row, int col)
    {
        _board = board;
        _row = row;
        _col = col;

        ClickCommand = ReactiveCommand.Create(() =>
        {
            var nextBoard = _board.OnTileClick(_row, _col);
        });
    }

    /*public void Refresh()
    {
        RaisePropertyChanged(nameof(TileType));
    }*/
}