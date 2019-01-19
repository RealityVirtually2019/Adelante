using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Candle : MonoBehaviour
{
    public GameObject flame;
    public Light light;

    private bool lighting = false;
    private bool lit = false;

    private float intensity = 1.5f;

    private float pingPong;

	private void OnHandHoverBegin( Hand hand )
	{
        lighting = true;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(lighting)
        {

            flame.transform.localScale = Vector3.Lerp(flame.transform.localScale, Vector3.one, Time.deltaTime);

            light.intensity = Mathf.Lerp(light.intensity, 1.5f, Time.deltaTime * 2);

            if (light.intensity > (intensity - 0.001f)) lit = true;
        }

        if (lit)
        {
            pingPong = Mathf.PingPong(Time.time, 1);

            flame.transform.localScale = new Vector3(1 + (pingPong/10), 1 + (pingPong/10), 1 + (pingPong/10));
            light.intensity = (intensity - 0.5f) + pingPong;

        }

    }
}
