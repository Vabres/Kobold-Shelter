using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hudScript : MonoBehaviour {

	public Text meatTxt, ratsTxt, bonesTxt, leatherTxt;
	public int meatInt = 0, ratsInt = 0, bonesInt = 0, leatherInt = 0;


	// Use this for initialization
	void Start () {
		
		
	}
	// Update is called once per frame
	void Update () {
		meatTxt.text = meatInt + "";
		ratsTxt.text = ratsInt + "";
		bonesTxt.text = bonesInt + "";
		leatherTxt.text = leatherInt + "";
	}
}
