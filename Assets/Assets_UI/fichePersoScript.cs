using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class fichePersoScript : MonoBehaviour {

	public Text nameTxt, jobTxt, capAtkTxt, capArtTxt, capIntTxt;
	public GameObject fichePerso, perso;
	public Image barreFaim, barreVie, barreSommeil;
	public GameObject btnWar, btnGat;


	public void affichage(GameObject g){
		fichePerso.SetActive (true);
		//nameTxt.text = g.nomduperso;
		//jobTxt = g.jobduperso;
		//capArtTxt = g.artduperso;
		//capAtkTxt = g.atkduperso;
		//capIntTxt = g.intduperso;
		//barreSommeil.rectTransform.rect.width = g.sommeil;
		//barreFaim.rectTransform.rect.width = g.faim;
		//barreVie.rectTransform.rect.width = g.life;
		perso = g;
		/*if (g.job == "Warior") {
			jobChoiceWar ();
		}
		else if (g.job == "Gatherer") {
			jobChoiceGat ();
		} 
		else {
			btnGat.SetActive (true);
			btnGat.GetComponent<Button> ().enabled = true;

			btnWar.SetActive (true);
			btnWar.GetComponent<Button> ().enabled = true;
		}*/
	}

	public void jobChoiceWar(){
		btnGat.SetActive (false);
		btnWar.GetComponent<Button> ().enabled = false;
		//perso.job = "Warior";
	}
	public void jobChoiceGat() {
		btnGat.SetActive (false);
		btnWar.GetComponent<Button> ().enabled = false;
		//perso.job = "Gatherer";
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
