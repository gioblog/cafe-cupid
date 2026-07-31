using UnityEngine;
using Unity.GraphToolkit.Editor;
using System;

[Serializable]
public class StartNode : Node 
{
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddOutputPort("out").Build(); 
    }
}

[Serializable]
public class EndNode : Node
{
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddInputPort("in").Build(); 
    }
}

[Serializable]
public class DialogueNode : Node
{
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddOutputPort("out").Build();
        context.AddInputPort("in").Build();

        context.AddInputPort<string>("Speaker").Build();
        context.AddInputPort<string>("Dialogue").AsTextArea().Build(); 
    }
}

[Serializable]
public class ChoiceNode : Node
{
    const string OptionID = "portCount"; 
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddInputPort("in");
        context.AddInputPort<string>("Speaker").Build();
        context.AddInputPort<string>("Dialogue").AsTextArea().Build();

        //make it dynamic so we can choose how many choices (import ports) it has 
        var option = GetNodeOptionByName(OptionID);
        option.TryGetValue(out int portCount); 

        for(int i = 0; i < portCount; i++)
        {
            context.AddInputPort<string>($"Dialogue Choice Text #{i}").Build();
            context.AddOutputPort($"Dialogue Choice #{i}").Build(); 
        }
    }

    protected override void OnDefineOptions(IOptionDefinitionContext context)
    {
        context.AddOption<int>(OptionID).WithDefaultValue(2).Delayed(); 
    }
}
