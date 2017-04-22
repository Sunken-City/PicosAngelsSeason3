using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Chat))]
public class ChatEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Chat chat = (Chat)target;

        GUILayout.Label("Command Count: " + chat.chatCommands.Count);

        if (GUILayout.Button("Add New Chat Command"))
            chat.chatCommands.Add(new Chat.Command());

        for (int i = 0; i < chat.chatCommands.Count; i++)
        {
            GUILayout.Label("Command " + (i + 1));

            chat.chatCommands[i].leftCharacter = (GameObject)EditorGUILayout.ObjectField("Left Character:", chat.chatCommands[i].leftCharacter, typeof(GameObject), false);
            if (chat.chatCommands[i].leftCharacter)
            {
                Texture2D myTexture = AssetPreview.GetAssetPreview(chat.chatCommands[i].leftCharacter.GetComponent<SpriteRenderer>().sprite);
                GUILayout.Label(myTexture);
            }
            GUILayout.Label("Dialogue Text:");
            chat.chatCommands[i].dialogueText = EditorGUILayout.TextArea(chat.chatCommands[i].dialogueText, GUILayout.MaxHeight(50));

            Seperator();
        }

        EditorUtility.SetDirty(chat);
    }

    void Seperator()
    {
        GUILayout.Label("-----------------------------------");
    }
}