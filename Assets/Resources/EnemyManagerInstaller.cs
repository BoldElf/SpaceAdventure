using UnityEngine;
using Zenject;

public class EnemyManagerInstaller : MonoInstaller
{
    [SerializeField] private EnemyManager enemyManager;
    public override void InstallBindings()
    {
        Container.Bind<EnemyManager>().FromInstance(enemyManager).AsSingle();
    }
}