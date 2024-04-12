namespace RunescapeGroupFinder.Models;
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
