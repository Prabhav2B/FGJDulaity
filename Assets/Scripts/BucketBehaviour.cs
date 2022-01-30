using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketBehaviour : MonoBehaviour
{
    private bool _isWaterFilled;

    private Transform _playerTransform;
    [SerializeField] private GameObject _spriteGameObject;
    private SpriteRenderer _waterSprite;
    private BoundryDetection _boundryDetection;

    // Start is called before the first frame update
    void Start()
    {
        _isWaterFilled = false;

        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _waterSprite = _spriteGameObject.GetComponent<SpriteRenderer>();
        _boundryDetection = FindObjectOfType<BoundryDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_playerTransform.position.x, _playerTransform.transform.position.y + 3f, transform.position.z);

        if (_boundryDetection.stopMovingRight && !_waterSprite.enabled && !_isWaterFilled)
        {
            _isWaterFilled = true;
            _waterSprite.enabled = true;
        }

        if (_boundryDetection.stopMovingLeft && _waterSprite.enabled && _isWaterFilled)
        {
            _isWaterFilled = false;
            _waterSprite.enabled = false;
        }
    }
}
