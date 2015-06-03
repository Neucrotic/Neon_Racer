using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour 
{
    //Break Data
    public bool p_breakable;
    int m_colour; // 1 = red, 2 = orange, 3 = green
    float m_speedThreshold;

    //Object Data
    Material m_material;
    Renderer renderer;
    Player player;

	void Start () 
    {
        renderer = this.GetComponent<Renderer>();
        m_material = renderer.material;
        player = FindObjectOfType<Player>();

        p_breakable = false;
        m_speedThreshold = Random.Range(80, 180);
	}
	
	void Update () 
    {
        //calculating colour based on player speed
        if (player.p_speed > m_speedThreshold)
        {
            m_colour = 3;
        }
        if (player.p_speed > (m_speedThreshold / 2) && player.p_speed < m_speedThreshold)
        {
            m_colour = 2;
        }
        if (player.p_speed < (m_speedThreshold / 2))
        {
            m_colour = 1;
        }
        m_colour = 1;
        //apply colour change
        if (m_colour == 1)
        {
            renderer.material.shader = Shader.Find("Emissive");
            m_material.SetColor("_Emission", Color.red);
        }
        if (m_colour == 2)
        {

        }
        if (m_colour == 3)
        {

        }
	}
}
