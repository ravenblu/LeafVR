using UnityEngine;
using System.Collections;

public class SoundMovement : MonoBehaviour {
	
	public float acceleration;

	//private float timePassed;
	public float velocity;

    public CardboardHead head;

	public Vector3 acc;
	public float drag;
	//public Vector3 maxSpeed;
	//public Vector3 minSpeed;
	public float lastRecordingTime = 0f;

	public Rigidbody rb;
	public GameObject cardboardSet;
	private cameraAvatar avaCam;
	private Vector3 camPos;

    private GameObject pivot;

    //public CanSpawn can;

	//private static string[] micArray = null;


	// Use this for initialization
	void Start () {

		avaCam = GetComponent<cameraAvatar>();
		cardboardSet = GameObject.FindGameObjectWithTag("MainCamera");
		rb = this.GetComponent<Rigidbody>();
		acc = new Vector3(0f, 0f, acceleration);
		camPos = cardboardSet.transform.position;

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

        cardboardSet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);
        cardboardSet.transform.LookAt(this.transform);

        pivot = new GameObject();
        pivot.transform.position = cardboardSet.transform.position;
        pivot.transform.LookAt(this.transform);
        pivot.AddComponent<CardboardHead>();
        //pivot.transform.parent = cardboardSet.transform;
        this.transform.parent = pivot.transform;
    }




	// Update is called once per frame
	void Update () {
        //pivot.transform.LookAt(cardboardSet.transform.position);
        /*
        if (Cardboard.SDK.Tilted)
        {
            if (Cardboard.SDK.HeadRotation.z < 1f && rb.angularVelocity == Vector3.zero)
            {
                Vector3 directedAcc = Vector3.right * acceleration * rb.mass;
                rb.angularVelocity = directedAcc;
                rb.angularDrag = .5f;
            }
            else if (Cardboard.SDK.HeadRotation.z > 1f)
            {
                Vector3 directedAcc = Vector3.left * acceleration * rb.mass;
                rb.angularVelocity = directedAcc;
                rb.angularDrag = .5f;
            }
            
        }*/

		if(soundDetected()) {
			Debug.Log("Sound detected");
            //Vector3 directedAcc = Vector3.forward * acceleration *rb.mass;
            Vector3 directedAcc = head.Gaze.direction * acceleration * rb.mass;
            rb.AddForce(directedAcc);
			//rb.AddForce(0f,0f,acceleration * rb.mass);
            //can.activate();

		}

		else
		//	Debug.Log("Sound not detected");
			rb.drag = drag;

        //can.deactivate();



        //}
        pivot.transform.rotation =  Quaternion.RotateTowards(this.transform.rotation, head.transform.rotation, 1.5f*Time.deltaTime);
        //pivot.transform.rotation = Quaternion.Lerp(this.transform.rotation, head.transform.rotation, Time.deltaTime);

        // Get the camera to follow the leaf
		velocity = - rb.velocity.z;
        cardboardSet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);


        //avaCam.cameraPosUpdate(velocity);
        //cameraPosUpdate (velocity); // Disable cameraAvatar and use the function inside this script




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

	/*void cameraPosUpdate(float v) {
		cardboardSet.transform.Translate (Vector3.forward * v, this.transform.position);
	}*/

}