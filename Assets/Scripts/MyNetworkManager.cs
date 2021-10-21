using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Mirror;


public struct CreatePlayerMessage : NetworkMessage
{
    public bool clientConnection;
}

public class MyNetworkManager : NetworkManager
{

    public GameObject mobilePlayerPrefab;


    public override void OnStartServer()
    {
        base.OnStartServer();
        Debug.Log("Server Started");

        NetworkServer.RegisterHandler<CreatePlayerMessage>(OnCreateCharacter);
    }


    public override void OnStopServer()
    {
        Debug.Log("Server Stopped");
    }


    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("Client Connected");
    }


    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Debug.Log("Disconnected from Server");
    }


    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        Debug.Log("Client Scene Change");
        base.OnClientSceneChanged(conn);

        CreatePlayerMessage playerMessage = new CreatePlayerMessage
        {
            clientConnection = true
        };

        conn.Send(playerMessage);

        SceneManager.LoadScene("ClientOnline", LoadSceneMode.Additive);
    }


    public override void OnServerSceneChanged(string name)
    {
        Debug.Log("Server Scene Change");
        SceneManager.LoadScene("ServerOnline", LoadSceneMode.Additive);
    }


    void OnCreateCharacter(NetworkConnection conn, CreatePlayerMessage message)
    {

        GameObject gameobject;

        if (message.clientConnection == true)
        {
            gameobject = Instantiate(mobilePlayerPrefab);
        }
        else
        {
            gameobject = Instantiate(playerPrefab);
        }


        NetworkServer.AddPlayerForConnection(conn, gameobject);
    }
}
