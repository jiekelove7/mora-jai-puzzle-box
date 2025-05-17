namespace MoraJai.Core.Tiles.BluePrince;

public static class BluePrince
{
    public static TileType[,] OnClick(Board board, int x, int y)
    {
        var size = board.GetSize();
        if (size % 2 == 0)
        {
            return board.GetBoard(); // blue tile doesn't work on even boards
        }
        var centerCoord = (size - 1) / 2;
        var centerTile = board.GetTile(centerCoord, centerCoord).TileType;
        
        return board.GetBoard();
    }
}