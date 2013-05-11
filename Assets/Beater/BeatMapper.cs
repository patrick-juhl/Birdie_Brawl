using UnityEngine;
using System.Collections;

public class BeatMapper : MonoBehaviour {
	
	[SerializeField]
	private int block = 0;
	
	[SerializeField]
	private GameObject BeatHandlerObject;
	
	private BeatHandler BeatHandler_;
		
	[SerializeField]
	public bool Hihat;
	
	[SerializeField]
	public bool Snare;

	[SerializeField]
	public bool Kick;

	[SerializeField]
	public bool Bass;

	[SerializeField]
	public bool Synth;

	
	// Use this for initialization
	void Start () {
		BeatHandler_ = this.BeatHandlerObject.GetComponent<BeatHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		block = v(Hihat) + v(Snare)*2 + v(Kick)*4 + v(Bass)*8 + v(Synth)*16;
		BeatHandler_.PlayNewBlockAfterThis(block);
	}
	
	int v(bool b) {
		return b?1:0;
	}
}
