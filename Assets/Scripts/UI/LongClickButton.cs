using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LongClickButton : MonoBehaviour, IPointerDownHandler , IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    public float requiredHoldTime;
    public UnityEvent onLongClick;
    private GameObject playcontroller;

public void Awake()
{
    playcontroller = GameObject.Find("PlayButtonManager");
}



public void LoadScene1()
{
    SceneManager.LoadScene("Level_1");
}

public void OnPointerDown(PointerEventData eventData)
{
    pointerDown = true;
    Debug.Log("OnPointerDown");
    playcontroller.GetComponent<AudioSource>().Play();
    
   
}

public void OnPointerUp(PointerEventData eventData)
{
    if (pointerDownTimer < requiredHoldTime) // if the hold time is less than required time, do not execute onLongClick event
    {
        Reset();
    }
    Debug.Log("OnPointerUp");
   playcontroller.GetComponent<AudioSource>().Stop();
   
}

private void Update()
{
    if (pointerDown)
    {
        pointerDownTimer += Time.deltaTime;
        if (pointerDownTimer > requiredHoldTime)
        {
            if (onLongClick != null)
            {
                onLongClick.AddListener(LoadScene1); // add the LoadScene1 method to the UnityEvent
                onLongClick.Invoke(); // invoke the UnityEvent
                onLongClick.RemoveListener(LoadScene1); // remove the method from the UnityEvent
            }
            Reset();
        }
    }
}



    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }
}