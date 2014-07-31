using UnityEngine;
using System;
using System.Collections;

public class Sheep : MonoBehaviour
{
	[Serializable]
	public enum Type
	{
		Waking,
		Sleeping,
		Weak,
	}
	public Type type { get; set; }
	private float lifeTime = 5.0f; // 羊が表示されている秒数
	private float elapsedTime;

	protected virtual void Start()
	{
		// TODO suzuki 初期ポジションの制御
		transform.localPosition = new Vector3(5.7f, -2.8f, 0);
		elapsedTime = 0;
	}

	protected virtual void Update()
	{
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= lifeTime)
		{
			Destroy(gameObject);
		}
	}
}
