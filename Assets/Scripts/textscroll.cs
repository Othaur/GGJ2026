using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using TMPro;

public class textscroll : MonoBehaviour
{
    [Header("Text Settings")]
    [SerializeField, TextArea] private string[] itemInfo;
    [SerializeField] private float textSpeed = 0.01f;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI itemInfoText;

    private int currentDisplayingText = 0;

    private Coroutine typingCoroutine;
    public bool isTyping = false;

    public void ActivateText()
    {
        // If already typing, complete text instantly
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            itemInfoText.text = itemInfo[currentDisplayingText];
            //isTyping = false;
            return;
        }

        // Otherwise start typing
        typingCoroutine = StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        isTyping = true;
        itemInfoText.text = "";

        string fullText = itemInfo[currentDisplayingText];

        for (int i = 0; i <= fullText.Length; i++)
        {
            itemInfoText.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
        currentDisplayingText++;
    }
}