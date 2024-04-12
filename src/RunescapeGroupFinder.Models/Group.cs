namespace RunescapeGroupFinder.Models;

public class Group {
  public string Name { get; set; }
  public Boss Boss { get; set; }
  public List<Player> Players { get; init; }
}
