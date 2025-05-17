namespace MoraJai.Core.Tiles.Corarica;

public static class Corarica
{
    public static TileType[,] OnClick(Board board, int x, int y)
    {
        var adjacentTiles = board.GetAdjacentTiles(x, y);
        
        var mostCommonTileType = adjacentTiles
            .GroupBy(tile => tile.TileType)
            .OrderByDescending(g => g.Count())
            .First();
            
        if (mostCommonTileType.Count() > adjacentTiles.Count / 2)
        {
            board.SetTile(x, y, mostCommonTileType.Key);
        }
        
        return board.GetBoard();
    }

}