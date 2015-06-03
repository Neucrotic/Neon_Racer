using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class Player : MonoBehaviour
{
    //Speed Data
    float m_maxSpeed = 180;
    float m_minSpeed = 80;
    public float p_speed = 5;
    public Vector2 p_movement;
    public bool p_boost = false;
    int m_boostCounter = 0;
    int m_dirLR = 0;

    public Camera p_mainCamera;
    //Movement freezing
    public bool m_freezeMovement = false;
    float m_countdown = 1.0f; // time you'll be frozen for

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
        if (Input.GetKey(KeyCode.A) && !m_freezeMovement)
        {
            m_dirLR = -1;
        }
        if (Input.GetKey(KeyCode.D) && !m_freezeMovement)
        {
            m_dirLR = 1;
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            m_dirLR = 0;

        if (m_freezeMovement)
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

        //detecting/applying boost and score multiplier
        if (p_boost)
        {


            m_boostCounter = 1;
            if (m_boostCounter >= 2)
            {
                m_scoreMultiplier = m_boostCounter;
            }
        }
        else if(!p_boost)
        {
            m_boostCounter = 0;
        }

        //increasing the score
        p_score += 1 * m_scoreMultiplier;
        p_movement = new Vector2((float)m_dirLR, p_speed);

        if (m_freezeMovement)
        {
            m_countdown -= Time.deltaTime;
            p_mainCamera.GetComponent<MotionBlur>().enabled = true;
            p_mainCamera.GetComponent<VignetteAndChromaticAberration>().enabled = true;
            p_mainCamera.GetComponent<ColorCorrectionCurves>().enabled = true;
        }
        else
            m_countdown = 1.0f;

        if (m_countdown <= 0)
        {
            m_freezeMovement = false;
            p_mainCamera.GetComponent<MotionBlur>().enabled = false;
            p_mainCamera.GetComponent<VignetteAndChromaticAberration>().enabled = false;
            p_mainCamera.GetComponent<ColorCorrectionCurves>().enabled = false;
        }

    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "killBox")
        {
            Application.LoadLevel("NeonRacerProto");
            print("DEAD!");
        }

        if (col.gameObject.name == "building1CloseBox" || col.gameObject.name == "building2CloseBox")
        {
            m_freezeMovement = true;
            print("BUMP");
        }
    }
}