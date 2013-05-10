using UnityEngine;
using System.Collections;

public class MusicFilter : MonoBehaviour {
	
	[SerializeField]
	public float FeedbackLevel = 0.95f;
	
	[SerializeField]
	public float MinDelay = 0.005f;

	[SerializeField]
	public float MaxDelay = 0.010f;

	[SerializeField]
	public float Hz = 2;
	
	private float t;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		t = Time.time;
	}
	
	float[] output;
	float[] input;
	
	void OnAudioFilterRead(float[] data, int channels)
  	{
		int L = data.Length;
		int N = L * 10;
		if (output == null || output.Length != N)
		{
			output = new float[N];
			input = new float[N];
		}
		
	    for (var i = 0; i < N-L; i++) {
			input[i] = input[i+L];
			output[i] = output[i+L];
		}
	    for (var i = 0; i < L; i++) {
			input[N-L+i] = data[i];
		}		
		
		float minDelay = MinDelay;
		float maxDelay = MaxDelay;
		
	    for (int i = 0; i < L; i++)
	    {
			float dt = i/44100.0f/channels;
			int m = (int)(44100.0f * ((maxDelay-minDelay)*(0.5f * Mathf.Sin(Mathf.PI*2*Hz*(t+dt)) +0.5f) + minDelay));
			int r = i - m*channels;
				
			float feedback, delay;
			
			if (N + r < 0) {
				feedback = 0.0f; delay = 0.0f;
				Debug.Log("no data");
			} else if (r < 0) {
				feedback = output[N + r];
				delay = input[N + r];
			} else {
				feedback = 0.0f;
				delay = 0.0f;
			}

			output[N-L+i] = data[i] = input[N-L+i] + delay + FeedbackLevel*feedback;
		}
	}
}
