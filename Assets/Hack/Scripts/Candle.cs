using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Candle : MonoBehaviour
{
    public GameObject flame;
    public Light light;

    private bool lit = false;

	private void OnHandHoverBegin( Hand hand )
	{
        lit = true;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(lit)
        {
            flame.transform.localScale = Vector3.Lerp(flame.transform.localScale, Vector3.one, Time.deltaTime);

            light.intensity = Mathf.Lerp(light.intensity, 1.5f, Time.deltaTime);
        }
    }
}
