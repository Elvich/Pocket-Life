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
    public FinancialData Financial = new FinancialData();
}

public struct Settings
{
    
}