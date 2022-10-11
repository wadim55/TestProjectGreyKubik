using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScrollWiev : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private string _savePath;
    [SerializeField] private string saveFileName = "data.json";
   
    private void Awake()
    {
#if    UNITY_ANDROID && !UNITY_EDITOR 
       _savePath = Path.Combine(Application.persistentDataPath, saveFileName);
#else 
        _savePath = Path.Combine(Application.dataPath, saveFileName);
    
#endif
    }

    public void SaveToFile()
    {
        var gameCore = new GameCoreStruct
        {
           volume = _scrollbar.value
        };
        var json = JsonUtility.ToJson(gameCore, true);
      File.WriteAllText(_savePath, json);
    }

    public void LoadFromFile()
    {
        if (!File.Exists(_savePath)) return;
        var json = File.ReadAllText(_savePath);
        var gameCoreFromJSon = JsonUtility.FromJson<GameCoreStruct>(json);
        _scrollbar.value = gameCoreFromJSon.volume;
        GetComponent<Text>().text = "Звук: " + ((int)(gameCoreFromJSon.volume*100)).ToString() + "%";
      
    }
    private void Start()
    {
       LoadFromFile();
    }

        public void changeVolume()
    {
        GetComponent<Text>().text = "Звук: " + ((int)(_scrollbar.value*100)).ToString() + "%";
        GameEvent.Changevolume(_scrollbar.value);
        SaveToFile();
    }
        
}
