using System.Collections.Generic;

namespace SceneLoader
{
    public class PrefabsScenes
    {
        private Dictionary<EScenes, EScenes[]> _prefabs;
        
        public Dictionary<EScenes, EScenes[]> AddingPrefabs()
        {
            _prefabs = new Dictionary<EScenes, EScenes[]>();
            
            return _prefabs;
        }

        
    }
}
