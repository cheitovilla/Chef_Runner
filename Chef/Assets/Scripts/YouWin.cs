using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour 
{
	public GameObject player;
	public GameObject win;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player.transform.position.z >= 450) {
			//anim.SetTrigger("showwin");
			win.SetActive(true);
		}
	}
}
