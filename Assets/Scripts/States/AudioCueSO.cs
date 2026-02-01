using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Audio/Audio Cue")]
public class AudioCueSO : ScriptableObject
{
    public bool looping = false;
    public AudioClip clip;

    public AudioClip GetClip()
    {
        return clip;
    }

}
