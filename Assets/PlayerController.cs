using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Rigidbody))]

public class PlayerController : MonoBehaviour {

    private Vector3 lastPos;
    [SerializeField]
    private Vector3 velocity;

    

	// Use this for initialization
	void Start () {
	        
	}
	
	// Update is called once per frame
	void Update () {
        velocity = this.transform.position - lastPos;
        Vector3 input = new Vector3();

        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        this.rigidbody.AddForce(input * 5);

        lastPos = this.transform.position;

	}
}
