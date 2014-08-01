using UnityEngine;
using System.Collections;

public class SheepTouch : TouchController
{
	private GameManager gameManager;

	void Start ()
	{
		gameManager = FindObjectOfType<GameManager>();
	}

	void Update ()
	{
		if (!gameManager.isStatusPlaying())
			return;
		HandleTouch();
	}

	protected override void OnTouchBegan(Vector3 pos)
	{
		if (!gameManager.isStatusPlaying())
			return;

		Vector2 worldPos2D = Camera.main.ScreenToWorldPoint(pos);
		foreach (var collider2D in Physics2D.OverlapPointAll(worldPos2D))
		{
			if (collider2D == null)
				continue;
			if (!collider2D.isTrigger)
				continue;
			if (collider2D.transform.parent == null)
				continue;

			var touchedSheep = collider2D.transform.parent.gameObject.GetComponent<Sheep>();
			if (touchedSheep == null)
				continue;
			touchedSheep.Touched();

			break;
		}
	}
}
