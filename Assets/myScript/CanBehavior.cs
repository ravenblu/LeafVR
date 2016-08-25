using UnityEngine;
using System.Collections;

public class CanBehavior : MonoBehaviour {

    public Transform target;
    private Rigidbody body;
    public float acceleration;

    private float adjustedAcc;
    private bool hasBirthed;

    private float age;
    public float lifespan;

    private Vector3 lastPlayerPosition;
    private Quaternion lastQuat;
    private Vector3 difference;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        age = 0f;
        //this.transform.LookAt(player.transform);
        //lastQuat = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(target);
       // float distance = Mathf.Abs(Vector3.Distance(this.transform.position, target.position));
        adjustedAcc = acceleration;
       // if (distance < 1f) adjustedAcc = .2f;
        body.AddForce(transform.forward*adjustedAcc);
        if (age != 0f && age>=lifespan)
        {
            // send flying into death portal instead, then have a collider watch
            this.transform.parent = null;
            GameObject.Destroy(this.gameObject);
        }
        age += Time.deltaTime;
        //lastQuat = transform.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        this.transform.parent = null;
        GameObject.Destroy(this.gameObject);

    }
}
