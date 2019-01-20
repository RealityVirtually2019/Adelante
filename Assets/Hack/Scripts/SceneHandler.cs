using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{

    public float audioDelay;
    public float narrationBuffer = 1;

    public GameObject location1;
    public GameObject location2;
    public GameObject location3;

    public AudioSource music;

    public AudioSource scene1narration;
    public AudioSource scene1effect;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(ExecuteAfterTime(audioDelay, scene1narration, scene1effect));

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

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
