using UnityEngine;
using System.Collections;

public class DataStore : MonoBehaviour
{
	private bool isCreated;

	public static int count { get; set; }
	public static int sheepType { get; set; }

	void Awake()
	{
		if (isCreated)
			return;

		DontDestroyOnLoad(gameObject);
		isCreated = true;
	}
}
