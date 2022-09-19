using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScreenManager : MonoBehaviour
{
    public Canvas loginScreen;
    public Canvas registerScreen;

    private void Start()
    {
        registerScreen.GetComponent<Canvas>().enabled = false;
    }

    public void goToRegisterScreen()
    {
        loginScreen.GetComponent<Canvas>().enabled = false;
        registerScreen.GetComponent<Canvas>().enabled = true;
    }

}
