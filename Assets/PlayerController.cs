using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Rigidbody))]

public class PlayerController : MonoBehaviour {

	private Vector3 prevInput;
    private Vector3 lastPos;
    [SerializeField]
    private Vector3 fapVelocity;
	private int count;


	// Use this for initialization
	void Start () {
		prevInput = new Vector3();
		fapVelocity = new Vector3();
		count = 0;
	}
	
	
	// Update is called once per frame
	void Update () {
        Vector3 input = new Vector3();
		
        input = Input.mousePosition;
		
		if (input.x!=prevInput.x){
			if (Mathf.Sign((input-prevInput).x)!=Mathf.Sign(fapVelocity.x)){
        		this.rigidbody.AddForce(0,1,0);
				Debug.Log(this.rigidbody.velocity.y);
			}
			fapVelocity = input-prevInput;
		}
		prevInput = input;
		
	}
}
