using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class BeatHandler : MonoBehaviour {
	
	const float bpm = 2*150;
	const float time_per_beat = 60 / bpm;
	const int beats_per_block = 32;
	const float delay = 1/60.0f;

	private AudioSource source_;

	public delegate void OnBeatEventHandler(object sender, int section, int beat);
	public event OnBeatEventHandler OnBeat;
	
	private int current_beat_in_block;
	private float current_block_start;
	private int current_block;

	[SerializeField]
	private int next_block;

	// Use this for initialization
	void Start () {
		current_block = 0;
		current_beat_in_block = -1;
		current_block_start = 0;
		
		source_ = GetComponent<AudioSource>();
	}

	public void PlayNewBlockAfterThis(int new_block) {
		next_block = new_block;
		if (source_ != null && !source_.isPlaying)
			GotBeat(0);
	}
	
	// Update is called once per frame
	void Update () {
		float relative_time = source_.time + delay - current_block_start;
		
		int update_beat_in_block = (int)(relative_time/time_per_beat);
		
		if (update_beat_in_block != current_beat_in_block) {
			GotBeat(update_beat_in_block);
		}
	}
	
	void GotBeat(int beat) {
		if (beat >= beats_per_block || ((beat%4) == 0 && current_block != next_block)) {
			if (beat >= beats_per_block)
				beat = 0;
			
			current_block_start = next_block*beats_per_block*time_per_beat;
			source_.time = current_block_start-delay + beat*time_per_beat;
			if (!source_.isPlaying)
				source_.Play();
			current_block = next_block;
		}
		
		current_beat_in_block = beat;

		if (OnBeat != null)
			OnBeat(this, current_block, current_beat_in_block);
	}
	
	public float beatTimeToBeat(int block, int beat) {
		float beat_mark = (block*beats_per_block + beat)*time_per_beat;
		float d = beat_mark - source_.time;
		float d2 = d + beats_per_block*time_per_beat;
		
		
		if (Mathf.Abs(d) < Mathf.Abs (d2))
			return d / time_per_beat;
		else
			return d2 / time_per_beat;
	}
}
