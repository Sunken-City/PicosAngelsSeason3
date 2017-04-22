using UnityEngine;
using UnityEditor;
using System;

public class ChatAsset
{
    [MenuItem("Assets/Create/Chat")]
    public static void CreateAsset()
    {
        CustomAssetUtility.CreateAsset<Chat>();
    }
}