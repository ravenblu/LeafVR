using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderTest : MonoBehaviour {

	//public const int InitialGameSlider = 0;
	public Slider GameSlider;

	// Use this for initialization
	void Start () {
		GameObject temp = GameObject.Find("GameSlider");

		GameSlider = temp.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
	
		GameSlider.value = 80;
	}
}
