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
    public Text playerGemCountHUD = default;
    public Image selectionImage = default;
    private void Awake()
    {
        instance = this;
    }

    public void openShop(int gemCount)
    {
        playerGemCountText.text = $"{gemCount}G";
    }

    public void updateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int gems)
    {
        playerGemCountHUD.text = $"{gems}";
    }
}
