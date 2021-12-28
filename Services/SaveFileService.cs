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
        NotifyDataChanged();
      }
    }

    public event Action OnChange;

    private void NotifyDataChanged() => OnChange?.Invoke();
  }
}