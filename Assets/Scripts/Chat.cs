using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : ScriptableObject
{
    [System.Serializable]
    public class Command
    {
        [TextArea(3, 10)]
        [Multiline]
        public string dialogueText;
        public string speakerName;
        public GameObject leftCharacter;
        public Character.Animations leftExpression;
        public GameObject rightCharacter;
        public Character.Animations rightExpression;
    };

    public Sprite background;
    public AudioClip music;
    public List<Command> chatCommands = new List<Command>();
}
