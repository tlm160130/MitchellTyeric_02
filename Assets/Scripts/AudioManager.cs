using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip _startingSong;

    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get { return instance; }
    }

    AudioSource _audioSource;

    private void Start()
    {
        if (_startingSong != null)
        {
            AudioManager.Instance.PlaySong(_startingSong);
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            //doesn't exist yet, this is now our singleton!
            instance = this;
            DontDestroyOnLoad(gameObject);
            //fill references
            _audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlaySong(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
