using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recolector : MonoBehaviour 
{
	public Text countTextDiamond;
	private int countDiamond;

	// Use this for initialization
	void Start ()
	{
		countDiamond = 0;
		SetCountText ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Diamante1")) {
			//audio.SonarDiamante ();
			other.gameObject.SetActive (false);
			countDiamond += 10;
			Debug.Log (countDiamond);
			SetCountText ();
		}

		if (other.gameObject.CompareTag ("Diamante2")) {
			//audio.SonarDiamante ();
			other.gameObject.SetActive (false);
			countDiamond += 20;
			Debug.Log (countDiamond);
			SetCountText ();
		}

		if (other.gameObject.CompareTag ("Diamante3")) {
			//audio.SonarDiamante ();
			other.gameObject.SetActive (false);
			countDiamond += 30;
			Debug.Log (countDiamond);
			SetCountText ();
		}
	}

	public void SetCountText ()
	{
		countTextDiamond.text = "Diamonds: " + countDiamond.ToString ();
		//puntajeFinalText.text = countDiamond.ToString ();
	}

}
