using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private PoolObject _poolObject; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<PoolObject>(out _poolObject) == true)
        {
            _poolObject.ReturnToPool();
        }
    }
}
