using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public static Dialogue instance;

    //Static HUD GUI elements
    [System.Serializable]
    public class DialogueReferences
    {
        public Canvas dialogueBox;
        public Text dialogueText;
        public Text nameText;
    };
    public DialogueReferences dialogueBox;

    void Awake()
    {
        // hostile singleton
        if (instance)
        {
            Debug.Log("Destroying irrelevant GameController instance");
            Destroy(instance.gameObject);
        }

        instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        
    }
    
    // Update is called once per frame
    void Update ()
    {
        
    }

    public void SetText(string name)
    {
        dialogueBox.dialogueText.text = name;
    }
}
