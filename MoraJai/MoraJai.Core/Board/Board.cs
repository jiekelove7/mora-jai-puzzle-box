using MoraJai.Core.Tiles;
using MoraJai.Core.Tiles.ArchAries;
using MoraJai.Core.Tiles.Corarica;
using MoraJai.Core.Tiles.Eraja;
using MoraJai.Core.Tiles.FennAries;
using MoraJai.Core.Tiles.Nuance;
using MoraJaiTile = MoraJai.Core.Tiles.MoraJai.MoraJai;
using MoraJai.Core.Tiles.OrindaAries;
using MoraJai.Core.Tiles.Verra;

namespace MoraJai.Core;

public class Board
{
    private TileType[,] _board;

    public Board(int size, TileType[,] initialBoard = null)
    {
        _board = new TileType[size, size];
        
        _board[0, 0] = TileType.MoraJai;
        _board[0, 1] = TileType.Nuance;
        _board[0, 2] = TileType.Eraja;
        _board[1, 0] = TileType.Corarica;
        _board[1, 1] = TileType.Verra;
        _board[1, 2] = TileType.OrindaAries;
        _board[2, 0] = TileType.MoraJai;
        _board[2, 1] = TileType.BluePrince;
        _board[2, 2] = TileType.ArchAries;

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
    
    public TileCoordAndType GetNorthEast(int x, int y)
    {
        return GetTile(x + 1, y + 1);
    }
    
    public TileCoordAndType GetEast(int x, int y)
    {
        return GetTile(x + 1, y);
    }
    
    public TileCoordAndType GetSouthEast(int x, int y)
    {
        return GetTile(x + 1, y - 1);
    }
    
    public TileCoordAndType GetSouth(int x, int y)
    {
        return GetTile(x, y - 1);
    }
    
    public TileCoordAndType GetSouthWest(int x, int y)
    {
        return GetTile(x - 1, y - 1);
    }
    
    public TileCoordAndType GetWest(int x, int y)
    {
        return GetTile(x - 1, y);
    }
    
    public TileCoordAndType GetNorthWest(int x, int y)
    {
        return GetTile(x - 1, y + 1);
    }

    public List<TileCoordAndType> GetSurroundingTiles(int x, int y)
    {
        // Clockwise starting north
        List<TileCoordAndType> surroundingTiles = [];
        var north = GetNorth(x, y);
        if (north != null)
        {
            surroundingTiles.Add(GetNorth(x, y));
        }
        var northEast = GetNorthEast(x, y);
        if (northEast != null)
        {
            surroundingTiles.Add(GetNorthEast(x, y));
        }
        var east = GetEast(x, y);
        if (east != null)
        {
            surroundingTiles.Add(GetEast(x, y));
        }
        var southEast = GetSouthEast(x, y);
        if (southEast != null)
        {
            surroundingTiles.Add(GetSouthEast(x, y));
        }
        var south = GetSouth(x, y);
        if (south != null)
        {
            surroundingTiles.Add(GetSouth(x, y));
        }
        var southWest = GetSouthWest(x, y);
        if (southWest != null)
        {
            surroundingTiles.Add(GetSouthWest(x, y));
        }
        var west = GetWest(x, y);
        if (west != null)
        {
            surroundingTiles.Add(GetWest(x, y));
        }
        var northWest = GetNorthWest(x, y);
        if (northWest != null)
        {
            surroundingTiles.Add(GetNorthWest(x, y));
        }
        return surroundingTiles;
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

        var selectedTile = _board[x, y];
        if (selectedTile == TileType.BluePrince)
        {
            var size = GetSize();
            if (size % 2 == 0)
            {
                return _board; // blue tile doesn't work on even boards
            }
            var centerCoord = (size - 1) / 2;
            selectedTile = GetTile(centerCoord, centerCoord).TileType;
        }

        var newBoard = selectedTile switch
        {
            TileType.None => _board,
            TileType.MoraJai => MoraJaiTile.OnClick(this, x, y),
            TileType.OrindaAries => OrindaAries.OnClick(this, x, y),
            TileType.FennAries => FennAries.OnClick(this, x, y),
            TileType.Nuance => Nuance.OnClick(this, x, y),
            TileType.Corarica => Corarica.OnClick(this, x, y),
            TileType.Verra => Verra.OnClick(this, x, y),
            TileType.ArchAries => ArchAries.OnClick(this, x, y),
            TileType.Eraja => Eraja.OnClick(this, x, y),
            TileType.BluePrince => _board,
            _ => _board
        };

        return newBoard;
    }
}