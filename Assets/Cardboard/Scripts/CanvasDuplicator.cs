using UnityEngine;
using System.Collections;

public class CanvasDuplicator : MonoBehaviour {

    public Camera otherCamera;

	// Use this for initialization
	void Start () {
        GameObject newCanvas = GameObject.Instantiate(this.gameObject) as GameObject;
        newCanvas.name = "Overlay Canvas_Two";
        Canvas newCanvas_canvas = newCanvas.GetComponent<Canvas>();
        newCanvas_canvas.worldCamera = otherCamera;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
