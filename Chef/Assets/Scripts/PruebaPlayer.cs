using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaPlayer : MonoBehaviour {

	private Rigidbody rb;
	public Transform pos;
	public float velHoriz = 0;
	public float velVert = 0;
	public int laneNum = 2;
	public int upNum = 2;
	public string control = "n";
	public float JumpForcee;

	// Use this for initializatioint n
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
	//	rb.velocity = new Vector3 (velHoriz, velVert, 4);
	}
	
	// Update is called once per frame
	void Update () {

		//GetComponent<Rigidbody> ().velocity = new Vector3 (velHoriz, velVert, 4);
		rb.velocity = new Vector3(velHoriz,rb.velocity.y,4);



		if (Input.GetKeyDown(KeyCode.LeftArrow) && (laneNum>1) && control == "n") {
			velHoriz = -6;
			StartCoroutine (stopSlide ());
			laneNum -= 1;
			control = "y";
		}
	
		if (Input.GetKeyDown(KeyCode.RightArrow) && (laneNum<3) && control == "n") {
			velHoriz = 6;
			StartCoroutine (stopSlide ());
			laneNum += 1;
			control = "y";
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			rb.velocity = new Vector3 (velHoriz, JumpForcee, 4);
		}
//		

	
	
	
	}

	IEnumerator stopSlide()
	{
		yield return new WaitForSeconds (.5f);
		velHoriz = 0;
		control = "n";

	}

//	IEnumerator stopJump()
//	{
//		yield return new WaitForSeconds (.5f);
//		velVert = 0;
//		control = "n";
//	}
	

}
