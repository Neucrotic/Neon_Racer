using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TerrainBMovement : MonoBehaviour {

	// Use this for initialization
    public GameObject p_player;
    public int p_maxBuildings;
  
    private GameObject m_building1;
    private GameObject m_building2;

    private bool m_moveTerrainA = true; //is so that this script only moves terrain a once
    private float m_speed = 70;
    private float m_terrainLength = 400;
    private float m_terrainWidth = 400;

    private float m_increaseTimer = 5.0f;

	void Start () 
    {
        m_building1 = GameObject.Find("Building1");
        m_building2 = GameObject.Find("Building2");
	}
	
	// Update is called once per frame
	void Update () 
    {
        m_increaseTimer -= Time.deltaTime;
        if (m_increaseTimer <= 0)
        {
            m_increaseTimer = 5;
            p_maxBuildings += 1;
        }

        m_speed = p_player.GetComponent<Player>().p_movement.y;

        float x = this.transform.position.x - p_player.GetComponent<Player>().p_movement.x * m_speed * Time.deltaTime;
        float y = this.transform.position.y;
        float z = this.transform.position.z - m_speed * Time.deltaTime;

        //stop you from going off the terrain
        if (x > m_terrainWidth / 2)  //Left Side
            x = m_terrainWidth / 2;

        if (x < -(m_terrainWidth / 2)) //Right Side
            x = -(m_terrainWidth / 2);

        //Move this terrain towards the player.
        this.transform.position = new Vector3(x, y, z);

        //this moves the other terrain to the back of this one
        if (this.transform.position.z <= 130 && m_moveTerrainA)
        {
            GameObject a = GameObject.Find("TerrainA");
            a.transform.position = new Vector3(a.transform.position.x, a.transform.position.y, this.transform.position.z + m_terrainLength);
            a.GetComponent<TerrainAMovement>().SetCanMoveTerrainB(true);
            a.GetComponent<TerrainAMovement>().GenBuildings();
            m_moveTerrainA = false;
        }	
	}

    public void SetCanMoveTerrainA(bool _bool) { m_moveTerrainA = _bool;  }
    
    public void GenBuildings()
    {
        float xPos = this.transform.position.x;

        //destroying prev building to stop repeating
        var children = new List<GameObject>();
        foreach ( Transform child in this.transform)
            Destroy(child.gameObject);

        float halfWidth = m_terrainWidth / 2;

        for (int i = 0; i < p_maxBuildings; i++)
        {
            int x = Random.Range((int)(xPos - halfWidth), (int)(xPos + halfWidth)); //Width
            int z = Random.Range((int)(m_terrainLength), (int)((m_terrainLength * 2)));

            Vector3 pos = new Vector3(x, 0, z);

            float rand = Random.Range(0, 10);

            GameObject clone;

            if (rand <= 5)
            {
                clone = Instantiate(m_building1, pos, transform.rotation) as GameObject;
                clone.transform.parent = this.transform;
            }
            if (rand > 5)
            {
                clone = Instantiate(m_building2, pos, transform.rotation) as GameObject;
                clone.transform.parent = this.transform;
            }
        }
    }
}
