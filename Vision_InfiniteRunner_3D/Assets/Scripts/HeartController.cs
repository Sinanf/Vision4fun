using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{

    private int playerHeart = 3;
    private int currentHeart;

    [SerializeField] private Image[] hearts;    
    [SerializeField] private Button playButton;
    [SerializeField] private Button adsButton;

    void Start()
    {
        currentHeart = playerHeart;
        ColorUpdate(playerHeart);

        playButton.onClick.AddListener(TaskOnClick);
    }


    public void UpdateHeart()
    {        
        ColorUpdate(currentHeart);
    }


    void TaskOnClick()
    {
        Debug.Log("azaltma öncesi = " + currentHeart);
        SetInt("currentHeart", currentHeart - 1);
        GetInt("currentHeart");
        ColorUpdate(currentHeart);
        Debug.Log("1 azaltýldý");
    }


    public void GainHeartFromAds()
    {
        currentHeart = 3;
        SetInt("currentHeart", 3);
        GetInt("currentHeart");
        ColorUpdate(currentHeart);
    }
    

    public void ColorUpdate(int currentHeart)
    {
        
        if (PlayerPrefs.HasKey("currentHeart"))
        {
            Debug.Log("key is correct and " + currentHeart);

            if (currentHeart == 3)
            {

                hearts[0].color = Color.red;
                hearts[1].color = Color.red;
                hearts[2].color = Color.red;

            }
            else if (currentHeart == 2)
            {
                hearts[0].color = Color.red;
                hearts[1].color = Color.red;
                hearts[2].color = Color.black;
            }
            else if (currentHeart == 1)
            {
                hearts[0].color = Color.red;
                hearts[1].color = Color.black;
                hearts[2].color = Color.black;
            }
            else if (currentHeart == 0)
            {

                hearts[0].color = Color.black;
                hearts[1].color = Color.black;
                hearts[2].color = Color.black;

            }

        }
        PlayerPrefs.Save();
        
    }

    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
        Debug.Log("Player saved" + currentHeart);
    }

    public int GetInt(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
        Debug.Log("Player saved" + currentHeart);
    }

}
