namespace MoraJai.Core;

public static class ArrayConverter
{
    public static Tiles.TileType[][] ToJagged(Tiles.TileType[,] grid)
    {
        var rows = grid.GetLength(0);
        var cols = grid.GetLength(1);
        var jagged = new Tiles.TileType[rows][];
        for (var i = 0; i < rows; i++)
        {
            jagged[i] = new Tiles.TileType[cols];
            for (var j = 0; j < cols; j++)
            {
                jagged[i][j] = grid[i, j];
            }
        }
        return jagged;
    }

    public static Tiles.TileType[,] To2D(Tiles.TileType[][] jagged)
    {
        var rows = jagged.Length;
        var cols = jagged[0].Length;
        var grid = new Tiles.TileType[rows, cols];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                grid[i, j] = jagged[i][j];
            }
        }
        return grid;
    }
}