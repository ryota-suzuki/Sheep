using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private enum Status
	{
		Opening,
		Playing,
		GameOver,
	}
	private Status status { get; set; }

	// NOTE Inspectorにて設定必要
	public GameObject openingPrefab;
	public Sheep[] sheeps;

	// NOTE カウント が「definedValueの倍数」or「definedValueStrを含む」場合は特殊な羊を出す
	private Counter counter;
	private static int definedValue = 3;
	private string definedValueStr;

	// NOTE 特殊な羊のうち、Weak がでる確率
	private int weakAppearProbability = 30;

	void Start()
	{
		definedValueStr = definedValue.ToString();
		counter = FindObjectOfType<Counter>();
		StartCoroutine(Opening());
	}

	void Update()
	{
		if (!isStatusPlaying())
			return;

		if (FindObjectOfType<Sheep>() != null)
			return;

		counter.Increment();
		Instantiate(sheeps[(int)LotSheepType()]);
	}

	private int LotSheepType()
	{
		if (IsWakingAppear())
			return (int)Sheep.Type.Waking;

		if (IsWeakAppear())
			return (int)Sheep.Type.Weak;

		return (int)Sheep.Type.Sleeping;
	}

	// NOTE カウント が「definedValueStrを含む」or「definedValueの倍数」でなければ Waking
	private bool IsWakingAppear()
	{
		if (counter.countStr.IndexOf(definedValueStr) != -1)
			return false;

		if (counter.count % definedValue == 0)
			return false;

		return true;
	}

	private bool IsWeakAppear()
	{
		if ( (int)Random.Range(0, 100) < weakAppearProbability )
			return true;
		return false;
	}

	private IEnumerator Opening()
	{
		status = Status.Opening;
		counter.Reset();

		// NOTE Opening表示(Openingが非表示になるまで待機する)
		float openingTime = 2.0f;
		GameObject opening = Instantiate(openingPrefab) as GameObject;
		Destroy(opening, openingTime);
		yield return new WaitForSeconds(openingTime);

		// NOTE 順番注意 Sheepオブジェクトの作成 -> StatusをPlayingに変更
		Instantiate(sheeps[(int)LotSheepType()]);
		status = Status.Playing;
	}

	public void GameOver(int type)
	{
		status = Status.GameOver;

		// GameOver scene に持ち越すためのデータをセット
		DataStore.count = counter.count;
		DataStore.sheepType = type;

		Application.LoadLevel ("GameOver");
	}

	public bool isStatusOpening()  { return status == Status.Opening; }
	public bool isStatusPlaying()  { return status == Status.Playing; }
	public bool isStatusGameOver() { return status == Status.GameOver; }

	public void setStatusPlaying() { status = Status.Playing; }
}
