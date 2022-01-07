using PKHeX.Core;

namespace PKHeX.Web.Services
{
  public class SaveFileService
  {
    private SaveFile _saveFile;

    public SaveFile SaveFile
    {
      get
      {
        return _saveFile;
      }
      set
      {
        _saveFile = value;
        FilteredGameDataSource = new FilteredGameDataSource(value, GameInfo.Sources);
        BoxEdit = new BoxEdit(SaveFile);
        NotifyDataChanged();
      }
    }

    public FilteredGameDataSource FilteredGameDataSource { get; internal set; }

    public BoxEdit BoxEdit { get; internal set; }

    public event Action? OnChange;

    public void NotifyDataChanged() => OnChange?.Invoke();
  }
}