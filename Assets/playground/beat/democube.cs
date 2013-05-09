using UnityEngine;
using System.Collections;

public class democube : MonoBehaviour {
	[SerializeField]
	private GameObject BeatHandlerObject;

	[SerializeField]
	private GameObject BeatMapperObject;

	private BeatHandler BeatHandler_;
	private BeatMapper BeatMapper_;
	
	// Use this for initialization
	void Start () {
		BeatHandler_ = this.BeatHandlerObject.GetComponent<BeatHandler>();
		BeatHandler_.OnBeat += Handle_OnBeat;

		BeatMapper_ = this.BeatMapperObject.GetComponent<BeatMapper>();
	}

	void Handle_OnBeat (object sender, int section, int beat)
	{
		Vector3 p = transform.position;
		Quaternion r = transform.rotation;
		Color c = renderer.material.color;
		
		switch(beat) {
		case 0:
			p.x = 1;
			c = Color.red;	
			break;
		case 7:
			if (BeatMapper_.Kick)
				p.y = -1;
			break;
		case 8:
			if (BeatMapper_.Kick)
				p.y = 1;
			c = Color.yellow;
			break;
		case 16:
			p.x = -1;
			c = Color.cyan;
			break;
		case 23:
			if (BeatMapper_.Kick)
				p.z = -1;
			break;
		case 24:
			if (BeatMapper_.Kick)
				p.z = 1;
			c = Color.magenta;
			break;
		default:
			break;
		}
		
		if (BeatMapper_.Snare && (beat+4) % 8 == 0)
		{
			r.y += 0.2f;
			r.z += 0.15f;
		}
		
		transform.position = p;
		transform.rotation = r;
		renderer.material.color = c;
	}
	
	
	// Update is called once per frame
	void Update () {
		Vector3 p = transform.position;
		p.Scale( new Vector3(0.99f,0.99f,0.99f) );
		transform.position = p;

		Quaternion r = transform.rotation;
		r.y *= 0.99f;
		transform.rotation = r;
		
		Color c = renderer.material.color;
		c.r *= 0.99f;
		c.g *= 0.99f;
		c.b *= 0.99f;
		renderer.material.color = c;
	}
}
