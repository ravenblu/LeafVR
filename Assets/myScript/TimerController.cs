using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerController : MonoBehaviour {

    //static float timer = 0.0f;
    public TimeWatcher time;
	public Text text_box;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //timer += Time.deltaTime;

        text_box.text = time.getMinutes().ToString("00") + ":" + time.getSeconds().ToString("00");
	}
}
