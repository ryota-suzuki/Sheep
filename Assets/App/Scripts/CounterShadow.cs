using UnityEngine;
using System.Collections;

public class CounterShadow : MonoBehaviour
{
	public GameObject CounterEntity;
	private GameManager gameManager;

	void Start()
	{
		gameManager = FindObjectOfType<GameManager>();

		Vector3 entityPosition = CounterEntity.transform.position;
		Vector3 shadowPosition = new Vector3(
			entityPosition.x,
			entityPosition.y - 0.005f,
			entityPosition.z - 1
		);
		transform.position = shadowPosition;
	}

	void Update ()
	{
		if (!gameManager.isStatusPlaying())
			return;

		guiText.text = CounterEntity.guiText.text;
	}
}
