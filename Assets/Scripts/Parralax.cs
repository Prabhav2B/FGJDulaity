using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    Camera _camera;
    private float _length, _startpos;
    [SerializeField] float _parallaxEffect;

    void Start()
    {
        _camera = Camera.main;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float d = _camera.transform.position.x * _parallaxEffect;

        transform.position = new Vector3(d, transform.position.y, transform.position.z);
    }
}
