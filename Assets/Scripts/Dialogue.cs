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
        public GameObject background;
        public Canvas dialogueBox;
        public Text dialogueText;
        public Text nameText;
    };
    public DialogueReferences dialogueBox;
    public GameObject leftCharacter;
    public GameObject rightCharacter;
    
    private string m_currentDialogueText = "";
    private int m_currentProgressThroughString = 0;

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
        ++m_currentProgressThroughString;
        SetScrollingText();
        if (m_currentProgressThroughString % 2 == 0 && leftCharacter)
        {
            leftCharacter.GetComponent<Character>().PlayVoice();
        }
    }

    public void SetText(string dialogText)
    {
        m_currentDialogueText = dialogText;
        m_currentProgressThroughString = 0;
    }

    private void SetScrollingText()
    {
        int substring = Mathf.Min(m_currentDialogueText.Length, m_currentProgressThroughString / 2);
        dialogueBox.dialogueText.text = m_currentDialogueText.Substring(0, substring);
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
        if (cmd.leftCharacter)
        {
            if (leftCharacter)
            {
                Destroy(leftCharacter);
            }
            leftCharacter = Instantiate(cmd.leftCharacter);
            leftCharacter.transform.SetPositionAndRotation(new Vector3(-6.0f, -5.0f, 0.0f) + leftCharacter.transform.localPosition, Quaternion.Euler(leftCharacter.transform.rotation.eulerAngles));
            SetCharacterName(leftCharacter.GetComponent<Character>().name);
        }
        if(leftCharacter)
        {
            leftCharacter.GetComponent<SpriteRenderer>().sprite = leftCharacter.GetComponent<Character>().emotions[(int)cmd.leftExpression];
        }
        if (cmd.rightCharacter)
        {
            if (rightCharacter)
            {
                Destroy(rightCharacter);
            }
            rightCharacter = Instantiate(cmd.rightCharacter);
            rightCharacter.transform.SetPositionAndRotation(new Vector3(6.0f, -5.0f, 0.0f) + rightCharacter.transform.localPosition, Quaternion.Euler(rightCharacter.transform.rotation.eulerAngles + new Vector3(0.0f, 180.0f, 0.0f)));
            SetCharacterName(rightCharacter.GetComponent<Character>().name);
        }
        if (rightCharacter)
        {
            rightCharacter.GetComponent<SpriteRenderer>().sprite = rightCharacter.GetComponent<Character>().emotions[(int)cmd.rightExpression];
        }
        if (!string.IsNullOrEmpty(cmd.speakerName))
        {
            SetCharacterName(cmd.speakerName);
        }
    }
}
