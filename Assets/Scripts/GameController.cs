using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Chat chats;
    int m_currentCommand = 0;

    void Awake()
    {
        // hostile singleton
        if (instance)
        {
            Debug.Log("Destroying irrelevant GameController instance");
            Destroy(instance.gameObject);
        }

        instance = this;
        Dialogue.instance.SetText("Ahahahaaha");
    }
    
    // Use this for initialization
    void Start ()
    {

    }
    
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Advance"))
        {
            Dialogue.instance.ApplyCommand(chats.chatCommands[m_currentCommand++]);
            if(m_currentCommand >= chats.chatCommands.Length)
            {
                m_currentCommand = 0;
            }
        }
    }
}
