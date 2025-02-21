using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TimeToText : MonoBehaviour
{
    [SerializeField] private FloatVariable time;
    private TMP_Text tmpText;

    private void Awake()
    {
        tmpText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        tmpText.text = System.TimeSpan.FromSeconds(time.value).ToString(@"mm\:ss\:fff");
    }
}
