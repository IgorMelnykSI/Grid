using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;

    // Player currencies data
    public TMP_Text GoldValue;
    public TMP_Text SilverValue;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetVirtualsCurrencies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetVirtualsCurrencies()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySucces, OnError);
    }

    void OnGetUserInventorySucces(GetUserInventoryResult result)
    {
        int silver = result.VirtualCurrency["SL"];
        SilverValue.SetText(silver.ToString());

        int gold = result.VirtualCurrency["GD"];
        GoldValue.SetText(gold.ToString());
    }

    void OnError(PlayFabError error)
    {
        // Error to retrieve data
        Debug.Log("Data recuperation error !!!");
    }
}
