namespace RunescapeGroupFinder.Models;

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
