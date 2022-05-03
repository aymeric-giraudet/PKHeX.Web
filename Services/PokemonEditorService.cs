using PKHeX.Core;

namespace PKHeX.Web.Services
{
  public class PkmEdit
  {
    public bool IsSetLeft { get; set; } = true;

    private PKM _PKM;

    public PKM PKM
    {
      get
      {
        return _PKM;
      }
      set
      {
        _PKM = value;
        NotifyDataChanged();
      }
    }

    public event Action? OnChange;

    public void NotifyDataChanged() => OnChange?.Invoke();
  }
}