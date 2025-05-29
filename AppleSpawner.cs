using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public string spawnTag;
	public float debugRenderSize = 1f;
    public int desiredAmount;
    public GameObject spawnObject;
    void Start()
    {
        List<GameObject> objs = new(GameObject.FindGameObjectsWithTag(spawnTag));
		int totalAmount = objs.Count;
		int spawned = 0;
		for (int i = 0; i < totalAmount; i++)
		{
			bool isBelowRequired = spawned < desiredAmount;
			bool randomCheck = Random.Range(0, 1) > 0.5;
			GameObject pos = objs[Random.Range(0, objs.Count)];
			if (isBelowRequired || randomCheck)
			{
				GameObject newObj = Instantiate(spawnObject);
				newObj.transform.position = pos.transform.position;
				spawned++;
				if (desiredAmount < totalAmount)
					objs.Remove(pos);
			}
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, debugRenderSize);
	}
}


