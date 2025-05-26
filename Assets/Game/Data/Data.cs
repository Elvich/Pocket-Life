namespace YG
{
    public partial class SavesYG
    {
        public GameData gameData;
    }
}

[System.Serializable]
public class GameData
{
    public FinancialData Financial = new();
}

public class Settings
{
    private Source _source = Source.instance;
    
    private EThemes _theme = EThemes.Clasic;
    
    public void ChangeTheme(EThemes theme) { _theme = theme; }
    public Themes GetTheme() => _source.GetTheme(_theme);
}