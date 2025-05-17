using UnityEngine;
using SceneLoader;
using YG;
using TMPro;

public class GamePlay : MonoBehaviour, IDataSubscriber
{
    [SerializeField] private TMP_Text text;
    
    private void Start()
    {
        ((IDataSubscriber)this).Subscribe();
    }

    public void AddMoney()
    {
        YG2.saves.gameData.addMoney(5);
    }

    public void ExitGame()
    {
        YG2.SaveProgress();
        
        SceneLoader.SceneLoader.Loader.UnloadAll();
        SceneLoader.SceneLoader.Loader.Load(EScenes.MainMenu);
    }

    public void GetGameData(GameData data)
    {
        text.text = data.GetMoney().ToString();
    }

    private void OnDisable()
    {
        ((IDataSubscriber)this).Unsubscribe();
    }
}
