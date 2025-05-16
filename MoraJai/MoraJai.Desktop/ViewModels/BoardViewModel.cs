using System.Collections.Generic;
using MoraJai.Core;
using ReactiveUI;

namespace MoraJai.ViewModels
{
    public class BoardViewModel : ViewModelBase
    {
        private readonly Board _board;
        public IList<TileViewModel> Tiles { get; }

        public BoardViewModel(Board board)
        {
            _board = board;
            var size = board.GetSize();
            Tiles = new List<TileViewModel>(size);
            for (var row = 0; row < size; row++)
            {
                for (var col = 0; col < size; col++)
                {
                    Tiles.Add(new TileViewModel(this, _board, row, col));
                }
            }
        }

        public void RefreshAllTiles()
        {
            foreach (var tile in Tiles)
            {
                tile.RefreshTileType();
            }
        }

        public void OnTileClicked(int row, int col)
        {
            _board.OnTileClick(row, col);
            RefreshAllTiles();
        }
    }
}