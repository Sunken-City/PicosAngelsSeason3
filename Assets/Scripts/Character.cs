using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        
    }
}
