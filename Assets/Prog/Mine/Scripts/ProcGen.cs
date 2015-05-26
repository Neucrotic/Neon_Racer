using UnityEngine;
using System.Collections;

public class ProcGen : MonoBehaviour 
{
    public int m_maxBuildings;

    private GameObject m_building;
	// Use this for initialization
	void Start () 
	{
        m_building = GameObject.FindGameObjectWithTag("Building");
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (Input.GetKeyDown ("space")) 
			RandomlyPlaceBuildings();
	}

	void RandomlyPlaceBuildings()
	{
        for (int i = 0; i < m_maxBuildings; i++)
        {
            int x = Random.Range(-100, 100);
            int z = Random.Range(0, 500);

            Vector3 pos = new Vector3(x, 0, z);

            GameObject clone;
            clone = Instantiate(m_building, pos, transform.rotation) as GameObject;

            print("RandomGen");
        }
	}
}
