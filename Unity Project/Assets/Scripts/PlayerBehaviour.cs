using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	private BaseWeapon currentGun;

	// Use this for initialization
	void Start () {
		currentGun = GetComponentInChildren<BaseWeapon> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}