using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public enum EnemyType
{
    Asteroid,
    UFO
}
[RequireComponent(typeof(Pool))]
public class EnemyManager : MonoBehaviour
{
    [Inject] DiContainer container;

    [SerializeField] private List<GameObject> Asteroids = new List<GameObject>();

    //private List<GameObject> AsteroidOnScene = new List<GameObject>();
    private List<PoolObject> AsteroidOnScene = new List<PoolObject>();

    private GameObject asteroid;
    //private GameObject currentObject;
    private PoolObject currentObject;

    private Pool _poolAsteroid;

    private void Start()
    {
        _poolAsteroid = GetComponent<Pool>();
    }

    public PoolObject spawnEnemyObject(EnemyType type, Vector3 position)
    {
        asteroid = Asteroids[0];

        if (type == EnemyType.Asteroid)
        {
            //AsteroidOnScene.Add(currentObject = container.InstantiatePrefab(asteroid));
            AsteroidOnScene.Add(currentObject = _poolAsteroid.GetFreeElement(position));
        }

        return currentObject;
    }
}
