using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RunescapeGroupFinder.Backend.Storage;
using RunescapeGroupFinder.Models;

namespace RunescapeGroupFinder.Backend.Controllers;

[ApiController]
[Route("[controller]/v1")]
public class BossAssignmentController(IStorageRegistry storageRegistry) : ControllerBase {

  [HttpGet("GetBosses")]
  public ActionResult<List<Boss>> GetBosses() {

    
    var bosses = new List<Boss>() {
      Bosses.Solak,
      Bosses.BeastMaster,
      Bosses.Aod,
      Bosses.Rago3Plus,
      Bosses.RagoDuo
    };
    
    return bosses;
  }
  
  [HttpPost("RegisterPlayer/{bossName}")]
  public async  Task<ActionResult> RegisterPlayer(string bossName, [FromBody] Player player) {

    var boss = Bosses.AllBosses.Find(x => x.BossName == bossName);

    if (boss == null)
      return NotFound($"A boss with the name {bossName} was not found");

    await storageRegistry.AssignPlayerToBoss(boss, player);

    return Ok();
  }
}
