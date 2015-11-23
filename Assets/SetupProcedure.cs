using UnityEngine;
using System.Collections;

public class SetupProcedure : MonoBehaviour {

    public GameObject FlatOverlay;
    public Camera LeftCamera;
    public Camera RightCamera;
    public TimeWatcher time;

    // Use this for initialization
    void Awake () {
        // Start up function for Variables
        Variables.InitVars();

        // Duplicate the Canvas Overlay once
        Canvas originalCanvas = FlatOverlay.GetComponent<Canvas>();
        GameObject newCanvas = GameObject.Instantiate(FlatOverlay) as GameObject;
        FlatOverlay.name = "Flat Overlay_Left";
        newCanvas.name = "Flat Overlay_Right";
        Canvas newCanvas_canvas = newCanvas.GetComponent<Canvas>();
        if (originalCanvas.worldCamera == null)
        {
            originalCanvas.worldCamera = LeftCamera;
            newCanvas_canvas.worldCamera = RightCamera;
        }
        else if (originalCanvas.worldCamera == LeftCamera)
        {
            newCanvas_canvas.worldCamera = RightCamera;
        }
        else
        {
            newCanvas_canvas.worldCamera = LeftCamera;
            FlatOverlay.name = "Flat Overlay_Right";
            newCanvas.name = "Flat Overlay_Left";
        }

	}
	
	// Update is called once per frame
	void Update () {
        // start time. This is just to get Time running. Later on
        // game will watch for a particular state (like, after leaf falls into place)
        if (!time.hasStarted) time.hasStarted = true;
    }
}
