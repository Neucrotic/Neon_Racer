using UnityEngine;
using System.Collections;

public class CollisionDetectionWithPlayer : MonoBehaviour
{
    public Vector3 pos;
    private GameObject m_player;

    //Colliders Data
    BoxCollider[] childColliders;
    BoxCollider myCollider;

    Building myBuild;

	// Use this for initialization
	void Start () 
    {
        childColliders = this.GetComponentsInChildren<BoxCollider>();

        for (int i = 0; i < childColliders.Length; i++)
        {
            if (childColliders[i].tag == "Respawn")
            {
                myCollider = childColliders[i];
            }
        }

        myBuild = this.GetComponentInChildren<Building>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        pos = this.transform.position;

        m_player = GameObject.FindGameObjectWithTag("Player");

        float dist = Vector3.Distance(m_player.transform.position, this.transform.position);

        if (dist < 20)
        {
            m_player.GetComponent<Player>().p_boost = true;
            print("Close!!");
        }


        if (m_player.GetComponent<Player>().p_speed < (myBuild.p_speedThreshold / 2))
        {
            myCollider.enabled = false;
            //m_player.GetComponent<Player>().m_freezeMovement = false;
        }
	}
}
