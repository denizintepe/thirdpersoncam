using UnityEngine;
using System.Collections;

public class SpawnArea : MonoBehaviour {
	
	public GameObject objectToSpawn;
	public Vector3 spawnArea;
	public float frequency = 1;
	
	
	private float lastFireTime = -1;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time > lastFireTime + 1 / frequency) 
		{
			Vector3 spPoint= new Vector3(gameObject.transform.position.x + Random.Range(0.0f, spawnArea.x),
				gameObject.transform.position.y + Random.Range(0.0f, spawnArea.y),
				gameObject.transform.position.z + Random.Range(0.0f, spawnArea.z));
			
			Spawner.Spawn(objectToSpawn,spPoint,Quaternion.identity);
			
			lastFireTime = Time.time;
		}
	}
}
