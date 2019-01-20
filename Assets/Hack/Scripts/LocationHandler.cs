using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationHandler : MonoBehaviour
{

    public float audioDelay;
    public float narrationBuffer = 1;
    public float locationDelay = 10;

    public AudioSource music;

    public AudioSource narration;
    public AudioSource effect;

    public bool finished;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(ExecuteAfterTime(audioDelay, narration, effect));

        finished = true;

    }

    IEnumerator ExecuteAfterTime(float time, AudioSource narration, AudioSource effect)
    {

        yield return new WaitForSeconds(time);

        music.volume /= 4;
        if (effect != null) effect.volume /= 4;

        yield return new WaitForSeconds(narrationBuffer);

        narration.Play();

        yield return new WaitForSeconds(narration.clip.length + narrationBuffer);

        music.volume *= 4f;
        if (effect != null) effect.volume *= 4;

        yield return new WaitForSeconds(locationDelay);

    }

}
