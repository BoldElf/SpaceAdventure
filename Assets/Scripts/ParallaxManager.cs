using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> parallaxElements = new List<GameObject>();

    [SerializeField] private float offset = 0.1f;

    private List<Material> _parallaxMaterials = new List<Material>();

    private float _offset;


    private void Start()
    {
        foreach(GameObject parallaxElement in parallaxElements)
        {
            
            if (parallaxElement.GetComponent<Renderer>().material != null)
            {
                _parallaxMaterials.Add(parallaxElement.GetComponent<Renderer>().material);
            }
            else
            {
                Debug.Log("Wrong parallaxElement!");
            }
        }
    }

    private void Update()
    {
        _offset += offset * Time.deltaTime;

        for (int i = 0; i < _parallaxMaterials.Count; i++)
        {
            _parallaxMaterials[i].mainTextureOffset = new Vector2(0, _offset);
        }
    }
}
