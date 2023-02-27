using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Button Click")]
    [SerializeField] AudioClip buttonClick;
    [SerializeField] [Range(0f, 1f)] public float clickVolume = 1f;

    [Header("Jump")]
    [SerializeField] AudioClip jumpSound;
    [SerializeField] [Range(0f, 1f)] public float jumpVolume = 1f;

    [Header("Death")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0f, 1f)] public float deathVolume = 1f;

    [Header("Lava")]
    [SerializeField] AudioClip lavaSound;
    [SerializeField] [Range(0f, 1f)] public float lavaVolume = 1f;

    [Header("Meteor")]
    [SerializeField] AudioClip meteorSound;
    [SerializeField] [Range(0f, 1f)] public float meteorVolume = 1f;

    [Header("Spikes")]
    [SerializeField] AudioClip spikeSound;
    [SerializeField] [Range(0f, 1f)] public float spikeVolume = 1f;

    [Header("Steak Pickup")]
    [SerializeField] AudioClip steakPickupSound;
    [SerializeField] [Range(0f, 1f)] public float steakPickupVolume = 1f;
    
    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);       
        }
    }
    public void PlayButtonClick()
    {
        PlayClip(buttonClick, clickVolume);
    }

    public void PlayJumpSound()
    {
        PlayClip(jumpSound, jumpVolume * 1.5f);
    }

    public void PlayDeathSound()
    {
        PlayClip(deathSound, deathVolume);
    }

    public void PlaySteakPickupSound()
    {
        PlayClip(steakPickupSound, steakPickupVolume);
    }

    public void PlayLavaSound()
    {
        PlayClip(lavaSound, lavaVolume);
    }

    public void PlayMeteorSound()
    {
        PlayClip(meteorSound, meteorVolume);
    }

    public void PlaySpikeSound()
    {
        PlayClip(spikeSound, spikeVolume);
    }
}
