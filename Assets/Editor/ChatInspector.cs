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
            chat.chatCommands[i].leftExpression = (Character.Animations)EditorGUILayout.EnumPopup("Expression:", chat.chatCommands[i].leftExpression);
            chat.chatCommands[i].rightCharacter = (GameObject)EditorGUILayout.ObjectField("Left Character:", chat.chatCommands[i].rightCharacter, typeof(GameObject), false);
            chat.chatCommands[i].rightExpression = (Character.Animations)EditorGUILayout.EnumPopup("Expression:", chat.chatCommands[i].rightExpression);
            if (chat.chatCommands[i].leftCharacter)
            {
                Texture2D myTexture = AssetPreview.GetAssetPreview(chat.chatCommands[i].leftCharacter.GetComponent<Character>().emotions[(int)chat.chatCommands[i].leftExpression]);
                GUILayout.Label(myTexture);
            }
            if (chat.chatCommands[i].rightCharacter)
            {
                Texture2D myTexture = AssetPreview.GetAssetPreview(chat.chatCommands[i].rightCharacter.GetComponent<Character>().emotions[(int)chat.chatCommands[i].rightExpression]);
                GUILayout.Label(myTexture);
            }
            chat.chatCommands[i].speakerName = EditorGUILayout.TextField("Speaker Name:", chat.chatCommands[i].speakerName);
            GUILayout.Label("Dialogue Text:");
            chat.chatCommands[i].dialogueText = EditorGUILayout.TextArea(chat.chatCommands[i].dialogueText, GUILayout.MaxHeight(50));

            Seperator();
        }

        if (GUILayout.Button("Remove Last Chat Command"))
            chat.chatCommands.RemoveAt(chat.chatCommands.Count - 1);

        EditorUtility.SetDirty(chat);
    }

    void Seperator()
    {
        GUILayout.Label("-----------------------------------");
    }
}