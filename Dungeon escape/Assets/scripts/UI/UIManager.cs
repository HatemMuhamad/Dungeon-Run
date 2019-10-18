using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("UI manager is null");
            }
            return _instance;
        }
    }
    public Text PlayerGemCountText;
    public Image selectionImg;
    public Text GemCountText;
    public Image[] lifeUnits;

    public void UpdateShopSelection(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
    }
    public void OpenShop(int gemCount)
    {
        PlayerGemCountText.text = "" + gemCount + "G";
    }
    private void Awake()
    {
        _instance = this;
    }
    public void UpdateGemCount(int gemCount)
    {
        GemCountText.text = "" + gemCount;
    }
    public void UpdateLives(int livesRemaining)
    {
        for(int i = 0; i<4; i++)
        {
            if(i == livesRemaining)
            {
                lifeUnits[i].enabled = false;
            }
        }
    }
}
