using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class ItemToBuy : MonoBehaviour
{
    public string itemName;
    public int silverPrice;


    public void BuyItem()
    {
        var request = new SubtractUserVirtualCurrencyRequest
        {
            VirtualCurrency = "SL",
            Amount = silverPrice
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubstractionSucces, OnError);
    }

    void OnSubstractionSucces(ModifyUserVirtualCurrencyResult result)
    {
        MainMenuManager.Instance.GetVirtualsCurrencies();
        Debug.Log("Item bought !!!");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Something went wrong or not enough on your account !!!");
    }
}
