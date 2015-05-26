using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
    Canvas canvas;

    Text scoreText;
    Text speedText;

    Player player;

	// Use this for initialization
	void Start () 
    {
        GameObject temp;

        canvas = GetComponent<Canvas>();
        if(canvas != null)
        {
            temp = GameObject.FindWithTag("TextA");
            scoreText = temp.GetComponent<Text>();

            temp = GameObject.FindWithTag("TextB");
            speedText = temp.GetComponent<Text>();
        }

        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        scoreText.text = "Score:" + player.p_score;
        speedText.text = player.p_speed + "Kms/h";
	}
}
