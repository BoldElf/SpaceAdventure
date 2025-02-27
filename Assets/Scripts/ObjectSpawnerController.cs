using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public class ObjectSpawnerController : MonoBehaviour
{
    [Inject] EnemyManager enemyManager;

    [SerializeField] private List<GameObject> spawnZone = new List<GameObject>();

    [SerializeField] private float timeToSpawn = 5f;

    private List<float> _pointsNumber = new List<float>();

    private PoolObject currentObject;

    private float currentNumber;

    private int randomNumber;

    private int spawnPoint;

    private bool needNumber = true;

    private bool needSpawn = false;
    private float needSpawnTimer = 0f;

    

    private void Update()
    {
        spawnController();
    }

    private void randomPointChoise()
    {
        randomNumber = Random.Range(0, 100);

        for (int i = 0; i < spawnZone.Count; i++)
        {
            if (_pointsNumber.Count == 0)
            {
                _pointsNumber.Add(100 / spawnZone.Count);
            }
            else
            {
                for (int a = 0; a < _pointsNumber.Count; a++)
                {
                    currentNumber = currentNumber + _pointsNumber[a];
                }

                _pointsNumber.Add(currentNumber);
                currentNumber = 0;
            }
        }

        for(int i = 1; i < _pointsNumber.Count + 1;i++)
        {
            if(randomNumber <= _pointsNumber[0] * i && needNumber == true)
            {
                spawnPoint = i - 1;
                needNumber = false;
            }
        }
     
        needNumber = true;
        //Debug.Log(randomNumber + " RandomNumber");
        //Debug.Log(spawnPoint + " SpawnPoint");

    }

    private void spawnObject()
    {
        randomPointChoise();

        //currentObject = enemyManager.spawnEnemyObject(EnemyType.Asteroid);
        //currentObject.transform.position = spawnZone[spawnPoint].transform.position;

        currentObject = enemyManager.spawnEnemyObject(EnemyType.Asteroid, spawnZone[spawnPoint].transform.position);
        //currentObject.transform.position = spawnZone[spawnPoint].transform.position;
    }

    private void spawnController()
    {
        if(needSpawnTimer >= timeToSpawn)
        {
            needSpawn = true;
        }
        else
        {
            needSpawnTimer += Time.deltaTime;
        }

        if(needSpawn == true)
        {
            spawnObject();
            needSpawnTimer = 0;
            needSpawn = false;
        }  
    }
}
