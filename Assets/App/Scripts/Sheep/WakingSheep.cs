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
	}
}
