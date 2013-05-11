using UnityEngine;
using System.Collections;

public class cubespace : MonoBehaviour {

	[SerializeField]
	private GameObject BeatHandlerObject;
	private BeatHandler BeatHandler_;
	
	private bool once=false;
	
	// Use this for initialization
	void Start () {
		BeatHandler_ = this.BeatHandlerObject.GetComponent<BeatHandler>();
		BeatHandler_.OnBeat += Handle_OnBeat;;
		BeatHandler_.PlayNewBlockAfterThis(16);
	}

	void Handle_OnBeat (object sender, int section, int beat)
	{
		Vector3 p = this.transform.position;
		if (beat == 0) {
			if (!once)
				once = true;
			else {
				BeatHandler_.PlayNewBlockAfterThis(31);
				p.y += 0.1f;
			}
		}
		this.transform.position = p;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 p = this.transform.position;
		p.y *= 0.99f;

        if (Input.GetKeyDown ("space")) {
			float dt = BeatHandler_.beatTimeToBeat(16,0);
			float dt2 = BeatHandler_.beatTimeToBeat(31,0);
			float dy = 5*Mathf.Max(0.0f, 1.0f - Mathf.Min(Mathf.Abs(dt),Mathf.Abs(dt2)));
			p.y += dy;
            print ("space key was pressed " + dt);
		}
		this.transform.position = p;
	}
}
