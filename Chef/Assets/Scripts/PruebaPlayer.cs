using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PruebaPlayer : MonoBehaviour
{

	private Rigidbody rb;
	public float velHoriz = 0;
	public float velVert = 0;
	public float velForward = 4;
	public int laneNum = 2;
	public string control = "n";
	public float JumpForcee;

	public bool enSuelo = true;
	public int life = 3;
	public Text lifeText;

	public bool isDead = false;

	Animator anim;

	// Use this for initializatioint n
	void Start () 
	{
		rb = this.GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	//	rb.velocity = new Vector3 (velHoriz, velVert, 4);
	}
	
	// Update is called once per frame
	void Update () {

		if (isDead)
			return;
		//GetComponent<Rigidbody> ().velocity = new Vector3 (velHoriz, velVert, 4);
		rb.velocity = new Vector3(velHoriz,rb.velocity.y,velForward);
		//anim.SetTrigger ("running");


		if (Input.GetKeyDown(KeyCode.LeftArrow) && (laneNum>1) && control == "n") 
		{
			velHoriz = -6;
			StartCoroutine (stopSlide ());
			laneNum -= 1;
			control = "y";
		}
	
		if (Input.GetKeyDown(KeyCode.RightArrow) && (laneNum<3) && control == "n") 
		{
			velHoriz = 6;
			StartCoroutine (stopSlide ());
			laneNum += 1;
			control = "y";
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			if (enSuelo) 
			{
				enSuelo = false;
				anim.SetTrigger ("jump");
				rb.velocity = new Vector3 (velHoriz, JumpForcee, velForward);
			}

		}
			
	}

	IEnumerator stopSlide()
	{
		yield return new WaitForSeconds (.5f);
		velHoriz = 0;
		control = "n";

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
				Lost();
			}
		}
	}

	public void Lost()
	{
		isDead = true;
		anim.SetTrigger ("dead");
		GetComponent<Score> ().Death ();
		Debug.Log ("Morí");
	}

	public void Setspeed(float modifer)
	{
		velForward = 4f + modifer;
	}
	

}
