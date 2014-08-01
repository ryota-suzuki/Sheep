using UnityEngine;
using System.Collections;

public class SleepingSheep : Sheep
{
	protected override void Start()
	{
		base.Start();
		type = Type.Sleeping;
	}

	protected override void Update()
	{
		base.Update();

		if (elapsedTime < lifeTime)
			return;

		if (!isTouched)
		{
			gameManager.GameOver((int)type);
		}

		Destroy(gameObject);
	}
}
