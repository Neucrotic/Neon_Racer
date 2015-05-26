using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    //Speed Data
    float m_maxSpeed = 120;
    float m_minSpeed = 50;
    public float p_speed = 5;
    public Vector2 p_movement;
    public bool p_boost;
    int m_dirLR = 0;

    //Score Data
    public float p_score = 0;
    int m_scoreMultiplier = 1;

    //Near-Miss Data
    public int p_missCounter = 0;

    void Start()
    {

    }

    void Update()
    {
        //ensuring speed stays within its range
        if (p_speed > m_maxSpeed)
        {
            p_speed = m_maxSpeed;
        }
        if (p_speed < m_minSpeed)
        {
            p_speed = m_minSpeed;
        }

        //detecting input for moving the player left and right
        if (Input.GetKey(KeyCode.A))
        {
            m_dirLR = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_dirLR = 1;
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            m_dirLR = 0;

        //detecting input for adjusting the speed value
        if (Input.GetKey(KeyCode.W))
        {
            p_speed += 0.345f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_speed -= 0.354f;
        }

        //increasing the score
        p_score += 1 * m_scoreMultiplier;
        p_movement = new Vector2((float)m_dirLR, p_speed);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "P_BuildingA 1")
        {
            print("BUMP");
        }
    }
}