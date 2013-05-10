using UnityEngine;
using System.Collections;
using System;

public class UpdateMusic : MonoBehaviour {

	[SerializeField]
	private GameObject MusicFilterObject;
	
	private MusicFilter MusicFilter_;
	
	[SerializeField]
	private GameObject BeatHandlerDirectionObject;
	
	private BeatHandlerDirection BeatHandlerDirection_;

	// Use this for initialization
	void Start () {
		BeatHandlerDirection_ = this.BeatHandlerDirectionObject.GetComponent<BeatHandlerDirection>();
		MusicFilter_ = this.MusicFilterObject.GetComponent<MusicFilter>();
	}
	
	// Update is called once per frame
	void Update () {
		// UpdateMusic(input);
		UpdateMusicOnPosition(this.transform.position);
		UpdateMusicOnVelocity(this.rigidbody.velocity);
	}
	
	void UpdateMusicOnPosition(Vector3 input) {
		Vector3 p = transform.position;
		Vector3 v = rigidbody.velocity;
		float a = Mathf.Max(0.0f, Mathf.Min(1.0f, (p.z+2.0f)/4.0f));
		float b = 1-Mathf.Max(0.0f, Mathf.Min(1.0f, (p.x+2.0f)/4.0f));

		MusicFilter_.Hz = a*8;
		MusicFilter_.MaxDelay = 0.06f*b;

		if (p.x < -2) {
			p.x = -2;
			v.x = 0;
		}
		if (p.x > 2) {
			p.x = 2;
			v.x = 0;
		}
		if (p.z < -2) {
			p.z = -2;
			v.z = 0;
		}
		if (p.z > 2) {
			p.z = 2;
			v.z = 0;
		}

		transform.position = p;
		rigidbody.velocity = v;
	}

	void UpdateMusicOnVelocity(Vector3 input) {
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
