using UnityEngine;
using System.Collections;

public class HealthMan : MonoBehaviour {
    public int health = 90;


    public bool gameRunning;
	// Use this for initialization
	void Start () {
        gameRunning = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void death()
    {
        if (gameRunning)
        {

            gameRunning = false;
        }
    }
}
