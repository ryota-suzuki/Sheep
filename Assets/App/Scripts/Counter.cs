using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour
{
	private GameManager gameManager;
	public int count { get; private set; }
	public string countStr { get { return count.ToString(); } }

	void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
	}

	public void Increment()
	{
		count++;
	}

	public void Reset()
	{
		count = 1;
	}

	void Update ()
	{
		if (!gameManager.isStatusPlaying())
			return;

		guiText.text = countStr;
	}
}
