using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource LobbyMusic;
    public AudioSource MandrakeSound;

    private List<AudioSource> _soundEffects;
    private List<AudioSource> _music;
    
    public void Start()
    {
        _soundEffects = new List<AudioSource>()
        {
           MandrakeSound,
        };

        _music = new List<AudioSource>()
        {
            LobbyMusic,
        };
    }
}