using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{
    public Text messageText;
    public Text messageRegText;
    public InputField mailInput;
    public InputField passwordInput;

    public InputField mailRegInput;
    public InputField passwordRegInput;
    public InputField userName;

    public void RegisterButton()
    {
        if (passwordRegInput.text.Length < 6)
        {
            messageRegText.text = "Too short password!";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Email = mailRegInput.text,
            Password = passwordRegInput.text,
            DisplayName = userName.text,
            Username = userName.text,
            RequireBothUsernameAndEmail = true
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSucces, OnError);
    }

    private void OnRegisterSucces(RegisterPlayFabUserResult obj)
    {
        messageRegText.text = "Registered and Logged in";
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = mailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSucces, OnError);
    }

    private void OnLoginSucces(LoginResult result)
    {
        messageText.text = "logged in!"; 
    }

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = mailInput.text,
            TitleId = "626DC"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset mail sent!";
    }

    

    void OnError(PlayFabError err)
    {
        messageText.text = err.ErrorMessage;
        messageRegText.text = "Error to register!";
        Debug.Log("Error to login");
        Debug.Log(err.GenerateErrorReport());
    }
}
