using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public FloatVariable currentAttemptTime;
    public FloatVariable bestTime;

    bool timerRunning = false;

    private void Update()
    {
        if (timerRunning)
            currentAttemptTime.SetValue(currentAttemptTime.value + Time.deltaTime);
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public void ResetTimer()
    {
        currentAttemptTime.SetValue(0f);
    }

    public void UpdateBestTime()
    {
        if (currentAttemptTime.value < bestTime.value)
            bestTime.value = currentAttemptTime.value;
    }
}
