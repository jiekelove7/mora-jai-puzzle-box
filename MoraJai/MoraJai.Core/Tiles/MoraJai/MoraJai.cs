namespace MoraJai.Core.Tiles.MoraJai;

public static class MoraJai
{
    public static TileType[,] OnClick(Board board, int x, int y, TileType selfType = TileType.MoraJai)
    {
        var adjacentTiles = board.GetAdjacentTiles(x, y);
        adjacentTiles.Add(board.GetTile(x, y));
        
        foreach (var tile in adjacentTiles)
        {
            switch (tile.TileType)
            {
                case TileType.None:
                    board.SetTile(tile.X, tile.Y, selfType);
                    break;
                case TileType.MoraJai:
                    board.SetTile(tile.X, tile.Y, TileType.None);
                    break;
                default:
                    break;
            }
        }
        return board.GetBoard();
    }
}