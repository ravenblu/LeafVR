using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float currentSpeed;
    public float acceleration;
    public float speed;
    public float maxSpeed;

    public Vector3 acc;
    public Vector3 maxDSpeed;
    public Vector3 maxBSpeed;

    private Rigidbody body;
    private GameObject cardboardSet;
    private cameraAvatar avaCam;

    private float timePassed;
    private Vector3 camPos;

    private AudioSource audio;
    private float loudness;

    public bool boostMode;
    public CanSpawn can;
    private Microphone mic;

    // Use this for initialization
    void Start () {
        avaCam = GetComponent<cameraAvatar>();
        cardboardSet = GameObject.FindGameObjectWithTag("MainCamera");
        body = this.GetComponent<Rigidbody>();
        acc = new Vector3(0f, 0f, acceleration);
        maxDSpeed = new Vector3(0f, 0f, speed);
        maxBSpeed = new Vector3(0f, 0f, maxSpeed);
        body.velocity = maxDSpeed;
        camPos = cardboardSet.transform.position;
        timePassed = 0f;

        audio = GetComponent<AudioSource>();
        audio.clip = Microphone.Start(null, true, 10, 44100);
    }
	
	// Update is called once per frame
	void Update () {
        // update time
        timePassed += Time.deltaTime;

        /*
        // Add basic directional speed to the Leaf
        if (body.velocity.z < speed)
        {
            body.AddForce(acc);
            currentSpeed = body.velocity.z;
        } else if (body.velocity.z >= speed)
        {
            body.velocity = maxSpeed;
        }

        // Get the camera to follow the leaf
        if (body.velocity.z > 0f)
        {
            avaCam.cameraPosUpdate(currentSpeed*Time.deltaTime);
            camPos.y = camPos.y + Mathf.Sin(timePassed)*.75f;
        }
        */

        loudness = GetAveragedVolume();
        if (loudness>.1f)
        {
            boostMode = true;
        }

        // Add basic directional speed to the Leaf
        if (body.velocity.z < maxSpeed && boostMode)
        {
            body.AddForce(acc);
            currentSpeed = body.velocity.z;
        }
        else if (body.velocity.z >= maxSpeed && boostMode)
        {
            body.velocity = maxBSpeed;
        }
        else if (!boostMode && body.velocity.z >= speed)
        {
            //body.AddForce(-acc);
            currentSpeed = body.velocity.z;
        }

        // Get the camera to follow the leaf
        if (body.velocity.z > 0f)
        {
            avaCam.cameraPosUpdate(currentSpeed * Time.deltaTime);
            camPos.y = camPos.y + Mathf.Sin(timePassed) * .75f;
        }
    }   

    /*
    void updateAcc()
    {
        if ()
    }*/
    void updateVel()
    {

    }
    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        audio.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}
