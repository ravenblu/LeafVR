using UnityEngine;
using System.Collections;

public class StateWatcher : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
	
	}
    void Awake()
    {
        // if another StateWatcher exists,
        // check age. If I am younger, destroy myself instead.
        // Destroy(transform.gameObject);
        DontDestroyOnLoad(transform.gameObject);
    }
    // Update is called once per frame
    void Update () {

	    if (Variables.Health<=0)
        {
            Application.LoadLevel(0);
         //   Variables.FadeOutStart = true;
         //   Variables.TrueEnd = false;
            // stuff that indicates DEATH of game
            // fade screen to black
        }
	}
}
