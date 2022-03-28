using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{

    public int playerHeart;

    [SerializeField] private Image[] hearts;    
    [SerializeField] private Button playButton;
    [SerializeField] private Button adsButton;
    
    private bool isClicked;


    void Start()
    {
        playerHeart = 3;
        UpdateHeartSetting();
    }

    
    void Update()
    {
        playButton.onClick.AddListener(TaskOnClick);
        UpdateHeartSetting();
    }

    public void UpdateHeartSetting()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (playerHeart == 3)
            {
                hearts[i].color = Color.red;
            }
            else if (playerHeart == 2)
            {
                hearts[0].color = Color.red;
                hearts[1].color = Color.red;
                hearts[2].color = Color.black;
            }
            else if (playerHeart == 1)
            {
                hearts[0].color = Color.red;
                hearts[1].color = Color.black;
                hearts[2].color = Color.black;
            }
            else 
            {
                hearts[i].color = Color.black;
            }
            
            
        }
    }

    public void IncreaseHeart()
    {
        playerHeart++;
    }

    public void DecreaseHeart()
    {
        playerHeart--;
    }

    void TaskOnClick()
    {
        DecreaseHeart();
        Debug.Log("Clicked Play");
    }

    public void GainHeartFromAds()
    {
        playerHeart = 3;
    }


}
