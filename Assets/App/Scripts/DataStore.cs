using UnityEngine;
using System.Collections;

public class DataStore : MonoBehaviour
{
	private static bool isCreated;

	public static int count { get; set; }
	public static int sheepType { get; set; }

	void Awake()
	{
		if (isCreated)
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);
		isCreated = true;
	}
}
