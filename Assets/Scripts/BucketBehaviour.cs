using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketBehaviour : MonoBehaviour
{

    [SerializeField] private AudioClip fillWaterSFX;
    [SerializeField] private AudioClip douseWaterSFX;
    
    private bool _isWaterFilled;

    private Transform _playerTransform;
    [SerializeField] private GameObject _spriteGameObject;
    private SpriteRenderer _waterSprite;
    private BoundryDetection _boundryDetection;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _isWaterFilled = false;

        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _waterSprite = _spriteGameObject.GetComponent<SpriteRenderer>();
        _boundryDetection = FindObjectOfType<BoundryDetection>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_playerTransform.position.x, _playerTransform.transform.position.y + 3f, transform.position.z);

        if (_boundryDetection.stopMovingRight && !_waterSprite.enabled && !_isWaterFilled)
        {
            _isWaterFilled = true;
            _waterSprite.enabled = true;
            _audioSource.PlayOneShot(fillWaterSFX);
        }

        if (_boundryDetection.stopMovingLeft && _waterSprite.enabled && _isWaterFilled)
        {
            _isWaterFilled = false;
            _waterSprite.enabled = false;
            _audioSource.PlayOneShot(douseWaterSFX);
        }
    }
}
