using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TimeToText : MonoBehaviour
{
    [SerializeField] private FloatVariable time;
    [SerializeField] private bool updateEveryFrame = true;
    [SerializeField] private bool updateOnEnable = true;
    private TMP_Text tmpText;

    private void Awake()
    {
        tmpText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        if (updateOnEnable)
            UpdateText();
    }

    private void Update()
    {
        if (updateEveryFrame)
            UpdateText();
    }

    public void UpdateText()
    {
        tmpText.text = ConvertToString(time.value);
    }

    private string ConvertToString(float timeInSeconds)
    {
        return System.TimeSpan.FromSeconds(time.value).ToString(@"mm\:ss\:fff");
    }
}
