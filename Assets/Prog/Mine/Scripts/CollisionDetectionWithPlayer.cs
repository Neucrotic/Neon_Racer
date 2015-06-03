using UnityEngine;
using System.Collections;

public class CollisionDetectionWithPlayer : MonoBehaviour
{
    public Vector3 pos;
    private GameObject m_player;
	// Use this for initialization
	void Start () 
    {
	    
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
	
	}
}
