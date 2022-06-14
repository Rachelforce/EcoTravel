using System;
using System.Collections.Generic;
using System.IO;
using Data;
using GoToApps.Serialization;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class ExampleComponents : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private string saveFilename;
        [SerializeField] private string pathToSaveFile;
        [SerializeField] private GameData gameData;
        
        [ContextMenu("Generate game data")]
        public void GenerateGameData()
        {
            List<string> strings = new List<string>();
            strings.Add("Hello World.");
            strings.Add("Example string.");
            strings.Add("Foo Bar");
            strings.Add("Example title");
            strings.Add("Example description");

            int i = Random.Range(0, strings.Count);
            string exampleString = strings[i];
            long randomLong = Random.Range(-10000, 10000);
            decimal randomDecimal = Random.Range(-100, 100);

            this.gameData.someStringValue = exampleString;
            this.gameData.someIntValue = i;
            this.gameData.someLongValue = randomLong;
            this.gameData.someDecimalValue = randomDecimal;

            int itemsCount = Random.Range(3, 10);
            this.gameData.shopItems = new List<ShopItem>();
            
            for (int j = 0; j < itemsCount; j++)
            {
                int k = Random.Range(0, strings.Count);
                int l = Random.Range(0, strings.Count);
                this.gameData.shopItems.Add(new ShopItem
                {
                    id = Random.Range(-10000, 10000),
                    price = Random.Range(-100, 100),
                    description = strings[k],
                    title = strings[k]
                });
            }
        }

        private void Awake()
        {
            this.pathToSaveFile = Path.Combine(Application.dataPath, this.saveFilename);

            if (File.Exists(this.pathToSaveFile))
            {
                this.gameData = BinarySerializer.Deserialize<GameData>(this.pathToSaveFile);
            }
        }

        private void OnApplicationQuit()
        {
            BinarySerializer.Serialize(this.pathToSaveFile, this.gameData);
        }
    }
}