using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager
{

    public void MyStartHost()
    {
        base.StartHost();
        Debug.Log(Time.timeSinceLevelLoad + " Starting Host.");
    }

    public override void OnStartHost()
    {
        base.OnStartHost();

        Debug.Log(Time.timeSinceLevelLoad + " Host Started.");
    }

    public override void OnStartClient(NetworkClient startedClient)
    {
        base.OnStartClient(startedClient);

        Debug.Log(Time.timeSinceLevelLoad +  " Client start requested.");

        InvokeRepeating("PrintDots", 0f, 1f);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

        Debug.Log(Time.timeSinceLevelLoad + " Client is connected to IP: " + conn.address);

        CancelInvoke("PrintDots");
    }

    private void PrintDots()
    {
        Debug.Log(".");
    }
}
