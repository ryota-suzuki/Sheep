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
	protected float elapsedTime;
	protected float lifeTime = 0.5f; // 羊が表示されている秒数
	protected GameManager gameManager;
	protected bool isTouched;

	protected virtual void Start()
	{
		// TODO suzuki 初期ポジションの制御
		transform.localPosition = new Vector3(0, -2.8f, 0);
		elapsedTime = 0;
		isTouched = false;
		gameManager = FindObjectOfType<GameManager>();
	}

	protected virtual void Update()
	{
		elapsedTime += Time.deltaTime;
	}

	public void Touched()
	{
		isTouched = true;
	}
}
