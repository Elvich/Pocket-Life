[System.Serializable] 
public class FinancialData 
{
    private int _money = 5;
    public EventCreator EventCreator = new EventCreator();

    public void AddMoney(int money)
    {
        if (money < 0) throw new System.Exception("Adding money cannot be negative");
        _money += money;
        EventCreator.InformEveryone(this);
    }

    public void RemoveMoney(int money)
    {
        if (money < 0) throw new System.Exception("Removing money cannot be negative");
        _money -= money;
        EventCreator.InformEveryone(this);
    }

    public int GetMoney() => _money;
}
