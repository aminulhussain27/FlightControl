using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	public float speed = 40;
	void Start () {
		Debug.LogError (("Start"));
	}

	float xAxis = 0;
	float yAxis = 0;
	float zAxis = 0;
	// Update is called once per frame
	void Update () {

		Vector3 moveCamera = transform.position - transform.forward * 10f + Vector3.up * 5f;
		float bias = 0.96f;
		Camera.main.transform.position = Camera.main.transform.position * bias + moveCamera * (1f - bias);
		Camera.main.transform.LookAt (transform.position + transform.forward * 30f);

		transform.position += transform.forward * Time.deltaTime * speed;

		speed -= transform.forward.y * Time.deltaTime * 30f;
		if(speed < 20 )
		{
			speed = 20;
		}

		transform.Rotate (Input.GetAxis ("Vertical"), 0.0f, -Input.GetAxis ("Horizontal"));





//		float hortemp = Input.GetAxis("Horizontal");
//		transform.Rotate(0, 0, -hortemp);

//		Vector3 currentRotation = transform.rotation.eulerAngles;
//		Debug.LogError (currentRotation);
//
//		currentRotation.x = Mathf.Clamp(currentRotation.x, 330f, 390f);
//		currentRotation.z = Mathf.Clamp(currentRotation.z, 330f, 390f);
//
//		transform.rotation = Quaternion.Euler(currentRotation);
	}
}
