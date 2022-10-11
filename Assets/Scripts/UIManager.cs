using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private Text resultText;
   
    
    
    private void OnEnable()
    {
        GameEvent.Kub+= ShowResult;
        GameEvent.AudioButton +=AudioPanelActivate;
    }
    private void OnDisable()
    {
        GameEvent.Kub -= ShowResult;
        GameEvent.AudioButton -=AudioPanelActivate;
    }

    private void ShowResult(string tagPocket)
    {
        switch (tagPocket)
        {
            case "TrueCube":
                Invoke("Bingo", 1f);
                GameEvent.Sobitie("animOn");
                break;
            case "FalseCube":
                resultPanel.SetActive(true);
                resultText.text = "ОШИБКА";
                break;
          
        }
    }

    private void Bingo()
    {
        resultPanel.SetActive(true);
        resultText.text = "ПОБЕДА";
    }

    private void AudioPanelActivate(int whoCall)
    {
        if (whoCall == 1)
        {
            pausePanel.SetActive(true);
        }
    }

    public void ExitVolumMenu()
    {
        pausePanel.SetActive(false);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(1);
    }
    
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
