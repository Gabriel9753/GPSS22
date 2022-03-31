﻿//==============================================================
// HealthSystem
// HealthSystem.Instance.TakeDamage (float Damage);
// HealthSystem.Instance.HealDamage (float Heal);
// HealthSystem.Instance.UseMana (float Mana);
// HealthSystem.Instance.RestoreMana (float Mana);
// Attach to the Hero.
//==============================================================

using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthSystemGUI : MonoBehaviour
{
	public static HealthSystemGUI Instance;

	public Image currentHealthBar;
	public Image currentHealthGlobe;
	public Text healthText;
	public float health;
	public float maxHealth;

	public Image currentManaBar;
	public Image currentManaGlobe;
	public Text manaText;
	public float mana;
	public float maxMana;

	//==============================================================
	// Regenerate Health & Mana
	//==============================================================
	public bool Regenerate = false;
	public float regen = 0.1f;
	private float timeleft = 0.0f;	// Left time for current interval
	public float regenUpdateInterval = 1f;

	public bool GodMode;

	//==============================================================
	// Awake
	//==============================================================
	void Awake()
	{
		Instance = this;
	}
	
	//==============================================================
	// Awake
	//==============================================================
  	void Start()
	{
		UpdateGraphics();
		timeleft = regenUpdateInterval; 
	}

	//==============================================================
	// Update
	//==============================================================
	void Update ()
	{
		if (Regenerate)
			Regen();
	}

	//==============================================================
	// Regenerate Health & Mana
	//==============================================================
	private void Regen()
	{
		timeleft -= Time.deltaTime;

		if (timeleft <= 0.0) // Interval ended - update health & mana and start new interval
		{
			// Debug mode
			if (GodMode)
			{
				HealDamage(maxHealth);
				RestoreMana(maxMana);
			}
			else
			{
				HealDamage(regen);
				RestoreMana(regen);				
			}

			UpdateGraphics();

			timeleft = regenUpdateInterval;
		}
	}

	//==============================================================
	// Health Logic
	//==============================================================
	private void UpdateHealthBar()
	{
		float ratio = health / maxHealth;
		currentHealthBar.rectTransform.localPosition = new Vector3(currentHealthBar.rectTransform.rect.width * ratio - currentHealthBar.rectTransform.rect.width, 0, 0);
		healthText.text = health.ToString ("0") + "/" + maxHealth.ToString ("0");
	}

	private void UpdateHealthGlobe()
	{
		float ratio = health / maxHealth;
		currentHealthGlobe.rectTransform.localPosition = new Vector3(0, currentHealthGlobe.rectTransform.rect.height * ratio - currentHealthGlobe.rectTransform.rect.height, 0);
		healthText.text = health.ToString("0") + "/" + maxHealth.ToString("0");
	}

	public void TakeDamage(float Damage)
	{
		health -= Damage;
		if (health < 1)
			health = 0;
		UpdateGraphics();
		StartCoroutine(PlayerHurts());
	}

	public void HealDamage(float Heal)
	{
		health += Heal;
		if (health > maxHealth) 
			health = maxHealth;

		UpdateGraphics();
	}
	public void SetMaxHealth(float input){
		Debug.Log("HEALTH");
		maxHealth = input;

		UpdateGraphics();
	}
	
	public void SetHealth(float input){
		health = input;

		UpdateGraphics();
	}
	
	public void SetMana(float input){
		mana = input;

		UpdateGraphics();
	}
	
	public void SetMaxMana(float input){
		maxMana = input;

		UpdateGraphics();
	}

	//==============================================================
	// Mana Logic
	//==============================================================
	private void UpdateManaBar()
	{
		float ratio = mana / maxMana;
		currentManaBar.rectTransform.localPosition = new Vector3(currentManaBar.rectTransform.rect.width * ratio - currentManaBar.rectTransform.rect.width, 0, 0);
		manaText.text = mana.ToString ("0") + "/" + maxMana.ToString ("0");
	}

	private void UpdateManaGlobe()
	{
		float ratio = mana / maxMana;
		currentManaGlobe.rectTransform.localPosition = new Vector3(0, currentManaGlobe.rectTransform.rect.height * ratio - currentManaGlobe.rectTransform.rect.height, 0);
		manaText.text = mana.ToString("0") + "/" + maxMana.ToString("0");
	}

	public void UseMana(float Mana)
	{
		mana -= Mana;
		if (mana < 1) // Mana is Zero!!
			mana = 0;

		UpdateGraphics();
	}

	public void RestoreMana(float Mana)
	{
		mana += Mana;
		if (mana > maxMana) 
			mana = maxMana;

		UpdateGraphics();
	}


	//==============================================================
	// Update all Bars & Globes UI graphics
	//==============================================================
	private void UpdateGraphics()
	{
		UpdateHealthBar();
		UpdateHealthGlobe();
		UpdateManaBar();
		UpdateManaGlobe();
	}

	//==============================================================
	// Coroutine Player Hurts
	//==============================================================
	IEnumerator PlayerHurts()
	{
		// Player gets hurt. Do stuff.. play anim, sound..

		PopupText.Instance.Popup("Ouch!", 1f, 1f); // Demo stuff!

		if (health < 1) // Health is Zero!!
		{
			yield return StartCoroutine(PlayerDied()); // Hero is Dead
		}

		else
			yield return null;
	}

	//==============================================================
	// Hero is dead
	//==============================================================
	IEnumerator PlayerDied()
	{
		// Player is dead. Do stuff.. play anim, sound..
		PopupText.Instance.Popup("You have died!", 1f, 1f); // Demo stuff!

		yield return null;
	}
}