using UnityEngine;
using System.Collections;

public class ParticleFollow : MonoBehaviour {
    public GameObject p_terrainToFollow;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        this.transform.position = new Vector3(p_terrainToFollow.transform.position.x, this.transform.position.y, this.transform.position.z);
	}
}
