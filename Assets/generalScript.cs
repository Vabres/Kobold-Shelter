using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalScript : MonoBehaviour {

    public int Rats;
    public int Viande;
    public int Os;
    public int Cuir;

    public List<GameObject> Kob = new List<GameObject>();

	// Use this for initialization
	void Start () {
        Rats = 10;
        Viande = 10;
        Os = 10;
        Cuir = 10;

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
