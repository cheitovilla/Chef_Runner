using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour 
{

	private Transform target;
	private Vector3 offSet;

	// Use this for initialization
	void Start () 
	{
		target =	GameObject.FindGameObjectWithTag ("Player").transform;
		offSet = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = target.position + offSet;
	}
}
