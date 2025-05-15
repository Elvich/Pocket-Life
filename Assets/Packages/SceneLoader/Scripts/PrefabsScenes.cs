using System.Collections.Generic;

namespace SceneLoader
{
    public class PrefabsScenes
    {
        private Dictionary<EScenes, EScenes[]> _prefabs = new();
        
        public Dictionary<EScenes, EScenes[]> AddingPrefabs()
        {
            _prefabs.Add(EScenes.TestMaksim, new EScenes[] { EScenes.TestMaksim, EScenes.Data });
            
            return _prefabs;
        }

        
    }
}
