using UnityEngine;
using System.Collections;

public class SpawnWorld : MonoBehaviour {

	[SerializeField]
	private GameObject prefab;

	[SerializeField]
	private GameObject prefab1;
	
	[SerializeField]
	private GameObject prefab2;
	
	// Use this for initialization
	void Start () {
		Random r = new Random();
		GameObject[] prefabs = {
			prefab, prefab1, prefab2, prefab2, prefab2 };
		
		for (int p=0; p<prefabs.Length; p++)
		{
			for (int i=0; i<10; i++) {
				float x = (float)Random.Range(-10,10);
				float z = (float)Random.Range(-10,10);
				Instantiate(prefabs[p], new Vector3(x, 1.0f, z), Quaternion.identity);
			}
		}
	}
}
