namespace MoraJai.Core.Tiles.ArchAries;

public static class ArchAries
{
    public static TileType[,] OnClick(Board board, int x, int y)
    {
        if (x == 0)
        {
            return board.GetBoard();
        }
        
        var northType = board.GetTile(x - 1, y).TileType;
        board.SetTile(x - 1, y, board.GetTile(x, y).TileType);
        board.SetTile(x, y, northType);
        return board.GetBoard();
    }
}