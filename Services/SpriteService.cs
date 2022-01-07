using System.Net.Http.Json;
using PKHeX.Core;

namespace PKHeX.Web.Services
{
  public class SpriteService
  {
    public IReadOnlyDictionary<string, string>? Items { get; internal set; }

    public IReadOnlyDictionary<string, PokemonSprite>? Pokemon { get; internal set; }

    public async Task InitializeServiceAsync(HttpClient httpClient)
    {
      var itemsTask = httpClient.GetFromJsonAsync<IReadOnlyDictionary<string, string>>("assets/data/item-map.json");
      var pokemonsTask = httpClient.GetFromJsonAsync<IReadOnlyDictionary<string, PokemonSprite>>("assets/data/pokemon.json");

      Items = await itemsTask;
      Pokemon = await pokemonsTask;
    }

    public string GetItem(int spriteId)
    {
      if (spriteId == 0) return "";

      var key = $"item_{spriteId:0000}";
      return $"assets/items/{Items![key]}.png";
    }

    public string GetPokemon(PKM pkm)
    {
      string key = pkm.Species.ToString("000");
      var spriteInfo = Pokemon![key];

      string shinyOrRegular = pkm.IsShiny ? "shiny" : "regular";
      string femaleSprite = spriteInfo.HasFemaleForm ? "female/" : "";

      return $"assets/pokemon-gen8/{shinyOrRegular}/{femaleSprite}{spriteInfo.Slug}.png";
    }

    public string GetPokemonBySpeciesId(int speciesId)
    {
      string key = speciesId.ToString("000");
      return $"assets/pokemon-gen8/regular/{Pokemon![key].Slug}.png";
    }
  }

  public record PokemonSprite(string Slug, bool HasFemaleForm);
}