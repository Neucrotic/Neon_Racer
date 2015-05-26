using UnityEngine;
using System.Collections;

public class CollisionDetectionWithPlayer : MonoBehaviour
{

    private GameObject m_player;
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");

        float dist = Vector3.Distance(m_player.transform.position, this.transform.position);

        if (dist < 10)
        {
            m_player.GetComponent<Player>().p_boost = true;
            print("Close!!");
        }
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            print("DEAD!");
        }
    }
}
