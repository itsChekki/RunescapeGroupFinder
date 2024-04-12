using System.Collections.Concurrent;
using FluentAssertions;
using RunescapeGroupFinder.Backend.Storage;
using RunescapeGroupFinder.Models;

namespace RunescapeGroupFinder.Backend.Tests;

public class InMemoryRegistryTests {
  [Fact]
  public async Task Player_is_assigned_and_a_new_boss_entry_is_added() {
    var inMemStorage = new InMemoryRegistry(new ConcurrentDictionary<Boss, List<Player>>());

    var player = new Player() {
      Name = "LobbyElf",
      Notes = "Bis Necro",
      Roles = RoleMappings.Aod7Man,
      ForReaper = false,
      WithLearners = false
    };

    await inMemStorage.AssignPlayerToBoss(Bosses.Aod, player);

    var assignedPlayers = await inMemStorage.GetSearchingPlayersForBoss(Bosses.Aod);

    assignedPlayers.Should().HaveCount(1);

    assignedPlayers.First().Should().Be(player);
  }

  [Fact]
  public async Task Player_is_assigned_boss_has_entries_player_is_added() {
    var concurrentDict = new ConcurrentDictionary<Boss, List<Player>>();

    var existingPlayer = new Player() {
      Name = "Zamorak",
      Notes = "Dual Bolg",
      Roles = RoleMappings.Aod7Man,
      ForReaper = false,
      WithLearners = false
    };

    concurrentDict.TryAdd(Bosses.Aod, new List<Player> { existingPlayer });

    var inMemStorage = new InMemoryRegistry(concurrentDict);

    var player = new Player() {
      Name = "Guthix",
      Notes = "Bis Sleeping",
      Roles = RoleMappings.Aod7Man,
      ForReaper = true,
      WithLearners = true
    };

    await inMemStorage.AssignPlayerToBoss(Bosses.Aod, player);

    var assignedPlayers = await inMemStorage.GetSearchingPlayersForBoss(Bosses.Aod);

    assignedPlayers.Should().HaveCount(2);

    assignedPlayers.Should().BeEquivalentTo(new List<Player>() {
      existingPlayer, player
    });
  }
  
  [Fact]
  public async Task Boss_is_fetched_that_doesnt_have_players() {

    var inMemStorage = new InMemoryRegistry(new ConcurrentDictionary<Boss, List<Player>>());

    var assignedPlayers = await inMemStorage.GetSearchingPlayersForBoss(Bosses.Aod);

    assignedPlayers.Should().BeEmpty();
  }
}
