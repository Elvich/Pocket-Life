using SceneLoader;
using UnityEngine;
using YG;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        YG2.saves.gameData = new GameData();
        SceneLoader.SceneLoader.Loader.UnloadAll();
        SceneLoader.SceneLoader.Loader.Load(EScenes.Game);
    }

    public void ContinueGame()
    {
        SceneLoader.SceneLoader.Loader.UnloadAll();
        SceneLoader.SceneLoader.Loader.Load(EScenes.Game);
    }

    public void SettingsGame()
    {
        
    }
}
