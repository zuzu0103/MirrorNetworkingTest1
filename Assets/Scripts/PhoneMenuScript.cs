using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PhoneMenuScript : MonoBehaviour
{

    public Button buttonClient;
    public InputField inputFieldAddress;


    void Start()
    {
        if (NetworkManager.singleton.networkAddress != "localhost") { inputFieldAddress.text = NetworkManager.singleton.networkAddress; }
        inputFieldAddress.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        buttonClient.onClick.AddListener(ButtonClient);
    }


    public void ValueChangeCheck()
    {
        NetworkManager.singleton.networkAddress = inputFieldAddress.text;
    }


    public void ButtonClient()
    {
        NetworkManager.singleton.StartClient();
    }
}