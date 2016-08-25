using UnityEngine;
using System.Collections;

public class CanSpawn : MonoBehaviour {

    public GameObject canParentObject;
    //public GameObject target;
    public GameObject canObject;

    public float spawnInterval;
    public float horizontalRange;
	public float verticalRange;
    public float zRange;
    public float yRange;
    //public float massVariance;
    public int perSpawnPoint;
   // public float canAcceleration;
    public float canlifespan;

    public float timer;

    public GameObject[] objects;

	public float spawnDist; // Spawning distance to the leaf

    private Vector3 position;
    private Vector3 parentPos;

    public bool activeSpawn;

	// Use this for initialization
	void Start () {
        //	objects = new GameObject[]()
        timer = 0f;
        canObject = Resources.Load("canProto") as GameObject;
        position = this.transform.position;

        //target = new GameObject();
        //parentPos = this.transform.parent.transform.position;
        //target.transform.position = new Vector3(parentPos.x, parentPos.y, parentPos.z - canAcceleration);
		//target.transform.position = new Vector3 (parentPos.x, parentPos.y, parentPos.z);
        activeSpawn = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!activeSpawn) return;
        if (timer>=spawnInterval)
        {
            // figure out the number of cans to spawn right now;
            int spawnNum = Random.Range(1, perSpawnPoint);

            // spawn a certain number of cans
            for (int i=0; i< spawnNum; i++)
            { 
                position = this.transform.position;
                GameObject newCan = GameObject.Instantiate(canObject);

				//float newX = position.x + Random.Range(-horizontalRange,horizontalRange);
				float newX = Random.Range(-horizontalRange,horizontalRange);
				//float newY = position.y;
				float newY = Random.Range(-verticalRange,verticalRange);
				float newZ = position.z + spawnDist;
			
                //float horizontal = horizontalRange * Random.value;
                //float newX = position.x - (horizontal*2f) + horizontal;
                //float newY = position.y + yRange * Random.value;
                //float newZ = position.z + zRange * Random.value;
               // Rigidbody canBody = newCan.GetComponent<Rigidbody>();
                //canBody.mass = canBody.mass + massVariance * Random.value;
                //newCan.transform.position = new Vector3(newX, newY, newZ);
				newCan.transform.position = new Vector3 (newX, newY, newZ);
                newCan.transform.parent = canParentObject.transform;
                CanBehavior newCanBehavior = newCan.GetComponent<CanBehavior>();
                //newCanBehavior.acceleration = canAcceleration;
                newCanBehavior.lifespan = canlifespan;
                //newCanBehavior.target = target.transform;

            }
            timer = 0f;
        }

        timer += Time.deltaTime;
        //parentPos = this.transform.parent.transform.position;
        //target.transform.position = new Vector3(parentPos.x, parentPos.y, parentPos.z + (0f));
    }

    public void activate()
    {
        if (!activeSpawn) activeSpawn = true;
    }
    public void deactivate()
    {
        if (activeSpawn) activeSpawn = false;
        // take all the objects, make them dumb
    }
}
