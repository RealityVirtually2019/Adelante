using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{

    public string[] sceneNames = new string[3]
    {
        "Adelante Scene 1",
        "Adelante Scene 2",
        "Adelante Scene 3"
    };

    private static SceneHandler sh = null;

    public GameObject[] locations = new GameObject[9];
    private LocationHandler[] locationHandlers = new LocationHandler[9];

    private int locationIdx = 0;

    void Awake()
    {

        if (sh == null) sh = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        foreach( GameObject location in locations)
        {
            locationIdx++;
            location.SetActive(false);
            locationHandlers[locationIdx] = location.GetComponent<LocationHandler>();
        }

        locations[locationIdx].SetActive(true);
        locationHandlers[locationIdx].StartLocation();

    }
    

    // Update is called once per frame
    void Update()
    {

        if (locationHandlers[locationIdx].finished)
        {
            locations[locationIdx].SetActive(false);
            locationIdx++;
            locations[locationIdx].SetActive(true);
            locationHandlers[locationIdx].StartLocation();
        }

        //else if (location3handler.finished)
        //{
        //    SteamVR_LoadLevel.Begin("Adelante Scene 2");
        //}

    }

}
