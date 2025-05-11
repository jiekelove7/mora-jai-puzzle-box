using Microsoft.AspNetCore.Mvc;
using MoraJai.Core;
using MoraJai.Core.Tiles;

namespace MoraJai.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    public GameController()
    {
    }

    [HttpGet("Board")]
    public async Task<ActionResult<TileType[,]>> GetBoard()
    {
        var board = new Board(3).GetBoard();
        var result = ArrayConverter.ToJagged(board);
        return Ok(result);
    }
}