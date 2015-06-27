using UnityEngine;
using System.Collections;

public interface ISpawnerListener{
	void OnSpawn(GameObject spawnedObject);
}

public class Spawner : MonoBehaviour {

	public float IntervalSeconds = 1;
	public GameObject Prefab;
	public Vector3 MinRandomPosition;
	public Vector3 MaxRandomPosition;
	public bool OnlyExternalPosition = false;
	float oldTime = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - oldTime > IntervalSeconds) {
			oldTime = Time.time;

			//Debug.Log("Interval");
			var randomPos = Vector3.zero;
			if(OnlyExternalPosition)
			{
				randomPos = new Vector3(
					Random.Range(-1,1) < 0 ? MinRandomPosition.x : MaxRandomPosition.x,
					Random.Range(-1,1) < 0 ? MinRandomPosition.y: MaxRandomPosition.y,
					Random.Range(-1,1) < 0 ? MinRandomPosition.z: MaxRandomPosition.z
					);
			}
			else
			{
			 randomPos = new Vector3(
								Random.Range(MinRandomPosition.x,MaxRandomPosition.x),
								Random.Range(MinRandomPosition.y,MaxRandomPosition.y),
								Random.Range(MinRandomPosition.z,MaxRandomPosition.z)
				);
			}

			var newPrefab = (GameObject)Instantiate(Prefab, transform.position + randomPos, Quaternion.identity);

			var listeners = GetComponents<ISpawnerListener>();
			foreach (var listener in listeners) {
				listener.OnSpawn(newPrefab);
			}
		}
	}

}
