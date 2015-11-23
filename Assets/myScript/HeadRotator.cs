using UnityEngine;
using System.Collections;

public class HeadRotator : MonoBehaviour {

    public Transform head;

    private Quaternion lastHeadAngle;
    private float angleDifference;

	// Use this for initialization
	void Start () {
        lastHeadAngle = head.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	    angleDifference = Quaternion.Angle(lastHeadAngle, head.rotation);

        if (angleDifference>0f)
        {

        }

        lastHeadAngle = head.rotation;
    }
}
