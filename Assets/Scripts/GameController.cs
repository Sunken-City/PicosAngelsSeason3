using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Chat[] chats;
    int m_currentCommand = 0;
    int m_currentChat = 0;

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

    void StartBackgroundMusic(AudioClip soundClip)
    {
        if (soundClip == null || soundClip == GetComponent<AudioSource>().clip)
        {
            return;
        }
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = soundClip;
        GetComponent<AudioSource>().Play();
    }

    // Use this for initialization
    void Start()
    {
        Dialogue.instance.dialogueBox.background.GetComponent<SpriteRenderer>().sprite = chats[0].background;
        StartBackgroundMusic(chats[0].music);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Advance"))
        {
            if (m_currentCommand <= chats[m_currentChat].chatCommands.Count)
            {
                Dialogue.instance.ApplyCommand(chats[m_currentChat].chatCommands[m_currentCommand++]);
            }
            if ((m_currentCommand > chats[m_currentChat].chatCommands.Count) && (m_currentChat < chats.Length))
            {
                m_currentCommand = 0;
                ++m_currentChat;
                StartBackgroundMusic(chats[m_currentChat].music);
                Dialogue.instance.dialogueBox.background.GetComponent<SpriteRenderer>().sprite = chats[m_currentChat].background;
                Dialogue.instance.ApplyCommand(chats[m_currentChat].chatCommands[m_currentCommand]);
            }
        }
        if (Input.GetButtonDown("Return"))
        {
            if (m_currentCommand > 0)
            {
                Dialogue.instance.ApplyCommand(chats[m_currentChat].chatCommands[--m_currentCommand]);
            }
            else if ((m_currentCommand == 0) && (m_currentChat > 0))
            {
                --m_currentChat;
                m_currentCommand = chats[m_currentChat].chatCommands.Count;
                StartBackgroundMusic(chats[m_currentChat].music);
                Dialogue.instance.dialogueBox.background.GetComponent<SpriteRenderer>().sprite = chats[m_currentChat].background;
                Dialogue.instance.ApplyCommand(chats[m_currentChat].chatCommands[m_currentCommand]);
            }
        }
    }
}

