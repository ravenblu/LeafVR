using UnityEngine;
using System.Collections;

public class NewSkyBoxBehaviour : MonoBehaviour {
	
	public Color colorStart = Color.black;
	public Color colorEnd = Color.white;
	public float max_position_xy = 1100.0F;
	private float currentposition = 10.0F;
	public float darkness_offset = 100.0F;
		
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {

		currentposition = Mathf.Sqrt (Mathf.Pow (transform.position.x, 2.0f) + Mathf.Pow (transform.position.z, 2.0f));
		
		float lerp = Mathf.PingPong((currentposition-darkness_offset), max_position_xy) / max_position_xy;
		print (lerp);

      	RenderSettings.skybox.SetColor ("_Tint", Color.Lerp (colorStart, colorEnd, lerp));
    }
}