using UnityEngine;
using System.Collections;

public class WakingSheep : Sheep
{
	protected override void Start()
	{
		base.Start();
		type = Type.Waking;
	}

	protected override void Update()
	{
		base.Update();

		if (isTouched)
		{
			gameManager.GameOver((int)type);
			Destroy(gameObject);
			return;
		}

		if (elapsedTime < lifeTime)
			return;

		Destroy(gameObject);
	}
}