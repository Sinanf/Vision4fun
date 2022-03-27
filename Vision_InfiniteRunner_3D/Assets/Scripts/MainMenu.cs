using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public Toggle toggle;
    
    

    private void Update()
    {
        SaveData2();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }    

    

    public void SaveData2()
    {
        if (toggle.isOn == true)
        {
            PlayerPrefs.SetInt("MusicData", 1);
            
        }
        else 
        {
            toggle.isOn = false;
            PlayerPrefs.SetInt("MusicData", 0);
            
            
        }
    }    

}
