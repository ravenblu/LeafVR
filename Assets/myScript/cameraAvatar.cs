using UnityEngine;
using System.Collections;

public class cameraAvatar : MonoBehaviour {

	public Camera cam;
    public Vector2 screenCoord = new Vector2(0f, 0f);
	public float distance;

    private Vector3 camPos;
    private GameObject cardboardSet;
    private Transform cbTrans;

    // Use this for initialization
    void Start () {
        cardboardSet = GameObject.FindGameObjectWithTag("MainCamera");
        cbTrans = cardboardSet.transform;
        camPos = cam.transform.position;
        Vector3 newPos = new Vector3(camPos.x, camPos.y + screenCoord.y, camPos.z + distance);//critical to place the leaf in front of the cam
        this.transform.position = newPos;
        this.transform.LookAt(cam.transform.position);//add the texture of the leaf
	}
	
	// Update is called once per frame
	void Update () {
        /*
        float smoothTime = 0.1F;
        
        Vector3 targetPosition = this.transform.TransformPoint(new Vector3(0, 5, -10));
        cbTrans.position = Vector3.SmoothDamp(camPos, targetPosition, ref velocity, smoothTime);
        */
        
    }

    public void cameraPosUpdate(float velocity)
    {
        Vector3 oldPos = cbTrans.position;
        Vector3 newPos = new Vector3(oldPos.x, oldPos.y, oldPos.z + velocity);
        cbTrans.position = newPos;
    }
}
