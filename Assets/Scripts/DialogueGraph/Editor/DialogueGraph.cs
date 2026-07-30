using UnityEngine;
using Unity.GraphToolkit;
using UnityEditor;
using Unity.GraphToolkit.Editor;
using System;

[Serializable]
[Graph(AssetExtension)]
public class DialogueGraph : Graph
{
    public const string AssetExtension = "dialoguegraph";
    
    /// <summary>
    /// Creates graph visual 
    /// </summary>
    [MenuItem("Assets/Create/Dialogue Graph", false)]
    private static void CreateAssetFile()
    {
        GraphDatabase.PromptInProjectBrowserToCreateNewAsset<DialogueGraph>(); 
    }
   
}
