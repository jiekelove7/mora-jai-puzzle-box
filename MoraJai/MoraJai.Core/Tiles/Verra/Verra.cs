namespace MoraJai.Core.Tiles.Verra;

public static class Verra
{
    public static TileType[,] OnClick(Board board, int x, int y)
    {
        var surroundingTiles = board.GetSurroundingTiles(x, y);
        surroundingTiles.Reverse();
        var firstTileType = surroundingTiles.First().TileType;
        for (var i = 0; i < surroundingTiles.Count - 1; i++)
        {
            var currentTile = surroundingTiles[i];
            var nextTile = surroundingTiles[i + 1];
            board.SetTile(currentTile.X, currentTile.Y, nextTile.TileType);
        }
        var lastTile = surroundingTiles.Last();
        board.SetTile(lastTile.X, lastTile.Y, firstTileType);
        return board.GetBoard();
    }

}