using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainAMovement : MonoBehaviour {

    // Use this for initialization
    public GameObject p_player;
    public int p_maxBuildings;

    private GameObject m_building;
    private bool m_moveTerrainB = true; //is so that this script only moves terrain b once
    private float m_speed = 70;
    private float m_terrainLength = 500f;

    private float m_increaseTimer = 5.0f;

	void Start () 
    {
        m_building = GameObject.FindGameObjectWithTag("Building");
	}
	
	// Update is called once per frame
	void Update () 
    {
        m_increaseTimer -= Time.deltaTime;
        if(m_increaseTimer <= 0)
        {
            m_increaseTimer = 5;
            p_maxBuildings += 1;
        }


        m_speed = p_player.GetComponent<Player>().p_movement.y;

        float x = this.transform.position.x - p_player.GetComponent<Player>().p_movement.x * m_speed * Time.deltaTime;
        float y = this.transform.position.y;
        float z = this.transform.position.z - m_speed * Time.deltaTime;

        if (x > 0 )
            x = 0;
        if (x < -195)
            x = -195;

        //Move this terrain towards the player.
        this.transform.position = new Vector3( x, y, z );
        
        //this moves the other terrain to the back of this one
        if (this.transform.position.z <= 00 && m_moveTerrainB)
        {
            GameObject b = GameObject.FindGameObjectWithTag("TerrainB");
            b.transform.position = new Vector3(b.transform.position.x, b.transform.position.y, this.transform.position.z + m_terrainLength);
            b.GetComponent<TerrainBMovement>().SetCanMoveTerrainA(true);
            b.GetComponent<TerrainBMovement>().GenBuildings();//When pushing terrain b to the back, call its gen function
            m_moveTerrainB = false;
        }
	}

    public void SetCanMoveTerrainB(bool _bool) { m_moveTerrainB = _bool; }

    public void GenBuildings()
    {
        float xPos = this.transform.position.x;

        //destroying prev building to stop repeating
        var children = new List<GameObject>();
        foreach (Transform child in this.transform)
            Destroy(child.gameObject);

        for (int i = 0; i < p_maxBuildings; i++)
        {
            int x = Random.Range((int)(xPos), (int)(200 + xPos)); //Width
            int z = Random.Range((int)(m_terrainLength), (int)((m_terrainLength * 2)));

            Vector3 pos = new Vector3(x, 0, z);

            GameObject clone;
            clone = Instantiate(m_building, pos, transform.rotation) as GameObject;
            clone.transform.parent = this.transform;
        }
    }
}
