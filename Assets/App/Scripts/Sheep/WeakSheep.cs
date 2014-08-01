using UnityEngine;
using System.Collections;

public class WeakSheep : Sheep
{
	protected override void Start()
	{
		base.Start();
		type = Type.Weak;
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
