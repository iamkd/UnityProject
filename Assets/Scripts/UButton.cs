using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UButton : MonoBehaviour {
	public UnityEvent signalOnClick = new UnityEvent();
	public void _onClick() {
		this.signalOnClick.Invoke();
	}
}
