﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private enum Status
	{
		Opening,
		Playing,
		GameOver,
	}
	private Status status { get; set; }
	public int count { get; private set; }

	// NOTE Inspectorにて設定必要
	public Sheep[] sheeps;

	// NOTE count が「definedValueの倍数」or「definedValueStrを含む」場合は特殊な羊を出す
	private static int definedValue = 3;
	private string definedValueStr;

	// NOTE 特殊な羊のうち、Weak がでる確率
	private int weakAppearProbability = 30;

	void Start()
	{
		definedValueStr = definedValue.ToString();
		Opening();
	}

	void Update()
	{
		if (!isStatusPlaying())
			return;

		if (FindObjectOfType<Sheep>() != null)
			return;

		count++;
		Instantiate(sheeps[(int)LotSheepType()]);
	}

	private int LotSheepType()
	{
		// NOTE count が「definedValueStrを含む」or「definedValueの倍数」でなければ Waking
		if ( (count.ToString().IndexOf(definedValueStr) == -1) && (count % definedValue != 0) )
			return (int)Sheep.Type.Waking;

		if (IsWeakAppear())
			return (int)Sheep.Type.Weak;

		return (int)Sheep.Type.Sleeping;
	}

	private bool IsWeakAppear()
	{
		if ( (int)Random.Range(0, 100) < weakAppearProbability )
			return true;
		return false;
	}

	private void Opening()
	{
		status = Status.Opening;
		count = 1;
		// TODO suzuki Openingインスタンスの作成

		// TODO suzuki 本来はOpening処理の最後で下記の処理を行う
		// NOTE 順番注意 Sheepオブジェクトの作成 -> StatusをPlayingに変更
		Instantiate(sheeps[(int)LotSheepType()]);
		status = Status.Playing;
	}

	public void GameOver()
	{
		status = Status.GameOver;
		// TODO suzuki GameOverインスタンスの作成やスコアの表示
	}

	public bool isStatusOpening()  { return status == Status.Opening; }
	public bool isStatusPlaying()  { return status == Status.Playing; }
	public bool isStatusGameOver() { return status == Status.GameOver; }

	public void setStatusPlaying() { status = Status.Playing; }
}