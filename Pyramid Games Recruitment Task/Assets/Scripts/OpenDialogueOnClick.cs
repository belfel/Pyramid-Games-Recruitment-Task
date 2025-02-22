using UnityEngine;

public class OpenDialogueOnClick : MonoBehaviour
{
    [SerializeField] private DialogueWindowTree dialogueTree;

    private void Awake()
    {
        if (dialogueTree == null)
            dialogueTree = GetComponent<DialogueWindowTree>();

        if (dialogueTree == null)
            Debug.LogWarning("Missing reference to dialogue tree");
    }

    private void OnMouseDown()
    {
        if (dialogueTree != null)
            dialogueTree.OpenDialogueWindow();
    }
}
