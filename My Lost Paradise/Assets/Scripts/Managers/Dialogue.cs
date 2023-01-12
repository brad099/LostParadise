using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dialogue : MonoBehaviour
{
    [SerializeField]GameObject DialoguePanel;
    [SerializeField]GameObject contButton;
    [SerializeField]GameObject talkBanner;
    [SerializeField]TMP_Text DialogueText;
    [SerializeField]string[] dialogue;
    [SerializeField]float ReadSpeed;
    [SerializeField]bool PlayerClose;
    private int index;  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& PlayerClose)
        {
            if (DialoguePanel.activeInHierarchy)
            {
                ZeroText();
            }
            else
            {
                DialoguePanel.SetActive(true); 
                StartCoroutine(Typing());
                SoundManager.instance.Play("Mumble",true);
            }
        }
        if (DialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void NextLine()
    {
        contButton.SetActive(false);
        if (index < dialogue.Length -1)
        {
            index++;
            DialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        } 
    }

    private void ZeroText()
    {
        DialogueText.text = "";
        index = 0;
        DialoguePanel.SetActive(false); 
        talkBanner.SetActive(false);
    }

    IEnumerator Typing()
    {
        SoundManager.instance.Play("Mumble2",true);
        foreach (char letter in dialogue[index].ToCharArray())
        {
            DialogueText.text  += letter; 
            yield return new WaitForSeconds(ReadSpeed);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            PlayerClose = true;
            talkBanner.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.instance.Play("Mumble3",true);
            PlayerClose = false;
            ZeroText();
            talkBanner.SetActive(false);
        }
    }
}
