using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PlayerMenuScript : MonoBehaviour
{
    
    public Button buttonHost;


    public void Start()
    {
        buttonHost.onClick.AddListener(ButtonHost);
    }


    public void ButtonHost()
    {
        NetworkManager.singleton.StartHost();
    }
}