using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioCue : MonoBehaviour
{
    public AudioCueSO audioCue = default;

    public AudioCueEventChannelSO audioCueEventChannel = default;
    public AudioMixerGroup audioGroup = default;

    public void PlayAudioCue()
    {
        Debug.Log("Launching play event");
        audioCueEventChannel.RaiseEvent(audioCue, audioGroup, transform.position);
    }


}
