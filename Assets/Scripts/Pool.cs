using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class Pool : MonoBehaviour
{
    [Inject] DiContainer container;

    [SerializeField] private PoolObject _prefab;
    [SerializeField] private Transform _container;

    [SerializeField] private int _minCapacity;
    [SerializeField] private int _maxCapacity;

    [SerializeField] private bool _isExpend; 

    private List<PoolObject> _pool;



    private void Start()
    {
        if (_isExpend == true)
        {
            _maxCapacity = Int32.MaxValue;
        }

        creatPool();
    }

    private void creatPool()
    {
        _pool = new List<PoolObject>(_minCapacity);

        for(int i = 0; i < _minCapacity;i++)
        {
            creatElement();
        }
    }

    private PoolObject creatElement(bool isActiveByDefault = false)
    {
        //var createdObject = container.InstantiatePrefab(_prefab, _container);
        var createdObject = Instantiate(_prefab, _container);
        createdObject.gameObject.SetActive(isActiveByDefault);

        _pool.Add(createdObject);
        return createdObject;
    }

    public bool TryGetElement(out PoolObject element)
    {
        foreach(var item in _pool)
        {
            if(item.gameObject.activeInHierarchy == false)
            {
                element = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public PoolObject GetFreeElement()
    {
        if(TryGetElement(out var element) == true)
        {
            return element;
        }

        if(_isExpend == true)
        {
            return creatElement(true);
        }

        if(_pool.Count < _maxCapacity)
        {
            return creatElement(true);
        }

        throw new Exception("Pool is over");
    }

    public PoolObject GetFreeElement(Vector3 position)
    {
        var element = GetFreeElement();
        element.transform.position = position;
        return element;
    }

    public PoolObject GetFreeElement(Vector3 position, Quaternion rotation)
    {
        var element = GetFreeElement(position);
        element.transform.rotation = rotation;
        return element;
    }
}
