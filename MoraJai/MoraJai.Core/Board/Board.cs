using MoraJai.Core.Tiles;
using MoraJai.Core.Tiles.FennAries;
using MoraJaiTile = MoraJai.Core.Tiles.MoraJai.MoraJai;
using MoraJai.Core.Tiles.OrindaAries;

namespace MoraJai.Core;

public class Board
{
    private TileType[,] _board;

    public Board(int size, TileType[,] initialBoard = null)
    {
        _board = new TileType[size, size];
        
        _board[0, 0] = TileType.MoraJai; // [ 0, 0]
        _board[0, 1] = TileType.None; // [ 0, 1]
        _board[1, 0] = TileType.None; // [ 0, 2]
        _board[0, 2] = TileType.OrindaAries; // [ 0, 3]
        _board[1, 2] = TileType.OrindaAries; // [ 0, 3]
        _board[2, 2] = TileType.OrindaAries; // [ 0, 3]
        _board[1, 1] = TileType.FennAries; // [ 0, 4]

        if (initialBoard != null)
        {
            _board = initialBoard;
        }
    }
    
    public TileType[,] GetBoard() => _board;
    
    public int GetSize() => _board.GetLength(0);

    public bool IsInBound(int x, int y) =>
        x >= 0 && y >= 0 && x < GetSize() && y < GetSize();

    public TileCoordAndType GetTile(int x, int y)
    {
        return IsInBound(x, y) ? new TileCoordAndType
        {
            TileType = _board[x, y],
            X = x,
            Y = y
        } : null;
    }

    public TileCoordAndType GetNorth(int x, int y)
    {
        return GetTile(x, y + 1);
    }
    
    public TileCoordAndType GetEast(int x, int y)
    {
        return GetTile(x + 1, y);
    }
    
    public TileCoordAndType GetSouth(int x, int y)
    {
        return GetTile(x, y - 1);
    }
    
    public TileCoordAndType GetWest(int x, int y)
    {
        return GetTile(x - 1, y);
    }

    public List<TileCoordAndType> GetAdjacentTiles(int x, int y)
    {
        // Clockwise starting north
        List<TileCoordAndType> adjacentTiles = [];
        var north = GetNorth(x, y);
        if (north != null)
        {
            adjacentTiles.Add(GetNorth(x, y));
        }
        var east = GetEast(x, y);
        if (east != null)
        {
            adjacentTiles.Add(GetEast(x, y));
        }
        var south = GetSouth(x, y);
        if (south != null)
        {
            adjacentTiles.Add(GetSouth(x, y));
        }
        var west = GetWest(x, y);
        if (west != null)
        {
            adjacentTiles.Add(GetWest(x, y));
        }
        return adjacentTiles;
    }

    public void SetTile(int x, int y, TileType tile)
    {
        if (!IsInBound(x, y))
        {
            return;
        }

        _board[x, y] = tile;
    }

    public void SetTile(TileCoordAndType target, TileType tile)  =>
        SetTile(target.X, target.Y, tile);
        

    public TileType[,] OnTileClick(int x, int y)
    {
        if (!IsInBound(x, y))
        {
            return _board;
        }

        var newBoard = _board[x, y] switch
        {
            TileType.None => _board,
            TileType.MoraJai => MoraJaiTile.OnClick(this, x, y),
            TileType.OrindaAries => OrindaAries.OnClick(this, x, y),
            TileType.FennAries => FennAries.OnClick(this, x, y),
            _ => _board
        };

        return newBoard;
    }
}