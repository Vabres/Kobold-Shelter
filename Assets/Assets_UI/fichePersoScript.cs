using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class fichePersoScript : MonoBehaviour {

	public Text nameTxt, jobTxt, capAtkTxt, capArtTxt, capIntTxt;
	public GameObject fichePerso, perso;
	public Image barreFaim, barreVie, barreSommeil;
	public GameObject btnWar, btnGat;
	public kobScript kob;


	public void affichage(GameObject g){
		fichePerso.SetActive (true);
		kob = g.getComponents<kobScript> ();
		nameTxt.text = kob.name;
		jobTxt = kob.job;
		capArtTxt = kob.Artisanat;
		capAtkTxt = kob.Atk;
		capIntTxt = kob.Intel;
		barreSommeil.rectTransform.rect.width = kob.Sleep;
		barreFaim.rectTransform.rect.width = kob.Hunger;
		barreVie.rectTransform.rect.width = kob.PV;
		perso = g;
		if (jobTxt == "Warior") {
			jobChoiceWar ();
		}
		else if (jobTxt == "Gatherer") {
			jobChoiceGat ();
		} 
		else {
			btnGat.SetActive (true);
			btnGat.GetComponent<Button> ().enabled = true;

			btnWar.SetActive (true);
			btnWar.GetComponent<Button> ().enabled = true;
		}
	}

	public void jobChoiceWar(){
		btnGat.SetActive (false);
		btnWar.GetComponent<Button> ().enabled = false;
		perso.job = "Warior";
	}
	public void jobChoiceGat() {
		btnWar.SetActive (false);
		btnGat.GetComponent<Button> ().enabled = false;
		perso.job = "Gatherer";
	}

	public void masquage(){
		fichePerso.SetActive (false);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
