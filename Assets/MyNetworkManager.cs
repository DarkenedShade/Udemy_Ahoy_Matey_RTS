using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager
{

    public void MyStartHost()
    {
        base.StartHost();
        Debug.Log("Starting Host at " + Time.timeSinceLevelLoad);
    }

    public override void OnStartHost()
    {
        base.OnStartHost();

        Debug.Log("Host Started at " + Time.timeSinceLevelLoad);
    }
}
