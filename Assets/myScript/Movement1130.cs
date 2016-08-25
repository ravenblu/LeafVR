/*

	This script is for smooth character control (camera following and the character reacting to head-tilting).
	NO SOUND INPUT FOR THIS PROTOTYPE.

	Author: Jiayu Liu
	Date: 11/30/2015
	
*/

using UnityEngine;
using System.Collections;

public class Movement1130 : MonoBehaviour {

	public CardboardHead head;

	public Rigidbody rb;
	public float v; //velocity

	private bool updated;
	private bool updated1;
	public bool trackRotation = true;
	public bool trackPosition = true;
	public Transform target;

	//public float distance;
	public float damping = 5.0f;

	// Use this for initialization
	void Start () {

		rb.velocity = head.Gaze.direction * v;


	}


	// Update is called once per frame
	void Update () {
	
		//Track the head position and update with the leaf
		UpdateHead ();

	}


	private void UpdateHead() {
		if (updated) {  // Only one update per frame
			return;
		}
		updated = true;
		Cardboard.SDK.UpdateState();


		if (trackRotation) {
			var rot = Cardboard.SDK.HeadPose.Orientation;
			if (target == null) {
				transform.localRotation = rot;
			} else {
				transform.rotation = target.rotation * rot;
			}
		}
		
		//if (trackPosition) {
			Vector3 pos = Cardboard.SDK.HeadPose.Position;
		//	if (target == null) {
		//		transform.localPosition = pos;
		//	} else {
		//		transform.position = Vector3.Lerp (this.transform.position, target.position + target.rotation * pos, Time.deltaTime * damping);
		//		cam.transform.position = Vector3.Lerp (pos, target.position + target.rotation * pos, Time.deltaTime * damping);
		//	}
		//}
	}

}
