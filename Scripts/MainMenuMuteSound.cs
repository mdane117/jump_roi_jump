using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMuteSound : MonoBehaviour
{
    [SerializeField] AudioSource MusicPlayer;
    [SerializeField] AudioPlayerMenu AudioPlayer;
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
        }
        else
        {
            AudioPlayer.clickVolume = 0.75f;
        }
    }

    public void MutePressed()
    {
        isMuted = !isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
        if(isMuted)
        {
            AudioPlayer.clickVolume = 0f;
        }
        else
        {
            AudioPlayer.clickVolume = 0.75f;
        }
    }

    public void MuteMusic()
    {
        isMusicMuted = !isMusicMuted;
        MusicPlayer.mute = isMusicMuted;
        PlayerPrefs.SetInt("MUTEDMUSIC", isMusicMuted ? 1 : 0);
    }
}
