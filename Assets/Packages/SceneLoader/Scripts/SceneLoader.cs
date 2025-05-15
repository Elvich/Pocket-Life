using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoader
{
    /// <summary>
    /// Класс для загрузги и выгрузки сцен Unity
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        /// <summary>
        /// Статичный экзепляр класса SceneLoader
        /// </summary>
        public static SceneLoader Loader;


        [SerializeField] private EScenes startScene;
        [Space, Header("Panels")] [SerializeField] private GameObject loadingUi;
        private readonly List<AsyncOperation> _sceneLoading = new();

        private List<EScenes> _activeScenes;
        /// <summary>
        /// Возвращает список всех загруженных сцен
        /// </summary>
        public List<EScenes> ActiveScenes => _activeScenes;

        private Dictionary<EScenes, EScenes[]> _prefabs;
        private List<EScenes> _nonUnloadingScenes = new() { EScenes.Data };

        private void Awake()
        {
            if (Loader == null)
                Loader = this;
            else
                throw new Exception("Only one Scene Loader can be active at a time.");

            _activeScenes = new List<EScenes>();
            
            if (loadingUi != null)
                loadingUi.SetActive(false);
            
            _prefabs = new PrefabsScenes().AddingPrefabs();

            if (startScene != EScenes.Main)
            {
                if (_prefabs.ContainsKey(startScene)) Load(_prefabs[startScene]);
                else Load(startScene);
            }
        }

        #region Loads
        /// <summary>
        /// Асинхронно загружает сцену 
        /// </summary>
        /// <param name="scene">Сцена из списка EScenes</param>
        /// <param name="activeLoadingUi">Включать ли загрузочную панель. По умолчанию стоит true</param>
        public void Load(EScenes scene, bool activeLoadingUi = true)
        {
            if (_activeScenes.Contains(scene)) return;
            _sceneLoading.Add(SceneManager.LoadSceneAsync((int)scene, LoadSceneMode.Additive));
            _activeScenes.Add(scene);
            StartCoroutine(GetSceneLoadProgress(activeLoadingUi));
        }
        
        /// <summary>
        /// Асинхронно загружает сцены 
        /// </summary>
        /// <param name="scenes">Массив сцен из списка EScenes</param>
        /// <param name="activeLoadingUi">Включать ли загрузочную панель. По умолчанию стоит true</param>
        public void Load(EScenes[] scenes, bool activeLoadingUi = true)
        {
            foreach (var scene in scenes)
            {
                Load(scene, activeLoadingUi);
            }
        }
        #endregion

        #region Unloads
        /// <summary>
        /// Асинхронно выгружает сцену 
        /// </summary>
        /// <param name="scene">Сцена из списка EScenes</param>
        /// <param name="activeLoadingUi">Включать ли загрузочную панель. По умолчанию стоит true</param>
        /// <param name="forceUnload">Пренудительно выгрузить. ВНИМАНИЕ! Пренудительная выгрузка может превести к ошибкам!</param>
        public void Unload(EScenes scene, bool activeLoadingUi = true, bool forceUnload = false)
        {
            if (_activeScenes.Contains(scene))
            {
                if (!_nonUnloadingScenes.Contains(scene) || forceUnload)
                {
                    _sceneLoading.Add(SceneManager.UnloadSceneAsync((int)scene,
                        UnloadSceneOptions.UnloadAllEmbeddedSceneObjects));
                    _activeScenes.Remove(scene);
                    StartCoroutine(GetSceneLoadProgress(activeLoadingUi));
                }
            }
        }
        
        /// <summary>
        /// Асинхронно выгружает сцены
        /// </summary>
        /// <param name="scenes">Массив сцен из списка EScenes</param>
        /// <param name="activeLoadingUi">Включать ли загрузочную панель. По умолчанию стоит true</param>
        /// <param name="forceUnload">Пренудительно выгрузить. ВНИМАНИЕ! Пренудительная выгрузка может превести к ошибкам!</param>
        public void Unload(EScenes[] scenes, bool activeLoadingUi = true, bool forceUnload = false)
        {
            foreach (EScenes scene in scenes)
            {
                Unload(scene, activeLoadingUi, forceUnload);
            }
        }
        
        /// <summary>
        /// Асинхронно выгружает все загруженные сцены
        /// </summary>
        /// <param name="activeLoadingUi">Включать ли загрузочную панель. По умолчанию стоит true</param>
        /// <param name="forceUnload">Пренудительно выгрузить. ВНИМАНИЕ! Пренудительная выгрузка может превести к ошибкам!</param>
        public void UnloadAll(bool activeLoadingUi = true, bool forceUnload = false)
        {
            foreach (var scene in _activeScenes.ToList())
            {
                Unload(scene, activeLoadingUi, forceUnload);
            }
        }
        #endregion

        private IEnumerator GetSceneLoadProgress( bool activeLoadingUi)
        {
            if (loadingUi != null && activeLoadingUi)
                loadingUi.SetActive(true);
            
            for (int i = 0; i < _sceneLoading.Count; i++)
            {
                while (!_sceneLoading[i].isDone)
                {
                    yield return null;
                }
            }

            //yield return new WaitForSecondsRealtime(2f);
            if (loadingUi != null && activeLoadingUi)
                loadingUi.SetActive(false);
        }

    }
}