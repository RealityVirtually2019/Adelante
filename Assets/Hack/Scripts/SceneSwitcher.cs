using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour {

    public int currLevel = 0;

    public string[] sceneNames = new string[3]
    {
        "Adelante Scene 1",
        "Adelante Scene 2",
        "Adelante Scene 3"
    };

    private static SceneSwitcher ss = null;

	// Use this for initialization
	void Start ()
    {

        if (ss == null)
            ss = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

	}
	
	// Update is called once per frame
	void Update ()
    {

        if (SceneKeyPressed() 
            && !SteamVR_LoadLevel.loading 
            && currLevel < sceneNames.Length)
        {
            currLevel++;
            currLevel = currLevel % sceneNames.Length;
            SteamVR_LoadLevel.Begin(sceneNames[currLevel]);
        }

	}

    bool SceneKeyPressed()
    {

        return Input.GetKey(KeyCode.Space);

    }


}