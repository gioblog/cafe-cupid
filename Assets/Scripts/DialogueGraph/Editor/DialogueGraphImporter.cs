using UnityEngine;
using UnityEditor.AssetImporters;
using Unity.GraphToolkit.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

[ScriptedImporter(1, DialogueGraph.AssetExtension)]
public class DialogueGraphImporter : ScriptedImporter
{
    //whenever an asset is imported (ex. saving the graph, creating the graph) 
    public override void OnImportAsset(AssetImportContext ctx)
    {
        DialogueGraph editorGraph = GraphDatabase.LoadGraphForImporter<DialogueGraph>(ctx.assetPath);
        RuntimeDialogueGraph runtimeGraph = ScriptableObject.CreateInstance<RuntimeDialogueGraph>();
        var nodeIDMap = new Dictionary<INode, string>(); //to look up node ids from their interface
        
        foreach(var node in editorGraph.GetNodes())
        {
            nodeIDMap[node] = Guid.NewGuid().ToString(); //giving each node a unique ID 
        }

        //looking for where to start 
        var startNode = editorGraph.GetNodes().OfType<StartNode>().FirstOrDefault(); 
        if(startNode != null)
        {
            var entryPort = startNode.GetOutputPorts().FirstOrDefault()?.FirstConnectedPort;
            if(entryPort != null)
            {
                runtimeGraph.entryNodeID = nodeIDMap[entryPort.GetNode()];
            }
        }

        foreach (var iNode in editorGraph.GetNodes())
        {
            if (iNode is StartNode || iNode is EndNode) continue;

            var runtimeNode = new RuntimeDialogueNode { nodeID = nodeIDMap[iNode] }; 
            if(iNode is DialogueNode dialogueNode)
            {
                ProcessDialogueNode(dialogueNode, runtimeNode, nodeIDMap); 
            }
        }

        //make inspector field for dialogue graph
        ctx.AddObjectToAsset("RuntimeData", runtimeGraph);
        ctx.SetMainObject(runtimeGraph); 
    }

    private void ProcessDialogueNode(DialogueNode node, RuntimeDialogueNode runtimeNode, 
        Dictionary<INode, string> nodeIDMap)
    {
        runtimeNode.speakerName = GetPortValue<string>(node.GetInputPortByName("Speaker"));
        runtimeNode.dialogueText = GetPortValue<string>(node.GetInputPortByName("Dialogue"));

        //creates the chain to let the game know how to go
        //from one piece of dialogue to the next 
        var nextNodePort = node.GetOutputPortByName("out")?.FirstConnectedPort; 
        if(nextNodePort != null)
        {
            runtimeNode.nextNodeID = nodeIDMap[nextNodePort.GetNode()]; 
        }

    }

    /// <summary>
    /// Gets the value thats inside the dialogue node's port 
    /// Uses a generic tyoe to allow for any sort of data 
    /// </summary>
    /// <param name="port"></param>
    /// <returns></returns>
    private T GetPortValue<T>(IPort port)
    {
        if (port == null) return default; 
        if(port.IsConnected)
        {
            if(port.FirstConnectedPort.GetNode() is IVariableNode variableNode)
            {
                variableNode.Variable.TryGetDefaultValue(out T value);
                return value; 
            }
        }

        port.TryGetValue(out T fallbackValue);
        return fallbackValue; 
    }
}
