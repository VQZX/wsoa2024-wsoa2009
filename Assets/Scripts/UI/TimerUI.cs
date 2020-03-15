using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    /// <summary>
    /// The text to display the countdown time to
    /// </summary>
    public Text TimerText;

    /// <summary>
    /// Audio Source to play an accompanying music
    /// </summary>
    public AudioSource AudioSource;

    /// <summary>
    /// The current time to display
    /// </summary>
    private int currentSecond = -1;

    /// <summary>
    /// Sets the time to display
    /// </summary>
    public void SetTime(float currentTime)
    {
        int round = Mathf.CeilToInt(currentTime);
        if (round != currentSecond)
        {
            PlaySound();
            currentSecond = round;
        }
        TimerText.text = currentSecond.ToString();

    }

    /// <summary>
    /// Play a user-interface sound effect
    /// </summary>
    public void PlaySound()
    {
        AudioSource.Play();
    }

    /// <summary>
    /// Activate the game object
    /// </summary>
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Deactivate the game object
    /// </summary>
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
