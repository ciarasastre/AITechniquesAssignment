using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MusicState : MonoBehaviour
{

    public AudioClip morningSong;
    public AudioClip beeSong;
    public AudioClip nightSong;

    public enum State
    {
        MORNING,
        BEE,
        NIGHT
    }

    public State state;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource song = GetComponent<AudioSource>();
        song.clip = morningSong;
        song.Play();


        state = MusicState.State.MORNING;
    }

    // Update is called once per frame
    void Update()
    {
        state = MusicState.State.MORNING;
    }

    IEnumerator FSM()
    {
        switch (state)
        {
            case State.MORNING:
                MorningMusic();
                break;

            case State.BEE:
                BeeMusic();
                break;

            case State.NIGHT:
                NightMusic();
                break;
        }

        yield return null;
    }

    void MorningMusic()
    {
        /* Does not work here find out why:
        AudioSource song = GetComponent<AudioSource>();
        song.clip = morningSong;
        song.Play();*/
    }

    void BeeMusic()
    {
        /*Pause any other songs
        morningSong.Pause();
        nightSong.Pause();
        
        beeSong = GetComponent<AudioSource>();
        beeSong.Play(0);*/
    }

    void NightMusic()
    {
        //Pause any other songs
        //morningSong.Pause();
        //beeSong.Pause();

        //Then play song
        //nightSong = GetComponent<AudioSource>();
        //nightSong.Play(0);
        //Debug.Log("started");
    }
}
