using UnityEngine;
using System.Collections;

public class LeafMovement : MonoBehaviour {

	public Rigidbody rb;
	public float speed;
	public float timeCount;
	public float slowMotion;

	private float fracJourney;
	private float startTime;
	private float distCovered;
	private float journeyLength;
	private float timeCount_temp = 0.0f;
	private float lastTime;
	
	private float lastRecordingTime = 0.0f;


	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
		startTime = Time.time;
		journeyLength = Vector3.Distance (Camera.main.transform.position, this.transform.position);

		rb.velocity = new Vector3 (0f, 0f, speed);

		AudioSource aud = GetComponent<AudioSource> ();
		aud.mute = true;
		aud.loop = true;
		aud.clip = Microphone.Start(null, false, 5, 44100);
	}


	// Update is called once per frame
	void Update () {

		//Get the camera to follow the leaf
		distCovered = (Time.time - startTime) * speed;
		startTime = Time.time;
		fracJourney = distCovered / journeyLength;
		Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, this.transform.position, fracJourney);

		//Leaf movement reacts to the sound
		if (soundDetected ()) {
			//slow motion, if the sound stops, the leaf goes back to original speed
			Time.timeScale = slowMotion;
			lastTime = Time.time;
			Debug.Log ("aaaaaaaaaahhhhhhhhh");
		}
		else {
			if (timeCount_temp > timeCount)
				Time.timeScale = 0.99f;
		}
		timeCount_temp = Time.time - lastTime;


		//Time reset
		if (Time.time - lastRecordingTime > 5) {
			lastRecordingTime = Time.time;
			AudioSource aud = GetComponent<AudioSource> ();
			aud.clip = Microphone.Start (null, false, 5, 44100);
		}
	
	}

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
