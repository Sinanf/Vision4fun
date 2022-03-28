using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{

    private int playerHeart = 3;
    private static int currentHeart;

    [SerializeField] private Image[] hearts;    
    [SerializeField] private Button playButton;
    [SerializeField] private Button adsButton;

    void Start()
    {        
        currentHeart = playerHeart;        
        ColorUpdate(playerHeart);
        playButton.onClick.AddListener(TaskOnClick);
        
    }


    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
        
    }

    public int GetInt(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
        
    }

    void TaskOnClick()
    {        
        currentHeart -= 1;         
        ColorUpdate(currentHeart);
        
    }


    public void GainHeartFromAds()
    {
        currentHeart = 3;        
        ColorUpdate(currentHeart);
        Debug.Log("Gained 3 hearts from ads" + currentHeart);

    }
    

    public void ColorUpdate(int currentHeart)
    {
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


}
