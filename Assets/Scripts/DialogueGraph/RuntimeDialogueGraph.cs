using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class RuntimeDialogueGraph : ScriptableObject
{
    public string entryNodeID;
    public List<RuntimeDialogueNode> allNodes = new List<RuntimeDialogueNode>();  
}

[Serializable]
public class RuntimeDialogueNode
{
    public string nodeID;
    public string speakerName;
    public string dialogueText;
    public string nextNodeID; 
}
