using UnityEngine;
using System.Collections;

public class CanvasPositioner : MonoBehaviour {

    public Transform cameraLocation;
    public float distance;

	// Use this for initialization
	void Start () {
        updatePosition();
    }
	
	// Update is called once per frame
	void Update () {
	    if (distance!=transform.position.z)
        {
            updatePosition();
        }
	}

    void updatePosition()
    {
        this.transform.position = cameraLocation.position;
        this.transform.LookAt(cameraLocation);
        this.transform.position = new Vector3(cameraLocation.position.x, cameraLocation.position.y, cameraLocation.position.z+distance);
    }
}
