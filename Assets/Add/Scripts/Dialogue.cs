using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject box;
    public TextMeshProUGUI displayText;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public Animator displayTextAnim;
    public GameObject player;

    private void Start()
    {
        box.SetActive(false);
        //displayText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Type());
    }
     void Update()
    {
        if (displayText.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        yield return new WaitForSeconds(.5f);
        box.SetActive(true);
        player.SetActive(false);
        yield return new WaitForSeconds(1f);
        foreach (char letter in sentences[index].ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentence()
    {
        displayTextAnim.SetTrigger("change");
        continueButton.SetActive(false);
        if (index < sentences.Length-1)
        {
            index++;
            displayText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            displayText.text = "";
            continueButton.SetActive(false);
            box.SetActive(false);
            player.SetActive(true);
        }
    }
}
