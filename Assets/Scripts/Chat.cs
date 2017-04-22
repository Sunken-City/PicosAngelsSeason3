using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : ScriptableObject
{
    [System.Serializable]
    public class Command
    {
        public string characterName;
        [TextArea(3, 10)]
        [Multiline]
        public string dialogueText;
    };

    public List<Command> chatCommands = new List<Command>();
}
