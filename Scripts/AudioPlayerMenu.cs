using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerMenu : MonoBehaviour
{
    [Header("Button Click")]
    [SerializeField] AudioClip buttonClick;
    [SerializeField] [Range(0f, 1f)] public float clickVolume = 1f;

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
}
