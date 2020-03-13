using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Text timerText;
    public AudioSource source;

    private int currentSecond = -1;

    public void SetTime(float currentTime)
    {
        timerText.text = currentTime.ToString();

        int round = Mathf.CeilToInt(currentTime);
        if (round != currentSecond)
        {
            PlaySound();
            currentSecond = round;
        }
    }

    public void PlaySound()
    {
        source.Play();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
