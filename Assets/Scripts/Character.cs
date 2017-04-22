using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Character : MonoBehaviour {

    [System.Serializable]
    public enum Animations
    {
        NEUTRAL,
        HAPPY,
        SAD,
        ANGRY,
        CONFUSED,
        IN_PAIN,
        SPECIAL1,
        SPECIAL2,
        SPECIAL3
    };
    public string name;
    public Sprite[] emotions;
    public Soundbank voiceSounds;
    private Vector2 voiceDisplacementVector;
    private Vector2 initialPosition;

    // Use this for initialization
    void Start ()
    {
        Vector4 color = GetComponent<SpriteRenderer>().color;
        color.w = 0.0f;
        GetComponent<SpriteRenderer>().color = color;
        voiceDisplacementVector = new Vector2(0.0f, 0.0f);
        initialPosition = transform.localPosition;
    }
    
    // Update is called once per frame
    void Update ()
    {
        Vector4 color = GetComponent<SpriteRenderer>().color;
        color.w = Mathf.Lerp(GetComponent<SpriteRenderer>().color.a, 1.0f, 0.05f);
        GetComponent<SpriteRenderer>().color = color;

        voiceDisplacementVector *= 0.9f;
        transform.localPosition = initialPosition + voiceDisplacementVector;
    }

    public void PlayVoice()
    {
        if (voiceSounds.TrackList.Length > 0)
        {
            int index = Random.Range(0, voiceSounds.TrackList.Length);
            if (voiceSounds.TrackList[index] != null)
            {
                Dialogue.instance.GetComponent<AudioSource>().clip = voiceSounds.TrackList[index].sample;
                Dialogue.instance.GetComponent<AudioSource>().Play();
                voiceDisplacementVector += new Vector2(Random.Range(-0.05f, 0.05f), Random.Range(0.2f, 0.4f));
            }
        }
    }
}
