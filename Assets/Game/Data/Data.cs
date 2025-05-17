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
    private int _money = 5;
    public EventCreator EventCreator = new EventCreator();

    public void addMoney(int money)
    {
        if (money < 0) throw new System.Exception("Adding money cannot be negative");
        _money += money;
        EventCreator.InformEveryone();
    }

    public void RemoveMoney(int money)
    {
        if (money < 0) throw new System.Exception("Removing money cannot be negative");
        _money -= money;
        EventCreator.InformEveryone();
    }

    public int GetMoney() => _money;
}

public struct Settings
{
    
}