using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameNetworkManagerWithMsf : GameNetworkManager
{
    public new void StartDedicateServer()
    {
        // Do nothing
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        var ioGamesRoom = FindObjectOfType<IOGamesRoom>();
        if (ioGamesRoom != null)
            ioGamesRoom.ClientDisconnected(conn);
        var character = conn.playerControllers[0].gameObject.GetComponent<CharacterEntity>();
        GameplayManager.Singleton.characters.Remove(character);
        NetworkServer.DestroyPlayersForConnection(conn);
    }
}
