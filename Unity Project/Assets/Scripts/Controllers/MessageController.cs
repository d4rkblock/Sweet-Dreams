using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class MessageController : MonoBehaviour 
{
	public static string Message { get; set; }

	public int timeToRemove = 2;
	public float positionY;
	public float positionX;

	private float timeAux;

	// Use this for initialization
	void Start () 
	{
		Message = string.Empty;
	}

	void Update()
	{
		timeAux += Time.deltaTime;

		if (timeAux > timeToRemove) 
		{
			Message = string.Empty;
			timeAux = 0; 
		}
	}

	void OnGUI()
	{
		GUI.Label (new Rect(positionX, positionY, 300, 20), Message, new GUIStyle
		{
			fontSize = 17,
			wordWrap = true,
			fontStyle = FontStyle.BoldAndItalic,

		});
	}
}