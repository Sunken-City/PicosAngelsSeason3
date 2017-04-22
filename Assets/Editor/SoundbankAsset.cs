using UnityEngine;
using UnityEditor;
using System;

public class SoundbankAsset
{
    [MenuItem("Assets/Create/Soundbank")]
    public static void CreateAsset()
    {
        CustomAssetUtility.CreateAsset<Soundbank>();
    }
}