using UnityEngine;
using SceneLoader;
using YG;
using TMPro;

public class GamePlay : MonoBehaviour, IDataSubscriber
{
    [SerializeField] private TMP_Text text;
    
    private void Start()
    {
        Subscribe();
    }

    public void AddMoney()
    {
        //YG2.saves.gameData.addMoney(5);
        YG2.saves.gameData.Financial.AddMoney(5);
    }

    public void ExitGame()
    {
        YG2.SaveProgress();
        
        SceneLoader.SceneLoader.Loader.UnloadAll();
        SceneLoader.SceneLoader.Loader.Load(EScenes.MainMenu);
    }
    
    private void OnDisable()
    {
        Unsubscribe();
    }

    public void GetGameData<T>(T data)
    {
        if (data is FinancialData financialData) text.text = financialData.GetMoney().ToString();
    }

    public void Subscribe()
    {
        YG2.saves.gameData.Financial.EventCreator.Subscribe(this);
    }

    public void Unsubscribe()
    {
        YG2.saves.gameData.Financial.EventCreator.Unsubscribe(this);
    }
}
