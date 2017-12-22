using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kobScript : MonoBehaviour {

    public int PV;
    public int Hunger;
    public int Sleep;
    public int Exp;
    public int LV;

    public int Atk;
    public int Intel;
    public int Artisanat;

    public GameObject UIPerso;



    public string job, name;

    public bool locked = false; 

    public GameObject target;
    public GameObject currentRoom;

    float hungerTime;
    float sleepTime;
    float dodoTime;
    float OsTime;
    float ViandeTime;
    float RatsTime;
    float CuirTime;

    // Use this for initialization
    void Start () {
        PV = 3;
        Hunger = 100;
        Sleep = 100;
        Exp = 0;
        LV = 1;

        Intel = 1;
        Atk = 2;
        Artisanat = 2;

        name = "John Doe";
    
	}
	
	// Update is called once per frame
	void Update () {
        hungerTime += Time.deltaTime ;

        if (currentRoom != null && currentRoom.GetComponent<RoomGenScript>().isDorm)
        {

        }
        else
        {
            sleepTime += Time.deltaTime;
        }


        if (sleepTime >= 4)
        {
            Sleep--;
            sleepTime = 0;
            findTarget();
            if (Sleep <= 0)
            {
                sleepDepravation();
            }
        }
        if(hungerTime >= 2)
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
            this.GetComponent<Transform>().localPosition = Vector3.Lerp(this.GetComponent<Transform>().localPosition, target.GetComponent<Transform>().localPosition + new Vector3(5, 2, 0), 0.005f);
        }


        getRoom();

        if (locked)
        {
            Camera.main.GetComponent<Transform>().localPosition = this.GetComponent<Transform>().localPosition + new Vector3(7,0,-20);
        }

	}

    void getRoom()
    {
        if (this.GetComponent<Transform>().localPosition.x >= target.GetComponent<Transform>().localPosition.x && this.GetComponent<Transform>().localPosition.x <= target.GetComponent<Transform>().localPosition.x + 10)
        {
            currentRoom = target;
        }
        else
        {
            currentRoom = null;
        }

        if (currentRoom != null)
        {
            if (currentRoom.GetComponent<RoomGenScript>().isCraft)
            {
                if (Hunger <= 20)
                {
                    if (Camera.main.GetComponent<generalScript>().Rats > 0)
                    {
                        Camera.main.GetComponent<generalScript>().Rats--;
                        Hunger += 50;
                    }
                    if (Camera.main.GetComponent<generalScript>().Viande > 0)
                    {
                        Camera.main.GetComponent<generalScript>().Viande--;
                        Hunger += 50;
                    }
                    if (Hunger > 100)
                    {
                        Hunger = 100;
                    }
                }
            }

            if (currentRoom.GetComponent<RoomGenScript>().isDorm)
            {
                dodoTime += Time.deltaTime;
                if (dodoTime >= 30)
                {
                    Sleep = 100;
                }
            }

            if (currentRoom.GetComponent<RoomGenScript>().isRssource)
            {
                OsTime += Time.deltaTime;
                ViandeTime += Time.deltaTime;
                RatsTime += Time.deltaTime;
                CuirTime += Time.deltaTime;

                if (RatsTime >= 15 - 9 * (float)Camera.main.GetComponent<generalScript>().Viande / 100)
                {
                    Camera.main.GetComponent<generalScript>().Rats++;
                    RatsTime = 0;
                }
                if (ViandeTime >= 15 + 9 * (float)Camera.main.GetComponent<generalScript>().Rats / 100)
                {
                    Camera.main.GetComponent<generalScript>().Viande++;
                    ViandeTime = 0;
                }

                if (OsTime >= 30)
                {
                    Camera.main.GetComponent<generalScript>().Os++;
                    OsTime = 0;
                }

                if (CuirTime >= 15)
                {
                    Camera.main.GetComponent<generalScript>().Cuir++;
                    CuirTime = 0;
                }
            } 
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
                target = GameObject.Find("Start").GetComponent<startScript>().findroom("food");
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
        Destroy(UIPerso);
        Destroy(gameObject);
        
    }
}
