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

        chat.background = (Sprite)EditorGUILayout.ObjectField("Background:", chat.background, typeof(Sprite), false);
        chat.music = (AudioClip)EditorGUILayout.ObjectField("Music:", chat.music, typeof(AudioClip), false);

        GUILayout.Label("Command Count: " + chat.chatCommands.Count);

        for (int i = 0; i < chat.chatCommands.Count; i++)
        {
            if (GUILayout.Button("X", GUILayout.Width(25), GUILayout.Height(25)))
            {
                chat.chatCommands.RemoveAt(i);
            }
            GUILayout.Label("Command " + (i + 1));

            chat.chatCommands[i].leftCharacter = (GameObject)EditorGUILayout.ObjectField("Left Character:", chat.chatCommands[i].leftCharacter, typeof(GameObject), false);
            chat.chatCommands[i].leftExpression = (Character.Animations)EditorGUILayout.EnumPopup("Expression:", chat.chatCommands[i].leftExpression);
            if (chat.chatCommands[i].leftCharacter)
            {
                Texture2D myTexture = AssetPreview.GetAssetPreview(chat.chatCommands[i].leftCharacter.GetComponent<Character>().emotions[(int)chat.chatCommands[i].leftExpression]);
                GUILayout.Label(myTexture);
            }

            chat.chatCommands[i].rightCharacter = (GameObject)EditorGUILayout.ObjectField("Right Character:", chat.chatCommands[i].rightCharacter, typeof(GameObject), false);
            chat.chatCommands[i].rightExpression = (Character.Animations)EditorGUILayout.EnumPopup("Expression:", chat.chatCommands[i].rightExpression);
            if (chat.chatCommands[i].rightCharacter)
            {
                Texture2D myTexture = AssetPreview.GetAssetPreview(chat.chatCommands[i].rightCharacter.GetComponent<Character>().emotions[(int)chat.chatCommands[i].rightExpression]);
                GUILayout.Label(myTexture);
            }
            
            chat.chatCommands[i].speakerName = EditorGUILayout.TextField("Speaker Name:", chat.chatCommands[i].speakerName);
            GUILayout.Label("Dialogue Text:");
            chat.chatCommands[i].dialogueText = EditorGUILayout.TextArea(chat.chatCommands[i].dialogueText, GUILayout.MaxHeight(50));

            chat.chatCommands[i].sfx = (AudioClip)EditorGUILayout.ObjectField("Sound Effect:", chat.chatCommands[i].sfx, typeof(AudioClip), false);

            Seperator();

            if (GUILayout.Button("Insert New", GUILayout.Width(100)))
                chat.chatCommands.Insert(i + 1, new Chat.Command());

            Seperator();
        }

        if (GUILayout.Button("Add New Chat Command"))
        {
            chat.chatCommands.Add(new Chat.Command());
        }
        EditorUtility.SetDirty(chat);
    }

    void Seperator()
    {
        GUILayout.Label("---------------------------------------------------------------------");
    }
}