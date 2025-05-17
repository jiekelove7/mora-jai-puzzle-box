namespace MoraJai.Core.Tiles.Nuance;

public static class Nuance
{
    public static TileType[,] OnClick(Board board, int x, int y)
    {
        var half = board.GetSize() / 2;
        var mirroredX = half - x + half;
        var mirroredY = half - y + half;
        var currentTileType = board.GetTile(x, y).TileType;
        board.SetTile(x, y, board.GetTile(mirroredX, mirroredY).TileType);
        board.SetTile(mirroredX, mirroredY, currentTileType);
        return board.GetBoard();
    }

}