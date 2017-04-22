using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

[System.Serializable]
public class AudioSample
{
    public AudioClip sample;

    //[Range(0.0f, 1.0f)]
    //public float volume = 1.0f;
    //[Range(-1.0f, 1.0f)]
    //public float pan = 0.0f;
    //[Range(-3.0f, 3.0f)]
    //public float pitch = 1.0f;
    public int weight = 1;
}

public class Soundbank : ScriptableObject
{
    public AudioSample[] TrackList;
}

