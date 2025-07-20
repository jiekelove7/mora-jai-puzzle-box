namespace MoraJai.Core.Tiles.FennAries;

public static class FennAries
{
    public static TileType[,] OnClick(Board board, int x, int y, TileType selfType = TileType.FennAries)
    {
        for (var i = 0; i < board.GetSize(); i++)
        {
            for (var j = 0; j < board.GetSize(); j++)
            {
                switch (board.GetTile(i, j).TileType)
                {
                    case TileType.MoraJai:
                        board.SetTile(i, j, TileType.OrindaAries);
                        break;
                    case TileType.OrindaAries:
                        board.SetTile(i, j, selfType);
                        break;
                    default:
                        break;
                }
            }
        }
        return board.GetBoard();
    }
}