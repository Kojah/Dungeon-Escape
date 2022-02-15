using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance 
    {
        get 
        {
            if(instance == null)
            {
                Debug.LogError("UIManager is null");
            }

            return instance;
        }
    }

    public Text playerGemCountText = default;
    public Image selectionImage = default;

    public void openShop(int gemCount)
    {
        playerGemCountText.text = $"{gemCount}G";
    }

    public void updateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    private void Awake()
    {
        instance = this;
    }
}
