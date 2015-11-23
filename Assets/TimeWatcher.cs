using UnityEngine;
using System.Collections;

public class TimeWatcher : MonoBehaviour {

    public float startTime;
    public float currentTime;

    public bool hasStarted;

	// Use this for initialization
	void Start () {
        hasStarted = false;
	}
	
    public void SetGameBeginning()
    {
        startTime = Time.time;
        hasStarted = true;
    }

	// Update is called once per frame
	void Update () {
        if (!hasStarted) return;
	}

    public float getTime()
    {
        return (Time.time - startTime);
    }

    public int getSeconds()
    {
        return Mathf.FloorToInt(getTime()) % 60;
    }
    public int getMinutes()
    {
        return Mathf.FloorToInt(getTime() / 60f);
    }
}
