using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public GameObject _shop_panel;
    public int currentSelectedItem;
    public int currentSelectedCost;
    Player player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
             player = other.GetComponent<Player>();
            if(player != null)
            {
                UIManager.Instance.OpenShop(player._diamonds);
            }
            _shop_panel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _shop_panel.SetActive(false);
        }
    }
    public void SelectItem(int item)
    {
        //0 = flame sword
        //1 = boots of light
        //2 = key to castle
        Debug.Log("SelectItem()"+ item);
        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(74);
                currentSelectedItem = 0;
                currentSelectedCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-32);
                currentSelectedItem = 1;
                currentSelectedCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-127);
                currentSelectedItem = 2;
                currentSelectedCost = 100;
                break;
        }
        
    }
    public void BuyItem()
    {
        if(player._diamonds >= currentSelectedCost)
        {
            if(currentSelectedItem == 2)
            {
                GameManager.Instance.hasKeyToCastle = true;
            }
            player._diamonds -= currentSelectedCost;
            Debug.Log("Item Awarded is:" + currentSelectedItem);
            _shop_panel.SetActive(false);
        }
        else
        {
            Debug.Log("Sorry you don't enough diamonds");
            _shop_panel.SetActive(false);
        }
    }
}
