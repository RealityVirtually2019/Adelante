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

    public GameObject location1;
    public GameObject location2;
    public GameObject location3;

    private LocationHandler location1handler;
    private LocationHandler location2handler;
    private LocationHandler location3handler;


    void Awake()
    {

        if (sh == null) sh = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        location1handler = location1.GetComponent<LocationHandler>();
        location2handler = location2.GetComponent<LocationHandler>();
        location3handler = location3.GetComponent<LocationHandler>();

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
        else if (location2handler.finished)
        {
            location2.SetActive(false);
            location3.SetActive(true);
        }
        else if (location3handler.finished)
        {
            SteamVR_LoadLevel.Begin("Adelante Scene 2");
        }

    }

}
