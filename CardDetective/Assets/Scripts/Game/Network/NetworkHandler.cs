using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class NetworkHandler : AbstractNetworkBehaviour
{
    [Inject] private LobbyHandler _lobbyHandler;

    void Start()
    {
        _lobbyHandler.JoinToLobby();
    }

}
