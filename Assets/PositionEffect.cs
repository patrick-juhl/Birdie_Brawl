using UnityEngine;
using System.Collections;

public class PositionEffect : MonoBehaviour {
	
	[SerializeField]
	private GameObject BeatKickObject;
	
	private AudioSource BeatKick_;
	
	[SerializeField]
	private GameObject BeatSnareObject;
	
	private AudioSource BeatSnare_;

	[SerializeField]
	private GameObject BeatSynthObject;
	
	private AudioSource BeatSynth_;
	
	// Use this for initialization
	void Start () {
		/*BeatKick_ = this.BeatKickObject.GetComponent<AudioSource>();
		BeatSnare_ = this.BeatSnareObject.GetComponent<AudioSource>();
		BeatSynth_ = this.BeatSynthObject.GetComponent<AudioSource>();*/
	}
	
	
	// Update is called once per frame
	void Update () {
		Vector3 p = transform.position;
		Vector3 v = rigidbody.velocity;
		
		/*float a = -1.0f + 2.0f*Mathf.Clamp01((p.z+10.0f)/10.0f);
		float b = -1.0f + 2.0f*Mathf.Clamp01((p.x+10.0f)/10.0f);

		BeatSnare_.volume = 1-Mathf.Abs(a);
		BeatKick_.volume = 1-Mathf.Abs(b);
		
		float e = v.x*v.x + v.y*v.y + v.z*v.z;
		BeatSynth_.volume = Mathf.Clamp01(BeatSynth_.volume*0.97f+0.003f*e);
		
		float pitch = 1.0f + 0.05f * BeatSynth_.volume;
		BeatKick_.pitch = pitch;
		BeatSnare_.pitch = pitch;
		BeatSynth_.pitch = pitch;*/
	}
}
