using UnityEngine;
using System.Collections;

public class SoundMovement : MonoBehaviour {
	
	public float acceleration;

	//private float timePassed;
	private float currentSpeed = 0f;

	public Vector3 acc;
	public Vector3 maxSpeed;
	public Vector3 minSpeed;

	private Rigidbody rb;
	private GameObject cardboardSet;
	private cameraAvatar avaCam;
	private Vector3 camPos;

    public CanSpawn can;

	private static string[] micArray = null;


	// Use this for initialization
	void Start () {

		avaCam = GetComponent<cameraAvatar>();
		cardboardSet = GameObject.FindGameObjectWithTag("MainCamera");
		rb = this.GetComponent<Rigidbody>();
		acc = new Vector3(0f, 0f, acceleration);
		maxSpeed = new Vector3(0f, 0f, currentSpeed);
		rb.velocity = Vector3.zero;
		camPos = cardboardSet.transform.position;
		//timePassed = 0f;

		AudioSource aud = GetComponent<AudioSource> ();
		foreach (string device in Microphone.devices) {
		//	Debug.Log ("Name" + device);
		}
		micArray = Microphone.devices;
		if (micArray.Length == 0) {
		//	Debug.Log ("No mic device detected!");
		}
		aud.clip = Microphone.Start(null, false, 100, 44100); // You can change the length of recording here
        
	}




	// Update is called once per frame
	void Update () {

		// Update time
		//timePassed += Time.deltaTime;
		//Debug.Log ("Time" + timePassed);

		// if the microphone is not working, ask the user to check mic
		if (!Microphone.IsRecording(null)) {
			//Debug.Log ("Please check your microphone.");
		} 

		// if the microphone is working, detect sound and do corresponding character control
		else {

		//	Debug.Log ("Mic working fine");

			if(soundDetected()) {
			//	Debug.Log("Sound detected~~~~");
				rb.AddForce(0f,0f,acceleration * rb.mass);
				currentSpeed += acceleration * Time.deltaTime; // vt = v0 + at
				if (currentSpeed > maxSpeed.z) {
					currentSpeed = maxSpeed.z;
				}
                can.activate();
			//	Debug.Log ("The current speed is " + currentSpeed);
			}

			else
			{
			//	Debug.Log("Sound not detected!");
				currentSpeed -= rb.drag * Time.deltaTime;
				if (currentSpeed < minSpeed.z) {
					currentSpeed = minSpeed.z;
				}
                can.deactivate();
			//	Debug.Log ("The current speed is" + currentSpeed);
			}



		}

        // Get the camera to follow the leaf
        if (rb.velocity.z > 0f)
        {
            avaCam.cameraPosUpdate(currentSpeed * Time.deltaTime);
        }

    }//update
	
	bool soundDetected() {

		AudioSource aud = GetComponent<AudioSource> ();
		float sampleMaxValue = 0.0f;
		float[] samples = new float[aud.clip.samples * aud.clip.channels];
		aud.clip.GetData (samples, 0);

        /*
		int i = 0;
		while (i <samples.Length) {
			samples [i] = samples [i] * 0.5f;
			++i;
		}*/

        for (int i=0; i<samples.Length; i++)
        {
            samples[i] = samples[i] * 0.5f;
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