using UnityEngine;
using System.Collections;

public class PlayerLightBehaviour : MonoBehaviour {

	private Light mainLight;

	// Use this for initialization
	void Start () {
		mainLight = GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) 
		{
			mainLight.enabled = mainLight.enabled ? false : true;
		}	
	}
}