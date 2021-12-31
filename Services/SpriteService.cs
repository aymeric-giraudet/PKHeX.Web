using PKHeX.Core;

namespace PKHeX.Web.Services
{
  public class SpriteService
  {
    public IReadOnlyDictionary<string, string> Items { get; internal set; } = new Dictionary<string, string>();

    public IReadOnlyDictionary<string, PokemonSprite> Pokemon { get; internal set; } = new Dictionary<string, PokemonSprite>();

    public void Initialize(IReadOnlyDictionary<string, string> items, IReadOnlyDictionary<string, PokemonSprite> pokemon)
    {
      Items = items;
      Pokemon = pokemon;
    }

    public string GetItem(int spriteId)
    {
      if (spriteId == 0) return "";

      var key = $"item_{spriteId:0000}";
      return $"assets/items/{Items[key]}.png";
    }

    public string GetPokemon(PKM pkm)
    {
      string key = pkm.Species.ToString("000");
      return $"assets/pokemon-gen8/regular/{Pokemon[key].Slug}.png";
    }
  }

  public class PokemonSprite
  {
    public string Slug { get; set; } = "";
    public bool HasFemaleForm { get; set; }
  }
}