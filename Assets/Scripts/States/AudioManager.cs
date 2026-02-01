using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioCueEventChannelSO sfxChannel;
    public AudioCueEventChannelSO musicChannel;
    
    public GameObject soundPlaceHolder;
    public GameObject musicPlaceHolder;
    

    private void Awake()
    {
        soundPlaceHolder = new GameObject();
        soundPlaceHolder.name = "SoundHolder";
        soundPlaceHolder.transform.parent = transform;

        musicPlaceHolder = new GameObject();
        musicPlaceHolder.name = "MusicHolder";
        musicPlaceHolder.transform.parent = transform;
               
        sfxChannel.OnAudioCueRequested += PlayFXAudioCue;
        musicChannel.OnAudioCueRequested += PlayMusicAudioCue;
       
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayFXAudioCue(AudioCueSO cue, AudioMixerGroup group, Vector3 position)
    {
        AudioSource emitter = soundPlaceHolder.AddComponent<AudioSource>();

        emitter.clip = cue.clip;
        emitter.outputAudioMixerGroup = group;
        emitter.transform.position = position;
        emitter.Play();

        StartCoroutine(FinishPlayingFX(cue.clip.length));
    }

    public void PlayMusicAudioCue(AudioCueSO cue, AudioMixerGroup group, Vector3 position)
    {
        AudioSource emitter = musicPlaceHolder.AddComponent<AudioSource>();

        emitter.clip = cue.clip;
        emitter.outputAudioMixerGroup = group;
        emitter.transform.position = position;
        emitter.loop = cue.looping;
        emitter.Play();

        StartCoroutine(PlayLoopingSound(cue.clip));
    }

   
    IEnumerator FinishPlayingFX(float length)
    {
        yield return new WaitForSeconds(length);

        var aSource = soundPlaceHolder.GetComponents<AudioSource>();

        for (int i = 0; i < aSource.Length; i++)
        {
            if (!aSource[i].isPlaying)
            {
                Destroy(aSource[i]);
            }
        }
    }

    IEnumerator FinishPlayingMusic(float length)
    {
        yield return new WaitForSeconds(length);

        var aSource = musicPlaceHolder.GetComponents<AudioSource>();

        for (int i = 0; i < aSource.Length; i++)
        {
            Debug.Log("Audio source: ");
            if (!aSource[i].isPlaying)
            {
                Destroy(aSource[i]);
            }
        }
    }

    IEnumerator PlayLoopingSound(AudioClip clip)
    {
        while (1 == 1)
        {
            yield return new WaitForSeconds(clip.length);
            //AudioSource aSource = musicPlaceHolder.GetComponent<AudioSource>();
            //aSource.PlayOneShot(clip);
        }
    }
}
