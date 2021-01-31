using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource LobbyMusic;
    public AudioSource BookFlip;

    private List<AudioSource> _soundEffects;
    private List<AudioSource> _music;
    
    public void Start()
    {
        _soundEffects = new List<AudioSource>()
        {
           BookFlip,
        };

        _music = new List<AudioSource>()
        {
            LobbyMusic,
        };
    }
}