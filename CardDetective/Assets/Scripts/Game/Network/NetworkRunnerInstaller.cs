using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class NetworkRunnerInstaller : MonoInstaller
{
    [SerializeField] private NetworkRunner _runnerPrefab;

    public override void InstallBindings()
    {
        NetworkRunner runner = Container.InstantiatePrefabForComponent<NetworkRunner>(_runnerPrefab);
        Container.Bind<NetworkRunner>().FromInstance(runner).AsSingle().NonLazy();

        LobbyHandler handler = new(runner);
        Container.Bind<LobbyHandler>().FromInstance(handler).AsSingle().NonLazy();
    }
}
