using UnityEngine;
using Zenject;

public class AudioInstallerManager : MonoInstaller
{
    [SerializeField] GameObject prefab;
    public override void InstallBindings()
    {
        Container.Bind< AudioManager >().FromComponentInNewPrefab(prefab).AsSingle();
    }
}