using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public Toggle toggle;    
    private bool toggleOn;

    private void Start()
    {
        
        toggle.isOn = toggleOn;
        ToggleBool(toggleOn);
        
        
        
        
        

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
    public void CheckData()
    {
        if (PlayerPrefs.HasKey("MusicData"))
        {
            
            if (PlayerPrefs.GetInt("MusicData") > 0)
            {
                toggleOn = true;
            }
            else
            {
                toggleOn = false;
            }
        }
        PlayerPrefs.Save();
        
    }

    

    public void ToggleBool (bool toggleOn)
    {
        if (toggleOn == true)
        {
            PlayerPrefs.SetInt("MusicData", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MusicData", 0);
        }
        CheckData();
    }



}
