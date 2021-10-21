using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Net;
using System.Net.Sockets;

public class ReadyMenuScript : MonoBehaviour
{
    
    public Button buttonHost;
    public Text textBox;
    public Text ipBox;
    

    void Start()
    {
        buttonHost.onClick.AddListener(ButtonHost);
        ipBox.text = LocalIPAddress();
    }


    void Update()
    {
        if (NetworkServer.connections.Count != 2)
        {
            buttonHost.interactable = false;
            textBox.text = "Waiting for Phone Connection";
        }
        else
        {
            buttonHost.interactable = true;
            textBox.text = "Phone Connection Established";
        }
    }


    public void ButtonHost()
    {
        NetworkClient.Ready();
        if (NetworkClient.localPlayer == null)
        {
            NetworkClient.AddPlayer();
        }
        Destroy(this.gameObject);
    }


    public static string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "0.0.0.0";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }
}