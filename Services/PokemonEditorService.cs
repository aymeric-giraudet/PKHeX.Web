using PKHeX.Core;

namespace PKHeX.Web.Services
{
  public class PokemonEditorService
  {
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

    public event Action OnChange;

    private void NotifyDataChanged() => OnChange?.Invoke();
  }
}