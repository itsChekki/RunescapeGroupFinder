namespace RunescapeGroupFinder.Models;

[Serializable]
public record Boss {
  public string BossName { get; }
  public short PlayerCount { get; }
  public List<string> Roles { get; }
  internal Boss(string bossName, short playerCount, List<string> roles){
    BossName = bossName;
    PlayerCount = playerCount;
    Roles = roles;
  }
}

public class Player {
  public string Name { get; set; }
  public List<string> Roles { get; set; }
  public string Notes { get; set; }
  public bool ForReaper { get; set; }
  public bool WithLearners { get; set; }
}

public class Group {
  public string Name { get; set; }
  public Boss Boss { get; set; }
  public List<Player> Players { get; init; }
}

public static class RoleMappings {
  public static List<string> Aod7Man = new() { "Base", "Hammer", "Free", "Umbra", "Cruor", "Fumus", "Glacier" };
  public static List<string> Rago3Plus = new() { "Base", "Bomb", "Tl5" };
  public static List<string> RagoDuo = new() { "Base", "Bomb" };
  public static List<string> Solak = new() { "Base", "Dps" };
  public static List<string> BeastMaster = new() { "Base", "Backup", "South Charge", "Pt13", "Pt2" };
}

public static class Bosses {
  public static Boss Aod = new Boss("Aod", 7, RoleMappings.Aod7Man);
  public static Boss Rago3Plus = new Boss("Rago3Plus", 10, RoleMappings.Rago3Plus);
  public static Boss RagoDuo = new Boss("RagoDuo", 2, RoleMappings.RagoDuo);
  public static Boss Solak = new Boss("Solak", 7, RoleMappings.Solak);
  public static Boss BeastMaster = new Boss("Beastmaster", 7, RoleMappings.BeastMaster);

  public static List<Boss> AllBosses = new() {
    Aod, Rago3Plus, RagoDuo, Solak, BeastMaster
  };
}
