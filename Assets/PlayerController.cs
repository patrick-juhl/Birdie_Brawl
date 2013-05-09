using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Rigidbody))]

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private GameObject BeatHandlerDirectionObject;
	
	private BeatHandlerDirection BeatHandlerDirection_;
	
    private Vector3 lastPos;
    [SerializeField]
    private Vector3 velocity;



	// Use this for initialization
	void Start () {
		BeatHandlerDirection_ = this.BeatHandlerDirectionObject.GetComponent<BeatHandlerDirection>();
	}
	
	
	// Update is called once per frame
	void Update () {
        velocity = this.transform.position - lastPos;
        Vector3 input = new Vector3();

        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        this.rigidbody.AddForce(input * 5);

        lastPos = this.transform.position;
		
		// UpdateMusic(input);
		UpdateMusic(this.rigidbody.velocity);
	}
	
	void UpdateMusic(Vector3 input) {
		
		
		if (Mathf.Abs(input.x) > Mathf.Abs(input.z))
		{
			if (input.x > 0.0f)
				BeatHandlerDirection_.PlayNewBlockAfterThis(32);
			else
				BeatHandlerDirection_.PlayNewBlockAfterThis(33);
		}
		else
		{
			if (input.z > 0.0f)
				BeatHandlerDirection_.PlayNewBlockAfterThis(34);
			else
				BeatHandlerDirection_.PlayNewBlockAfterThis(35);
		}
	}
}
