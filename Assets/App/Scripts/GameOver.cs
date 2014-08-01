using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
	private int count;
	private int sheepType;
	public GameObject[] gameOvers;

	void Start()
	{
		count = DataStore.count;
		sheepType = DataStore.sheepType;

		Debug.Log("count:" + count);
		Debug.Log("sheepType:" + sheepType);
		Instantiate(gameOvers[sheepType]);
	}

	void Update()
	{
	}
}
