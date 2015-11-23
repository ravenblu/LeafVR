using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

    public bool fadeOutInitialized;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (fadeOutInitialized)
        {

        }
	    else if (!fadeOutInitialized && Variables.FadeOutStart && !Variables.TrueEnd)
        {
            fadeOutInitialized = true;
            Variables.FadeOutStart = false;
        }
	}
}
