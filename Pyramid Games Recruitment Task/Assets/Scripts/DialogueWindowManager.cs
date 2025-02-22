using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueWindowManager : MonoBehaviour
{
    public DialogueWindowContent content;

    [SerializeField] private GameObject ui;
    [SerializeField] private TMP_Text title;
    [SerializeField] private Transform optionsParent;
    [SerializeField] private GameObject optionPrefab;

    private List<GameObject> options = new List<GameObject>();

    private void Awake()
    {
        if (content)
            content.Clear();
    }

    public void ShowWindow()
    {
        Clear();

        int i = 0;
        title.text = content.title;
        foreach (string optionText in content.options)
        {
            var optionGO = Instantiate(optionPrefab, optionsParent);
            var optionButton = optionGO.GetComponent<Button>();
            int iCopy = i;

            options.Add(optionGO);
            optionButton.onClick.AddListener(() => { OptionSelected(iCopy); });
            optionButton.GetComponentInChildren<TMP_Text>().text = optionText;

            i++;
        }

        ui.SetActive(true);
    }

    public void HideWindow()
    {
        ui.SetActive(false);
    }

    private void OptionSelected(int index)
    {
        if (content.source == null)
            return;

        DialogueWindowTree dialogueSource = content.source;

        Clear();
        content.Clear();

        dialogueSource.OnOptionSelected(index);
    }

    private void Clear()
    {
        for (int i = options.Count - 1; i >= 0; i--)
            Destroy(options[i]);
        options.Clear();
    }
}
