using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour
{
	private bool isDragging = false;

	protected void HandleTouch()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer ||
			Application.platform == RuntimePlatform.Android)
		{
			if (Input.touchCount <= 0)
				return;

			Touch t = Input.GetTouch(0);
			Vector3 touchPos = new Vector3(t.position.x, t.position.y, 10);
			switch (t.phase)
			{
				case TouchPhase.Began:
					OnTouchBegan(touchPos);
					break;

				case TouchPhase.Moved:
					OnTouchMoved(touchPos);
					break;

				case TouchPhase.Ended:
					OnTouchEnded(touchPos);
					break;
			}
		} else
		{
			Vector3 mouse = Input.mousePosition;
			mouse.z = 10;
			Vector3 touchPos = mouse;
			if (!isDragging && Input.GetMouseButtonDown(0))
			{
				isDragging = true;
				this.OnTouchBegan(touchPos);
				return;
			}
			if (isDragging && Input.GetMouseButtonUp(0))
			{
				isDragging = false;
				OnTouchEnded(touchPos);
				return;
			}
			if (isDragging)
			{
				OnTouchMoved(touchPos);
				return;
			}
		}
	}

	protected virtual void OnTouchBegan(Vector3 vec)
	{
	}

	protected virtual void OnTouchMoved(Vector3 vec)
	{
	}

	protected virtual void OnTouchEnded(Vector3 vec)
	{
	}
}
