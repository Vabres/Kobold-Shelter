using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class persoListScript : MonoBehaviour {

	public GameObject perso, fichePerso;
	public Text name;
	public Sprite wariorIcon, gathererIcon, workerIcon;
	public Image icon;
	public int nbDePerso = 0;

	// Use this for initialization
	void Start () {
			
	}

	public void appui(){
		fichePerso.GetComponent<fichePersoScript> ().affichage (perso);
	
	}


	// Update is called once per frame
	void Update () {


		if (perso.job == "warior")
			icon.sprite = wariorIcon;
		if (perso.job == "gatherer") {
			icon.sprite = gathererIcon;
		}
		if (perso.job == "worker") {
			icon.sprite = workerIcon;
		}
	}
}
