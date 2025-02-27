using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float objectSpeed;
    
    void Update()
    {
        movment();
    }

    private void movment()
    {
        gameObject.transform.position -= new Vector3(0,objectSpeed * Time.deltaTime, 0);
    }
}
