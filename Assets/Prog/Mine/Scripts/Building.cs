using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour 
{
    //Break Data
    public bool p_breakable;
    int m_colour; // 1 = red, 2 = orange, 3 = green

    //Collider Data
    Collider baseCol;
    Collider nearMiss;
    Collider[] cols;
    Player player;

	void Start () 
    {
        baseCol = this.GetComponent<MeshCollider>();
        nearMiss = this.GetComponent<BoxCollider>();

        player = FindObjectOfType<Player>();

        p_breakable = false;
	}
	
	void Update () 
    {
	    
	}

    void OnTiggerEnter(Collider _col)
    {
        //make sure we have collided with the player
        if (_col.tag == "Player")
        {
            if (p_breakable)
            {

            }
            else
            {

            }
        }
    }

    void OnTriggerExit(Collider _col)
    {

    }

    void OnCollision(Collider _col)
    {

    }
}
