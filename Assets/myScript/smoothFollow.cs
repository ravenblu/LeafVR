using UnityEngine;
using System.Collections;

public class smoothFollow : MonoBehaviour {

	public GameObject leaf;
	public Transform target;
	public float distance;
	public float damping = 5.0f;

	// Use this for initialization
	void Start () {

		leaf = GameObject.FindGameObjectWithTag ("Player");
		distance = 1.5f;

	}
	
	// Update is called once per frame
	void Update () {

		target.position = new Vector3 (leaf.transform.position.x, leaf.transform.position.y, leaf.transform.position.z - distance);
		transform.position = Vector3.Lerp (this.transform.position, target.position, Time.deltaTime * damping);

	}
}
