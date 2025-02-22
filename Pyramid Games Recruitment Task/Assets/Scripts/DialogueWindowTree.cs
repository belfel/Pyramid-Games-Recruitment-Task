using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueWindowTree : MonoBehaviour
{
    public DialogueWindowContent dialogueWindowContent;

    public GameEvent dialogueWindowOpened;
    public GameEvent dialogueWindowClosed;

    public List<DialogueWindow> dialogueWindows = new List<DialogueWindow>();
    private int activeWindowIndex = 0;
    private bool isActive = false;

    [System.Serializable]
    public struct DialogueWindow
    {
        public string title;
        public List<DialogueWindowOption> options;
    }

    [System.Serializable]
    public class DialogueWindowOption
    {
        public string text;
        public UnityEvent onSelectEvent;
        public int nextDialogueIndex;

        public DialogueWindowOption()
        {
            nextDialogueIndex = -1;
        }
    }

    public void OpenDialogueWindow()
    {
        if (isActive)
            return;

        dialogueWindowContent.Clear();
        dialogueWindowContent.source = this;
        dialogueWindowContent.title = dialogueWindows[activeWindowIndex].title;
        foreach (var option in dialogueWindows[activeWindowIndex].options)
            dialogueWindowContent.AddOption(option.text);

        dialogueWindowOpened.Raise();
    }

    public void OnOptionSelected(int index)
    {
        DialogueWindowOption selectedOption = dialogueWindows[activeWindowIndex].options[index];

        if (selectedOption == null)
        {
            Debug.LogError("Selected option doesn't exist");
            return;
        }

        selectedOption.onSelectEvent.Invoke();

        if (selectedOption.nextDialogueIndex == -1)
        {
            isActive = false;
            dialogueWindowClosed.Raise();
            return;
        }

        activeWindowIndex = selectedOption.nextDialogueIndex;
        OpenDialogueWindow();
    }

    public void SetWindowIndex(int index)
    {
        if (index < dialogueWindows.Count && index >= 0)
            activeWindowIndex = index;
        else
            Debug.LogError("Index value out of range");
    }

    public void OnDialogueContentCleared()
    {
        isActive = false;
    }
}
