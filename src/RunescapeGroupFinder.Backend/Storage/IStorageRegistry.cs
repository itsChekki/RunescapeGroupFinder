using System.Collections.Concurrent;
using RunescapeGroupFinder.Models;

namespace RunescapeGroupFinder.Backend.Storage;

public interface IStorageRegistry {
  Task AssignPlayerToBoss(Boss boss, Player player);
  Task<List<Player>> GetSearchingPlayersForBoss(Boss boss);
}

public class InMemoryRegistry(ConcurrentDictionary<Boss, List<Player>> bossRegistry) : IStorageRegistry {
  public Task AssignPlayerToBoss(Boss boss, Player player) {
    
    if (bossRegistry.TryGetValue(boss, out var players)) {
      players.Add(player);
      return Task.CompletedTask;
    }
    
    var newPlayerList = new List<Player> { player };
    bossRegistry.TryAdd(boss, newPlayerList);

    return Task.CompletedTask;
  }

  public Task<List<Player>> GetSearchingPlayersForBoss(Boss boss) {
    return Task.FromResult(bossRegistry.TryGetValue(boss, out var players) ? players : new List<Player>());
  }
}
