using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hudScript : MonoBehaviour {

	public Text meatTxt, ratsTxt, bonesTxt, leatherTxt;
	public int meatInt = 0, ratsInt = 0, bonesInt = 0, leatherInt = 0;
	public generalScript gen;


	// Use this for initialization
	void Start () {
		gen = Camera.main.GetComponent<generalScript> ();
		
	}


	// Update is called once per frame
	void Update () {
		meatTxt.text = gen.Viande + "";
		ratsTxt.text = gen.Rats + "";
		bonesTxt.text = gen.Os + "";
		leatherTxt.text = gen.Cuir + "";
	}
}
