namespace MoraJai.Core.Tiles.OrindaAries;

public static class OrindaAries
{
    public static TileType[,] OnClick(Board board, int x, int y)
    {
        var firstElementType = board.GetTile(x, 0).TileType;
        for (var i = 0; i < board.GetSize() - 1; i++)
        {
            board.SetTile(x, i, board.GetTile(x, i + 1).TileType);
        }
        board.SetTile(x, board.GetSize() - 1, firstElementType);
        return board.GetBoard();
    }
}