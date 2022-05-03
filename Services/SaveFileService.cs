using PKHeX.Core;

namespace PKHeX.Web.Services
{
  public class SavEdit
  {
    private SaveFile _SAV;

    public SaveFile SAV
    {
      get
      {
        return _SAV;
      }
      set
      {
        _SAV = value;
        GameInfo.FilteredSources = new FilteredGameDataSource(value, GameInfo.Sources);
        NotifyDataChanged();
      }
    }

    public event Action? OnChange;

    public void NotifyDataChanged() => OnChange?.Invoke();
  }
}