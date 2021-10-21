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


public class NetworkManagerScript : NetworkManager
{

    public GameObject phonePlayerPrefab;

    public NetworkConnection serverConn;
    public NetworkConnection clientConn;


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
            gameobject = Instantiate(phonePlayerPrefab);
            clientConn = conn;
        }
        else
        {
            gameobject = Instantiate(playerPrefab);
            serverConn = conn;
            Debug.Log("Server Conn Established");
        }

        Debug.Log("Added Player For Connection");
        NetworkServer.AddPlayerForConnection(conn, gameobject);
    }
}