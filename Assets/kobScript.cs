using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kobScript : MonoBehaviour {

    public int PV;
    public int Hunger;
    public int Sleep;
    public int Exp;
    public int LV;

    public string job;


    public GameObject target;

    float hungerTime;
    float sleepTime;

    // Use this for initialization
    void Start () {
        PV = 3;
        Hunger = 100;
        Sleep = 100;
        Exp = 0;
        LV = 1;
	}
	
	// Update is called once per frame
	void Update () {
        hungerTime += Time.deltaTime ;
        sleepTime += Time.deltaTime ;

        if (sleepTime >= 8)
        {
            Sleep--;
            sleepTime = 0;
            findTarget();
            if (Sleep <= 0)
            {
                sleepDepravation();
            }
        }
        if(hungerTime >= 4)
        {
            Hunger--;
            hungerTime = 0;
            findTarget();
            if (Hunger <= 0)
            {
                starvation();
            }
        }
        if (PV <= 0)
        {
            death();
        }

        if(target == null)
        {
            findTarget();
        }
        else
        {
            this.GetComponent<Transform>().localPosition = Vector3.Lerp(this.GetComponent<Transform>().localPosition, target.GetComponent<Transform>().localPosition, 1);
        }

	}

    void findTarget()
    {

       
        if (Hunger <= 20) {
            target = GameObject.Find("Start").GetComponent<startScript>().findroom("food");
        }
        else if (Sleep <= 10)
        {
            target = GameObject.Find("Start").GetComponent<startScript>().findroom("dorm");
        }
        else
        {
            if (job == "warrior")
            {
                target = GameObject.Find("Start").GetComponent<startScript>().findroom("entry");
            }
            else if (job == "gatherer")
            {
                target = GameObject.Find("Start").GetComponent<startScript>().findroom("ressources");

            }
            else if (job == "worker")
            {
                //do stuff
            }
        }
    }




    void sleepDepravation()
    {
        PV--;
        Sleep += 10;
    }

    void starvation()
    {
        PV--;
        Hunger += 10;
    }

    void death()
    {
        Destroy(gameObject);
    }
}
