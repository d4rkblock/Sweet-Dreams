using UnityEngine;
using System.Collections;

public class WeaponCollectedController {

	public static BaseWeapon CurrentFirstWeapon { get; set; }
	public static BaseWeapon CurrentSecondWeapon { get; set; }
	
	public static bool CanInstantiate { get; set; }
	public static bool AlreadyCollected { get; set; }

	public static void CollectWeapon(BaseWeapon currentGun = null)
	{
		if ((CurrentFirstWeapon != null && currentGun.gameObject.layer == CurrentFirstWeapon.gameObject.layer) ||
		    (CurrentSecondWeapon != null && currentGun.gameObject.layer == CurrentSecondWeapon.gameObject.layer)) {
			AlreadyCollected = true;
			MessageController.Message = "Você já possui " + currentGun.weaponName + " em seu inventário";
		}
		else 
		{
			if (CurrentFirstWeapon != null && CurrentSecondWeapon == null) 
			{
				CanInstantiate = false;
				CurrentSecondWeapon = currentGun;
			}
			else if ((CurrentFirstWeapon == null && CurrentSecondWeapon != null) || 
			         (CurrentFirstWeapon == null && CurrentSecondWeapon == null))
			{
				CanInstantiate = true;
				CurrentFirstWeapon = currentGun;
			}
		}
	}
}