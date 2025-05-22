using System;
using System.Collections.Generic;
using YG;

public class EventCreator 
{
    private List<IDataSubscriber> _subscribers;

    private void Initiailize()
    {
        _subscribers ??= new List<IDataSubscriber>();
    }

    public void InformEveryone<T>(T data)
    {
        Initiailize();
        foreach (IDataSubscriber subscriber in _subscribers)
        {
            subscriber.GetGameData(data);
        }
    }
    
    public void Subscribe(IDataSubscriber subscriber)
    {
        Initiailize();
        _subscribers.Add(subscriber);
        subscriber.GetGameData(YG2.saves.gameData);
    }

    public void Unsubscribe(IDataSubscriber subscriber)
    {
        if (_subscribers == null) throw new Exception("Subscribe is null");
        
        _subscribers.Remove(subscriber);
    }
}
