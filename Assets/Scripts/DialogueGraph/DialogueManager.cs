using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public RuntimeDialogueGraph runtimeGraph;

    [Header("UI Components")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI dialogueText;

    [Header("Choice Button UI")]
    public Button choiceButtonPrefab;
    public Transform choiceButtonContainer; 

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
        //last condition checks to make sure that there isn't a dialogue button selection occuring 
        if (IsPressed() && currentNode != null && currentNode.choices.Count == 0)
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

    /// <summary>
    /// Displays dialogue to UI 
    /// </summary>
    /// <param name="nodeID"></param>
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

        foreach(Transform child in choiceButtonContainer)
        {
            Destroy(child.gameObject); 
        }

        //displays choices if they are present for the user  
        if(currentNode.choices.Count > 0)
        {
            foreach(var choice in currentNode.choices)
            {
                Button button = Instantiate(choiceButtonPrefab, choiceButtonContainer);
                TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>(); 
                if(buttonText != null)
                {
                    buttonText.text = choice.choiceText;
                }

                //setup button's onClick event
                if(button != null)
                {
                    button.onClick.AddListener(() =>
                    {
                       if(!string.IsNullOrEmpty(choice.destinationNodeID))
                       {
                            ShowNode(choice.destinationNodeID); 
                       }
                       else
                       {
                            EndDialogue(); //string is null 
                       }
                    });   
                }
            }
        }
    }

    /// <summary>
    /// Ends dialogue by returning nessary variables to default state
    /// </summary>
    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        currentNode = null;

        //just in case 
        foreach (Transform child in choiceButtonContainer)
        {
            Destroy(child.gameObject);
        }
    }  
    
    /// <summary>
    /// Checks what tool is actively being used 
    /// </summary>
    /// <returns></returns>
    private bool IsPressed()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) return true;
        if (Gamepad.current != null && Gamepad.current.buttonWest.wasPressedThisFrame) return true;

        return false; 
    }
}

