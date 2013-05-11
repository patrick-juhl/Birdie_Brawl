using UnityEngine;
using System.Collections;

public class Charger : MonoBehaviour {

	private Vector3 prevInput;
    private Vector3 lastPos;
    private Vector3 velocity;
	private int faps;
		
	[SerializeField]
	private GameObject BeatHandlerObject;
	private BeatHandler BeatHandler_;

	// Use this for initialization
	void Start () {
		prevInput = new Vector3();
		velocity = new Vector3(0,5,0);
		faps = 0;
		BeatHandler_ = this.BeatHandlerObject.GetComponent<BeatHandler>();
		BeatHandler_.OnBeat += Handle_OnBeat;
	}

	void Handle_OnBeat (object sender, int section, int beat)
	{
		if (section == 4 && beat == 0){
			this.enabled = false;	
			this.gameObject.GetComponent<PlayerController>().enabled = true;
			this.rigidbody.velocity = faps * velocity;
		}
		else {
			this.rigidbody.velocity = velocity;			
		}
	}
	
	
	// Update is called once per frame
	void Update () {
        Vector3 input = new Vector3();
		
        input = Input.mousePosition;
		
		if (input.x!=prevInput.x){
			if (Mathf.Sign((input-prevInput).x)!=Mathf.Sign(velocity.x)){
				faps++;
			}
			velocity = input-prevInput;
		}
		prevInput = input;
		
		
	 	if (Input.GetKeyDown("space"))
            print ("You reached "+faps+" number of FAPS!");
    }
		
}


