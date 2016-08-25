using UnityEngine;
using System.Collections;

public class CanBehavior : MonoBehaviour {

    public Transform target;
    private Rigidbody body;
    public float acceleration;
	public AudioClip hit;

    private float adjustedAcc;
    private bool hasBirthed;

    private float age;
    public float lifespan;

    private Vector3 lastPlayerPosition;
    private Quaternion lastQuat;
    private Vector3 difference;

	public Vector3 newPos;

	private CanSpawn canSpawnInstance;
	private LeafMovement LeafMovementInstance;

	private int flag = 0;
	private bool temp;


	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        age = 0f;
        //this.transform.LookAt(player.transform);
        //lastQuat = transform.rotation;
		LeafMovementInstance = GetComponent<LeafMovement> ();
    }
	
	// Update is called once per frame
	void Update () {
        //this.transform.LookAt(target);
       // float distance = Mathf.Abs(Vector3.Distance(this.transform.position, target.position));
        //adjustedAcc = acceleration;
       // if (distance < 1f) adjustedAcc = .2f;
        //body.AddForce(transform.forward*adjustedAcc);
        if (age != 0f && age>=lifespan)
        {
            // send flying into death portal instead, then have a collider watch
            this.transform.parent = null;
            GameObject.Destroy(this.gameObject);
        }
        age += Time.deltaTime;
        //lastQuat = transform.rotation;

    }

    void OnTriggerEnter(Collider collision)
    {
		Debug.Log ("Collide");
        if (collision.CompareTag("Player"))
        {
			//Debug.Log ("Player");
			//GameObject player = collision.gameObject;
			//AudioSource audio = player.GetComponent<AudioSource>();
			//audio.PlayOneShot (hit, 0.7f);
            //Debug.Log(collision.name);
			Handheld.Vibrate();
            this.transform.parent = null;
            Variables.HealthDecrement(1f);
            GameObject.Destroy(this.gameObject);
        }
    }
	
}
