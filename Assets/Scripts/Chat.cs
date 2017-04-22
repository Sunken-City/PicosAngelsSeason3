using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : ScriptableObject
{
    [System.Serializable]
    public class Command
    {
        public string characterName;
        public string dialogueText;
    };

    public Command[] chatCommands;
}
