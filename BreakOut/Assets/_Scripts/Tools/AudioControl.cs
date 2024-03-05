using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class AudioControl : MonoBehaviour
{
    public Opciones opciones;
    public AudioSource BGM;
    public AudioSource SFX;
    public AudioClip[] clips;

    void Start()
    {
        UpdateSound();
    }
    private void Update()
    {
        UpdateSound();
    }
    private void UpdateSound()
    {
        BGM.volume = DecibelToLinear(opciones.VolumenMusica);
        SFX.volume = DecibelToLinear(opciones.VolumenSonido);
    }
    private void PlayBGM(AudioClip clip)
    {
        BGM.clip = clip;
        BGM.Play();
    }
    public void PlaySoundEffect(string nameClip)
    {
        var objClips = (from x in clips where x.name == nameClip select x).ToList();
        if (objClips.Count > 0)
        {
            PlaySoundEffect(objClips.First());
        }
    }
    public void PlaySoundEffect(AudioClip clip)
    {
        SFX.clip = clip;
        SFX.Play();
    }
    private float LinearToDecibel(float linear)
    {
        float dB;
        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;
        return dB;
    }
    private float DecibelToLinear(float dB)
    {
        if (dB == -80f) return 0;
        float linear = Mathf.Pow(10.0f, dB / 20.0f);
        return linear;
    }
}