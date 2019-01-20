using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{

    public GameObject location1;
    public GameObject location2;
    public GameObject location3;

    public LocationHandler location1handler;
    public LocationHandler location2handler;
    public LocationHandler location3handler;

    void Awake()
    {

        location2.SetActive(false);
        location3.SetActive(false);

    }
    
    // Update is called once per frame
    void Update()
    {
        if (location1handler.finished)
        {
            location1.SetActive(false);
            location2.SetActive(true);
        }

        if (location2handler.finished)
        {
            location2.SetActive(false);
            location3.SetActive(true);
        }

    }
}
