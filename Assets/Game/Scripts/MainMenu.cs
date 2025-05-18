using System;
using SceneLoader;
using UnityEngine;
using YG;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject tablet;
    [SerializeField] private GameObject portrait;

    private void Start()
    {
        portrait.SetActive(false);
        tablet.SetActive(false);
        
        if (YG2.envir.isMobile) portrait.SetActive(true); 
        else tablet.SetActive(true);
    }

    public void NewGame()
    {
        YG2.saves.gameData = new GameData();
        SceneLoader.SceneLoader.Loader.UnloadAll();
        SceneLoader.SceneLoader.Loader.Load(EScenes.Game);
    }

    public void ContinueGame()
    {
        if (YG2.saves.gameData == null) NewGame();
        
        SceneLoader.SceneLoader.Loader.UnloadAll();
        SceneLoader.SceneLoader.Loader.Load(EScenes.Game);
    }

    public void SettingsGame()
    {
        
    }
}
