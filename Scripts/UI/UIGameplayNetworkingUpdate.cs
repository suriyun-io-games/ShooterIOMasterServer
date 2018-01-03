using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(UIGameplay))]
public class UIGameplayNetworkingUpdate : MonoBehaviour {
    bool networkStatus;
    UIGameplay uiGameplay;
    private void Awake()
    {
        uiGameplay = GetComponent<UIGameplay>();
    }

    private void Update()
    {
        var newNetworkStatus = NetworkManager.singleton.isNetworkActive;
        if (networkStatus != newNetworkStatus)
        {
            foreach (var hidingIfDedicateUi in uiGameplay.hidingIfDedicateServerUis)
            {
                hidingIfDedicateUi.SetActive(!NetworkServer.active || NetworkServer.localClientActive);
            }
            networkStatus = newNetworkStatus;
        }
    }
}
