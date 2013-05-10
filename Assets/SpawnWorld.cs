using UnityEngine;
using System.Collections;

public class SpawnWorld : MonoBehaviour {

	[SerializeField]
	private GameObject prefab;

	[SerializeField]
	private GameObject prefab1;
	
	[SerializeField]
	private GameObject prefab2;

	[SerializeField]
	private GameObject prefabNo;

	// Use this for initialization
	void Start () {
		Random r = new Random();
		GameObject[] prefabs = {
			prefab, prefab1, prefab2, prefab2, prefab2 };
		
		for (int p=0; p<prefabs.Length; p++)
		{
			for (int i=0; i<200; i++) {
				float x = (float)Random.Range(-8,9);
				float z = (float)Random.Range(-8,9);
				if (x == 0 && z == 0)
					continue;
				Instantiate(prefabs[p], new Vector3(x, 1.0f, z), Quaternion.identity);
			}
		}
		
		for (int i=-10; i<=10; i++) {
			noBeat(Instantiate(prefab, new Vector3(i, 1.0f, 10.0f), Quaternion.identity));
			noBeat(Instantiate(prefab, new Vector3(i, 1.0f, -10.0f), Quaternion.identity));
			noBeat(Instantiate(prefab, new Vector3(10.0f, 1.0f, i), Quaternion.identity));
			noBeat(Instantiate(prefab, new Vector3(-10.0f, 1.0f, i), Quaternion.identity));
		}
	}
	
	void noBeat(object o) {
		foreach(MonoBehaviour b in (o as GameObject).GetComponents<MonoBehaviour>())
		{
			Destroy(b);
		}
		
		(o as GameObject).renderer.material.color = Color.black;
	}
}
