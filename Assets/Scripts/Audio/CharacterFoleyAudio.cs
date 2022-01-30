using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class CharacterFoleyAudio : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _footStepAudioClips;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomFootstep()
    {
        var audioToBePlayed = _footStepAudioClips[Random.Range(0, _footStepAudioClips.Count - 1)];
        _audioSource.PlayOneShot(audioToBePlayed);
    }
}
