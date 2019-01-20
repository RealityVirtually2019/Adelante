using UnityEngine;
using Valve.VR.InteractionSystem;

public class Candle : MonoBehaviour
{
    public GameObject flame;
    public Light flameLight;

    private bool lighting = false;
    private bool lit = false;

    private float intensity = 1.5f;

    private float pingPong;

	private void OnHandHoverBegin( Hand hand )
	{
        lighting = true;
	}


    // Update is called once per frame
    void Update()
    {

        if(lighting)
        {

            flame.transform.localScale = Vector3.Lerp(flame.transform.localScale, Vector3.one, Time.deltaTime);

            flameLight.intensity = Mathf.Lerp(flameLight.intensity, 1.5f, Time.deltaTime * 2);

            if (flameLight.intensity > (intensity - 0.001f)) lit = true;
        }

        if (lit)
        {
            pingPong = Mathf.PingPong(Time.time, 1);

            flame.transform.localScale = new Vector3(1 + (pingPong/10), 1 + (pingPong/10), 1 + (pingPong/10));
            flameLight.intensity = (intensity - 0.5f) + pingPong;

        }

    }
}
