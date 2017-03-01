using UnityEngine;
using System.Linq;
using System;
using System.Threading;

public class PlayerBehaviour : MonoBehaviour
{
	public Transform weaponPosition;
	public BaseWeapon[] weapons;

	private BaseWeapon currentGun;

    // Use this for initialization
    void Start()
    {
        currentGun = GetComponentInChildren<BaseWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentGun != null)
            {
                currentGun.Action();
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(EnumWeapons.FIRST_WEAPON);
        }

        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(EnumWeapons.SECOND_WEAPON);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.tag == "Weapon")
            {
                GrabWeapon(other);
            }
        }
    }

    void GrabWeapon(Collider other)
    {
        try
        {
			int weaponLayer = other.gameObject.layer;
			var weaponCollected = weapons.FirstOrDefault (x => x.gameObject.layer == weaponLayer);

			WeaponCollectedController.CollectWeapon (weaponCollected);

			if (!WeaponCollectedController.AlreadyCollected)
			{
				Destroy (other.gameObject);
				
				if (weaponCollected != null)
				{
					if (weaponPosition.GetComponentInChildren<BaseWeapon>() == null)
						currentGun = weaponCollected;
					
					if (WeaponCollectedController.CanInstantiate)
					{
						Instantiate (weaponCollected, weaponPosition.position,
						             weaponPosition.rotation, weaponPosition);
						
						MessageController.Message = weaponCollected.weaponName + " coletado";
					}
				}
			}

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
		
	void SwitchWeapon(EnumWeapons code)
    {
		var currentWeapon = weaponPosition.GetComponentInChildren<BaseWeapon> ();

		if (code == EnumWeapons.FIRST_WEAPON) 
		{
			if (WeaponCollectedController.CurrentFirstWeapon != null) 
			{
				if (currentWeapon != null)
					Destroy (currentWeapon.gameObject);

				Instantiate (WeaponCollectedController.CurrentFirstWeapon, weaponPosition.position,
				             weaponPosition.rotation, weaponPosition);
			}
		} 
		else if (code == EnumWeapons.SECOND_WEAPON) 
		{
			if (WeaponCollectedController.CurrentSecondWeapon != null) 
			{
				if (currentWeapon != null)
					Destroy (currentWeapon.gameObject);

				Instantiate (WeaponCollectedController.CurrentSecondWeapon, weaponPosition.position,
				             weaponPosition.rotation, weaponPosition);
			}
		}
    }
}