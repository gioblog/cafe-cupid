using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public RuntimeDialogueGraph runtimeGraph;

    [Header("UI Components")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI dialogueText;

    private Dictionary<string, RuntimeDialogueNode> nodeLookup = new Dictionary<string, RuntimeDialogueNode>();
    private RuntimeDialogueNode currentNode;

    private void Start()
    {
        //populate the dictionary 
        foreach(var node in runtimeGraph.allNodes)
        {
            nodeLookup[node.nodeID] = node; 
        }

        if (!string.IsNullOrEmpty(runtimeGraph.entryNodeID))
        {
            ShowNode(runtimeGraph.entryNodeID);
        }
        else
        {
            EndDialogue(); 
        }
    }

    private void Update()
    {
        //checks for either mouse or controller input 
        if(Mouse.current.leftButton.wasPressedThisFrame && currentNode != null || 
            Gamepad.current.buttonWest.wasPressedThisFrame && currentNode != null)
        {
            if (!string.IsNullOrEmpty(currentNode.nextNodeID))
            {
                ShowNode(currentNode.nextNodeID);
            }
            else
            {
                EndDialogue();
            }
        }
    }

    private void ShowNode(string nodeID)
    {
        //when the node id is not found in the dictionary 
        if(!nodeLookup.ContainsKey(nodeID))
        {
            EndDialogue();
            return; 
        }

        currentNode = nodeLookup[nodeID];
        dialoguePanel.SetActive(true);
        speakerText.SetText(currentNode.speakerName);
        dialogueText.SetText(currentNode.dialogueText); 
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        currentNode = null; 
    }
}

