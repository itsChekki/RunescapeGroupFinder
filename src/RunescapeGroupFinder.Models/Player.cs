namespace RunescapeGroupFinder.Models;

public class Player {
  public string Name { get; set; }
  public List<string> Roles { get; set; }
  public string Notes { get; set; }
  public bool ForReaper { get; set; }
  public bool WithLearners { get; set; }
}
