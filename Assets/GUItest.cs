using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUItest : MonoBehaviour {

	public Texture btnTexture;

    public bool isPlaying;

	// Use this for initialization
	void Start () {
        isPlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI () {

		if (!isPlaying) {

			//if (!btnTexture) {
			//	Debug.LogError ("Please assign a texture on the inspector");
			//	return;
			//}

			//if (GUI.Button (new Rect (10, 10, 50, 50), btnTexture))
			//	Debug.Log ("Clicked the button with an image");
			if (GUI.Button (new Rect (300, 0, 100, 20), "Play")) {
				Application.LoadLevel ("DemoClone");
				Debug.Log ("Game starts");
			}

			if (GUI.Button (new Rect (Screen.width * 0.4f, Screen.height * 0.2f, 0, 0), "Restart")) {
				Application.LoadLevel ("DemoClone");
				Debug.Log ("Restart the game");
                isPlaying = true;
			}
		}
		
	}
}
