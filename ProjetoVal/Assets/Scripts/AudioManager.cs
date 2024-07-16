using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource MusicaSource;
    public AudioSource SFXSource;
    public AudioClip SFXTiro;
    public AudioClip SFXColetar;
    public AudioClip SFXMorte;
    public AudioClip SFXDano;
    public AudioClip SFXDanoInimigo;

    public void SFXManager(AudioClip sfxClip, float volume)
    {
        SFXSource.PlayOneShot(sfxClip, volume);
       
    }
}
