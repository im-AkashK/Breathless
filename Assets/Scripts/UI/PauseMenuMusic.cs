using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PauseMenuMusic : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private AudioSource audioSource;
    private bool isPaused;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isPaused = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isPaused)
        {
            audioSource.Pause();
            isPaused = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isPaused)
        {
            audioSource.UnPause();
            isPaused = false;
        }
    }
}
