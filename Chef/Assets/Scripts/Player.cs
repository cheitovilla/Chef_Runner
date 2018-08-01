using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{

	public float moveSpeed = 5.0f;
	public float Jumpforce;
	private Rigidbody rb;
	public int life = 3;
	public Text lifeText;

	public bool enSuelo = true;
//	private bool isDead = false;


	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}


	// Update is called once per frame
	void Update () 
	{
		rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, moveSpeed);

		if (Input.GetKeyDown(KeyCode.UpArrow)) 
		{
			if (enSuelo) 
			{
				enSuelo = false;
				rb.velocity = new Vector3 (rb.velocity.x, Jumpforce, moveSpeed);
			}
		}

		if (Input.GetKeyDown(KeyCode.RightArrow)) 
		{
			rb.velocity = new Vector3 (rb.velocity.x + 3, rb.velocity.y, moveSpeed);	
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow)) 
		{
			rb.velocity = new Vector3 (rb.velocity.x - 3, rb.velocity.y, moveSpeed);	
		}
	}


	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Piso") 
		{
			enSuelo = true;	
		}

		if (collision.gameObject.tag == "Obstaculo") 
		{
			life--;
			lifeText.text = "Vidas: " + life.ToString ();
			Destroy (collision.gameObject);
			if (life<=0) {
				//Lost();
			}
		}
	}



}
