namespace MoraJai.Core.Tiles.Eraja;

public static class Eraja
{
    public static TileType[,] OnClick(Board board, int x, int y)
    {
        if (x >= board.GetSize() - 1)
        {
            return board.GetBoard();
        }
        
        var southType = board.GetTile(x + 1, y).TileType;
        board.SetTile(x + 1, y, board.GetTile(x, y).TileType);
        board.SetTile(x, y, southType);
        return board.GetBoard();
    }
}