using PKHeX.Core;

namespace PKHeX.Web.Services
{
  public class SpriteService
  {
    public IReadOnlyDictionary<string, string> Items { get; internal set; } = new Dictionary<string, string>();

    public IReadOnlyDictionary<string, string> Pokemon { get; internal set; } = new Dictionary<string, string>();

    public void Initialize(IReadOnlyDictionary<string, string> items, string pokemon)
    {
      Items = items;
    }

    public string GetItem(int spriteId)
    {
      if (spriteId == 0) return "";

      var key = $"item_{spriteId.ToString().PadLeft(4, '0')}";
      return $"https://raw.githubusercontent.com/msikma/pokesprite/master/items/{Items[key]}.png";
    }

    public string GetPokemon(PKM pkm)
    {
      string key = pkm.Species.ToString().PadLeft(3, '0');
      return $"https://raw.githubusercontent.com/msikma/pokesprite/master/pokemon-gen8/regular/{Pokemon}.png";
    }
  }
}