using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatScript : MonoBehaviour {
    List<GameObject> combattants = new List<GameObject>();
    public bool startAlert = false;
    public bool stopAlert = false;

    public int battleCount = 0;
    public float battleTime = 0;
    public float nextbattleTime = 0;

    public int ennemyPv, ennemyDmg;
    public int allyDMG;
    public int Dammage;



    public bool battleStart = false;

    



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ProcessBattle();
        nextbattleTime += Time.deltaTime;

        if (nextbattleTime >= 300 )
        {
            nextbattleTime = 0;
            StartBattle();
        }
	}

    void StartBattle()
    {
        startAlert = true;
        battleStart = true;

        for(int i = 0; i < combattants.Count; i++)
        {
            combattants[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }


    void GenerateEnnemy()
    {
        ennemyDmg = battleCount + 2;
        ennemyPv = battleCount + battleCount / 2;
    }

    void ProcessBattle()
    {
        if (battleStart)
        {
            battleTime += Time.deltaTime;
            if (battleTime >= 60)
            {
                allyDMG = 0;
                Dammage = 0;
                for(int i = 0; i < combattants.Count; i++)
                {
                    allyDMG += combattants[i].GetComponent<kobScript>().Atk;
                }

                while(ennemyPv - allyDMG > 0)
                {
                    ennemyPv -= allyDMG;
                    Dammage += ennemyDmg;
                }

                EndBattle(Dammage);
            }
        }
    }

    void EndBattle(int dammage)
    {
        battleCount++;
        for(int i = 0; i < dammage; i++)
        {
            combattants[i%combattants.Count].GetComponent<kobScript>().PV--;
        }
        Camera.main.GetComponent<generalScript>().Os += ennemyDmg/2;
        Camera.main.GetComponent<generalScript>().Cuir += ennemyPv/2;
        Camera.main.GetComponent<generalScript>().Viande += ennemyPv;
        stopAlert = true;

        for (int i = 0; i < combattants.Count; i++)
        {
            combattants[i].GetComponent<SpriteRenderer>().enabled = true;
        }

    }

    void GetCombatant()
    {
        for (int i = 0 ; i < Camera.main.GetComponent<generalScript>().Kob.Count; i++)
        {
            if (Camera.main.GetComponent<generalScript>().Kob[i].GetComponent<kobScript>().job == "warrior")
            {
                combattants.Add(Camera.main.GetComponent<generalScript>().Kob[i]);
            }
        }
    }
}
