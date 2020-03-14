using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {
	HealthManager healthManager;
	bool isDestroyed = false;
	public GameObject deadScreen;
	

// <<<<<<< HEAD
	void Start() {
		healthManager = GetComponent<HealthManager>();
		deadScreen = GameObject.Find("UI/InGameUI/DeadScreen");
	}

	void Update() {
		if(healthManager.IsDead && !isDestroyed) {
			isDestroyed = true;

			StartCoroutine(ShowDeadScreen());

			MonoBehaviour[] scripts = GetComponentsInChildren<MonoBehaviour>();

			foreach(MonoBehaviour script in scripts) {
				// Disable all weapons
				if(script is WeaponBase) {
					DisableWeapon((WeaponBase)script);
				}
				// Deactivate player controls
				else if(script is FirstPersonController) {
					DisableController((FirstPersonController)script);
				}
			}
		}
	}

	void DisableWeapon(WeaponBase weapon) {
		weapon.IsEnabled = false;
	}

	void DisableController(FirstPersonController controller) {
		controller.enabled = false;
	}

	IEnumerator ShowDeadScreen() {
		deadScreen.SetActive(true);

		Image image = deadScreen.GetComponent<Image>();
		Color origColor = image.color;

		for(float alpha = 0.0f; alpha <= 1.1f; alpha += 0.1f) {
			image.color = new Color(origColor.r, origColor.g, origColor.b, alpha);
			yield return new WaitForSeconds(0.1f);
		}

		yield break;
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if(hit.gameObject.tag == "BulletCase") {
			Physics.IgnoreCollision(GetComponent<Collider>(), hit.gameObject.GetComponent<Collider>());
		}
	}
	//=======
	public class Player2 : MonoBehaviour
	{
		public float healt;
		public Slider healthBar;
		public GameObject menuMuerte;

		private void Start()
		{
			healt = 0f;
		}


		private void Update()
		{
			if (healt >= 1)
			{
				Time.timeScale = 0f;
			}
		}


		public void damage()
		{
			healthBar.value += 0.10f;
			healt += 0.10f;
		}


	}	//>>>>>>> d1d57959047fca7ae19d1813ea2143b2a4752616
}
