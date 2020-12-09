using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public float zoomSpeed = 1f;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		
	}

	void Update(){
		
		// zoom out
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) 
		{
			if (transform.position.y > 60) 
			{
				Vector3 move = transform.position.y * zoomSpeed * transform.forward;
				transform.Translate (move, Space.World);
			}
		}
		// zoom in
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) 
		{
			if (transform.position.y < 110) 
			{
				Vector3 move = transform.position.y * zoomSpeed * -transform.forward;
				transform.Translate (move, Space.World);			
			}
		}
	}
}