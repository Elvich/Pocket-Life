using YG;

public interface IDataSubscriber 
{
    public void GetGameData(GameData data);

    public void Subscribe()
    {
        YG2.saves.gameData.EventCreator.Subscribe(this);
    }

    public void Unsubscribe()
    {
        YG2.saves.gameData.EventCreator.Unsubscribe(this);
    }
}
