using UnityEngine;
using System.Collections;

public class DisappearOnBeat : MonoBehaviour {

	[SerializeField]
	public int Tempo = 16;

	
	[SerializeField]
	private GameObject BeatHandlerDirectionObject;
	private BeatHandlerDirection BeatHandlerDirection_;
	
	// Use this for initialization
	void Start () {
		BeatHandlerDirection_ = this.BeatHandlerDirectionObject.GetComponent<BeatHandlerDirection>();
		BeatHandlerDirection_.OnBeat += Handle_OnBeat;
	}

	void Handle_OnBeat (object sender, int section, int beat)
	{
		int b = beat % Tempo;
		
		if (b == Tempo - 1)
			Warn();
		else if (b == 0)
			Hide();
		else if (b == Tempo/2)
			Show();
	}
	
	void Warn() {
		this.renderer.material.color = Color.red;
	}
	
	void Hide() {
		this.gameObject.SetActive(false);
	}

	void Show() {
		this.gameObject.SetActive(true);
		this.renderer.material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
