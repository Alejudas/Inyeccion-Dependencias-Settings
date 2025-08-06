using UnityEngine;
using Zenject;

public class DisplaySettingsManagerInstaller : MonoInstaller
{
    [SerializeField] GameObject prefab;
    public override void InstallBindings()
    {
        Container.Bind<DisplaySettingsmanager>().FromComponentInNewPrefab(prefab).AsSingle();

    }
}