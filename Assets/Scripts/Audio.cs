using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
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
    
    private void Start()
    {
        if (!File.Exists(_savePath)) return;
        var json = File.ReadAllText(_savePath);
        var gameCoreFromJSon = JsonUtility.FromJson<GameCoreStruct>(json);
       _audio.volume = gameCoreFromJSon.volume;
    }
    
    private void OnEnable()
    {
        GameEvent._volume+= ChangeVolume;
       
    }
    private void OnDisable()
    {
        GameEvent._volume -= ChangeVolume;
    }

    private void ChangeVolume(float volume)
    {
        _audio.volume = volume;
       
    }
  
    
}
