using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cam : MonoBehaviour
{
	public GameObject Player;
	public Vector3 distance;
	public float clampy;
    // Start is called before the first frame update
    void Start()
    {
        distance=transform.position-Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(Player.transform.position.x, 
            Mathf.Clamp(clampy,clampy,clampy),Player.transform.position.z) +distance;
    }
}
