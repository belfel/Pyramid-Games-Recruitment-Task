using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueWindowContent", menuName = "Scriptable Objects/DialogueWindowContent")]
public class DialogueWindowContent : ScriptableObject
{
    public DialogueWindowTree source;
    public string title;
    public List<string> options = new List<string>();

    public void AddOption(string text)
    { 
        options.Add(text);
    }

    public void Clear()
    {
        if (source != null)
            source.OnDialogueContentCleared();

        source = null;
        title = string.Empty;
        options.Clear();
    }
}
