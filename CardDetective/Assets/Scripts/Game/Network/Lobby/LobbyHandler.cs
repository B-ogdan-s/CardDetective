using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyHandler
{
    private NetworkRunner _runner;

    public LobbyHandler(NetworkRunner runner)
    {
        _runner = runner;
    }

    public async void JoinToLobby()
    {
        Debug.Log($"Start connection");

        var result = await _runner.JoinSessionLobby(SessionLobby.ClientServer);

        if (result.Ok)
        {
            Debug.Log($"Complete connection");
        }
        else
        {
            Debug.LogError($"Failed to Start: {result.ShutdownReason}");
        }
    }

    public void CreateGame()
    {

    }
    public void JoinToGame()
    {

    }
}
