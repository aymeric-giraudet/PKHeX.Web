using PKHeX.Core;

namespace PKHeX.Web.Services
{
  public class PokemonEditorService
  {
    public bool IsSetLeft { get; set; } = true;

    private PKM _pokemon;

    public PKM Pokemon
    {
      get
      {
        return _pokemon;
      }
      set
      {
        _pokemon = value;
        NotifyDataChanged();
      }
    }

    public event Action? OnChange;

    public void NotifyDataChanged() => OnChange?.Invoke();
  }
}