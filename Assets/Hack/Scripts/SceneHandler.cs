using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{

    private string[] sceneNames = new string[9]
    {
        "Adelante Scene 1",
        "Adelante Scene 2",
        "Adelante Scene 3",
        "Adelante Scene 4",
        "Adelante Scene 5",
        "Adelante Scene 6",
        "Adelante Scene 7",
        "Adelante Scene 8",
        "Adelante Scene 9",
    };

    private static SceneHandler sh = null;

    private LocationHandler locationHandler;

    private int locationIdx = 0;

    void Awake()
    {

        if (sh == null) sh = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

    }
    

    // Update is called once per frame
    void Update()
    {

        if (locationHandler == null)
        {
            locationHandler = GameObject.Find("Location").GetComponent<LocationHandler>();
        }
        else if (locationHandler != null && !locationHandler.started)
        {
            locationHandler.StartLocation();
        }
        else if (locationHandler.finished && !SteamVR_LoadLevel.loading && locationIdx < sceneNames.Length)
        {
            locationIdx++;
            Debug.Log("Load scene [" + locationIdx + "]: " + sceneNames[locationIdx]);
            SteamVR_LoadLevel.Begin(sceneNames[locationIdx]);
            locationHandler = null;
        }

    }

}
