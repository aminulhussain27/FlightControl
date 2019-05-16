using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	public float speed = 40;
	void Start () {
		Debug.LogError (("Start"));
	}

	float rotPitch;
	float rotYaw;

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

		rotPitch = transform.eulerAngles.x;
		rotYaw = transform.eulerAngles.y;


		if (rotPitch > 30 && rotPitch < 180) 
		{
			rotPitch = 30;
		}
		else if (rotPitch < 330 && rotPitch > 180) 
		{
			rotPitch = 330;
		}

		if (rotYaw > 30 && rotYaw < 180) 
		{
			rotYaw = 30;
		}
		else if (rotYaw < 330 && rotYaw > 180) 
		{
			rotYaw = 330;
		}
		transform.rotation = Quaternion.Euler (rotPitch, 0, rotYaw);
	}
}
