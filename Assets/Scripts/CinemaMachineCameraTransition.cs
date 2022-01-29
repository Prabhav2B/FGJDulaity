using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(BoxCollider2D))]
public class CinemaMachineCameraTransition : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _toCam;
    private CinemachineVirtualCamera _fromCam;

    private CinemachineBrain _brain;

    // Start is called before the first frame update
    void Start()
    {
        _brain = CinemachineCore.Instance.GetActiveBrain(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _fromCam = _brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        _fromCam.gameObject.SetActive(false);
        _toCam.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _fromCam.gameObject.SetActive(true);
        _toCam.gameObject.SetActive(false);
    }
}
