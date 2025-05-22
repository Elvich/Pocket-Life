using YG;

public interface IDataSubscriber 
{
    public void GetGameData<T>(T data);

    public void Subscribe();

    public void Unsubscribe();
}
