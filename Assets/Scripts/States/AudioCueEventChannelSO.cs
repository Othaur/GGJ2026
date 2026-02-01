using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "MyEvents/AudioCue Event Channel")]
public class AudioCueEventChannelSO : ScriptableObject
{
    public UnityAction<AudioCueSO, AudioMixerGroup, Vector3> OnAudioCueRequested;

    public void RaiseEvent(AudioCueSO audioCue, AudioMixerGroup audioGroup, Vector3 position)
    {
        if (OnAudioCueRequested != null)
        {
            OnAudioCueRequested.Invoke(audioCue, audioGroup, position);
        }
        else
        {
            Debug.LogWarning("An audio cue was requeted but nobody picked it up");
        }
    }


}
