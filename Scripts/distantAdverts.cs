using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distantAdverts : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource AS;
    public float minTimeBtw;
    public float maxTimeBtw;
    public void Start()
    {
        StartCoroutine(RandomAudioCoroutine());
    }

    private IEnumerator RandomAudioCoroutine()
    {
        while (true)
        {
            yield return StartCoroutine(RandomAudio());
            yield return new WaitForSeconds(Random.Range(minTimeBtw, maxTimeBtw));
        }
    }
    private IEnumerator RandomAudio()
    {
         float random = Random.Range(5f, 25f);
        AS.PlayOneShot(clips[Mathf.FloorToInt(Random.Range(0f, clips.Length - 1))], 0.3f);
        yield return new WaitForSeconds(random);
    }
}
