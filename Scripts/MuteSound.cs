using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSound : MonoBehaviour
{
    [SerializeField] AudioSource MusicPlayer;
    [SerializeField] AudioPlayer AudioPlayer;
    private bool isMuted;
    private bool isMusicMuted;
    private void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
        isMusicMuted = PlayerPrefs.GetInt("MUTEDMUSIC") == 1;
        MusicPlayer.mute = isMusicMuted;
        if(isMuted)
        {
            AudioPlayer.clickVolume = 0f;
            AudioPlayer.jumpVolume = 0f;
            AudioPlayer.deathVolume = 0f;
            AudioPlayer.lavaVolume = 0f;
            AudioPlayer.spikeVolume = 0f;
            AudioPlayer.steakPickupVolume = 0f;
        }
        else
        {
            AudioPlayer.clickVolume = 0.75f;
            AudioPlayer.jumpVolume = 1f;
            AudioPlayer.deathVolume = 1f;
            AudioPlayer.lavaVolume = 0.75f;
            AudioPlayer.spikeVolume = 1f;
            AudioPlayer.steakPickupVolume = 0.75f;
        }
    }

    public void MutePressed()
    {
        isMuted = !isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
        if(isMuted)
        {
            AudioPlayer.clickVolume = 0f;
            AudioPlayer.jumpVolume = 0f;
            AudioPlayer.deathVolume = 0f;
            AudioPlayer.lavaVolume = 0f;
            AudioPlayer.spikeVolume = 0f;
            AudioPlayer.steakPickupVolume = 0f;
        }
        else
        {
            AudioPlayer.clickVolume = 0.75f;
            AudioPlayer.jumpVolume = 1f;
            AudioPlayer.deathVolume = 1f;
            AudioPlayer.lavaVolume = 0.75f;
            AudioPlayer.spikeVolume = 1f;
            AudioPlayer.steakPickupVolume = 0.75f;
        }
    }

    public void MuteMusic()
    {
        isMusicMuted = !isMusicMuted;
        MusicPlayer.mute = isMusicMuted;
        PlayerPrefs.SetInt("MUTEDMUSIC", isMusicMuted ? 1 : 0);
    }
}
