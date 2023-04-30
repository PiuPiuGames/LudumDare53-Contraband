using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textWriter : MonoBehaviour
{
     public Text textObject;
    public string message;
    public float delayBetweenCharacters;
    public float delayBetweenWords;
    public float delayOnPunctuation;
    public AudioSource audioSource;

    private void Start()
    {
        StartCoroutine(TypeAndPlayMessage());
    }

    private IEnumerator TypeAndPlayMessage()
    {
        textObject.text = "";

        for (int i = 0; i < message.Length; i++)
        {
            textObject.text += message[i];
            PlayAudioClip();
            float currentDelay = delayBetweenCharacters;
            if (char.IsWhiteSpace(message[i]))
            {
                currentDelay = delayBetweenWords;
            }
            else if (IsPunctuation(message[i]))
            {
                currentDelay = delayOnPunctuation;
            }
            yield return new WaitForSeconds(currentDelay);
        }
    }
    private void PlayAudioClip()
    {
        audioSource.Play();
    }
    private bool IsPunctuation(char character)
    {
        return character == '.' || character == ',' || character == '!' || character == '?' || character == ':' || character == ';';
    }
}
