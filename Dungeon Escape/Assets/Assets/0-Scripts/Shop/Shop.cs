using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel = default;
    public int currentSelectedItem = 0;
    public int currentItemCost = 0;

    Player playerRef = default;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerRef = other.GetComponent<Player>();
            if(playerRef != null)
            {
                UIManager.Instance.openShop(playerRef.diamonds);
            }
            currentSelectedItem = 2;
            currentItemCost = 100;
            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        currentSelectedItem = item;
        switch (item)
        {
            case 0:
                UIManager.Instance.updateShopSelection(75);
                currentItemCost = 200;
                break;
            case 1:
                UIManager.Instance.updateShopSelection(-35);
                currentItemCost = 400;
                break;
            case 2:
                UIManager.Instance.updateShopSelection(-145);
                currentItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if(playerRef.diamonds >= currentItemCost)
        {
            if(currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            playerRef.diamonds -= currentItemCost;
        }
        else
        {
            Debug.Log("Not enough gems.");
        }
        shopPanel.SetActive(false);
    }
}
