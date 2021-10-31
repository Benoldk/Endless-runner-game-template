using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace game.package.gameplay.resourceloader
{
    public class AssetManager : MonoBehaviour
    {
        public readonly string PrefabsDir = "Resources/prefabs/";
        public readonly string levelsDir = "levels";
        public readonly string playersDir = "players";

        public string level = "prototype";
        public string player = "player_michelle";

        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public List<GameObject> LoadLevelAssets()
        {
            string path = $"{Application.dataPath}/{PrefabsDir}/{levelsDir}/{level}";
            var files = Directory.GetFiles(path).Where(f => !f.EndsWith("meta"));
            List<GameObject> levelAssets = new List<GameObject>();
            foreach (var file in files)
            {
                int assetPathIndex = file.IndexOf("Assets");
                string localPath = file.Substring(assetPathIndex).Replace("\\", "/").Replace("//", "/");
                GameObject asset = AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject)) as GameObject;
                levelAssets.Add(asset);
            }
            return levelAssets;
        }

        public GameObject LoadPlayer()
        {
            string path = $"{Application.dataPath}/{PrefabsDir}/{playersDir}/";
            var files = Directory.GetFiles(path).Where(f => !f.EndsWith("meta"));
            var playerFile = files.FirstOrDefault(f => f.Contains(player));
            if (!string.IsNullOrEmpty(playerFile))
            {
                int assetPathIndex = playerFile.IndexOf("Assets");
                string localPath = playerFile.Substring(assetPathIndex).Replace("\\", "/").Replace("//", "/");
                var playerObj = AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject)) as GameObject;
                return playerObj;
            }
            return null;
        }
    }
}