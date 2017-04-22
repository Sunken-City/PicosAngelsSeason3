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
    public GameObject leftCharacter;

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

    public void SetText(string dialogText)
    {
        dialogueBox.dialogueText.text = dialogText;
    }

    public void SetCharacterName(string characterName)
    {
        dialogueBox.nameText.text = characterName;
    }

    public void ApplyCommand(Chat.Command cmd)
    {
        if (!string.IsNullOrEmpty(cmd.dialogueText))
        {
            SetText(cmd.dialogueText);
        }
        if(cmd.leftCharacter)
        {
            if (leftCharacter)
            {
                Destroy(leftCharacter);
            }
            leftCharacter = Instantiate(cmd.leftCharacter);
            SetCharacterName(leftCharacter.GetComponent<Character>().name);
            leftCharacter.GetComponent<SpriteRenderer>().sprite = leftCharacter.GetComponent<Character>().emotions[(int)cmd.expression];
        }
    }
}
