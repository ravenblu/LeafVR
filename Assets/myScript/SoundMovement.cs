using UnityEngine;
using System.Collections;

public class SoundMovement : MonoBehaviour {
	
	public float acceleration;

	//private float timePassed;
	public float velocity;

    public CardboardHead head;

	public Vector3 acc;
	public float drag; 

	public float lastRecordingTime = 0f;

	public Rigidbody rb;
	//public GameObject cardboardSet;
	private cameraAvatar avaCam;
	private Vector3 camPos;

	private Transform lastTrans;
	public float damping = 5.0f;

    //public CanSpawn can;

	//private static string[] micArray = null;


	// Use this for initialization
	void Start () {

		//avaCam = GetComponent<cameraAvatar>();
		//cardboardSet = GameObject.FindGameObjectWithTag("MainCamera");
		rb = this.GetComponent<Rigidbody>();
		acc = new Vector3(0f, 0f, acceleration);
		//camPos = cardboardSet.transform.position;

		AudioSource aud = GetComponent<AudioSource> ();
		aud.mute = true;
		aud.loop = true;
		//foreach (string device in Microphone.devices) {
		//	Debug.Log ("Name" + device);
		//}
		//micArray = Microphone.devices;
		//if (micArray.Length == 0) {
		//	Debug.Log ("No mic device detected!");
		//}
		aud.clip = Microphone.Start(null, false, 5, 44100); // You can change the length of recording here

		//head.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);
		//head.transform.LookAt(this.transform);

		//rb.velocity = new Vector3 (0f, 0f, velocity);

		lastTrans = this.transform;
    }




	// Update is called once per frame
	void Update () {

		if (soundDetected ()) {
			//Expel, or push the cans forward







			//Let the camera follow the leaf
			//head.transform.position = Vector3.Lerp (transform.position, lastTrans.position, Time.deltaTime * damping);
			//lastTrans = this.transform;
		}

		
        if (Time.time - lastRecordingTime > 5) {
			Debug.Log ("Time reset");
			lastRecordingTime = Time.time;
			AudioSource aud = GetComponent<AudioSource> ();
			aud.clip = Microphone.Start(null, false, 5, 44100);
		}

    }//update

	
	bool soundDetected() {

		AudioSource aud = GetComponent<AudioSource> ();
		float sampleMaxValue = 0.0f;
		float[] samples = new float[aud.clip.samples * aud.clip.channels];
		aud.clip.GetData (samples, 0);

        
		int i = 0;
		while (i <samples.Length) {
			samples [i] = samples [i] * 0.5f;
			++i;
		}

        
		aud.clip.SetData (samples, 0);

		foreach (float s in samples) {
			float m = Mathf.Abs(s);
			if (sampleMaxValue < m)
				sampleMaxValue = m;
		}

		if (sampleMaxValue > 0.1)
			return true;
		else
			return false;
	}


}