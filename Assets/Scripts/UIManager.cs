using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	public Slider healthBar;
	public TMP_Text HPText;
	public TMP_Text LvlText;

	public PlayerHealthManager playerHealth;
	private PlayerStats playerStats;
	private static bool UIExists;

    // Start is called before the first frame update
    void Start()
    {
        if (!UIExists)
		{
			UIExists = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy(gameObject);
		}

		playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
    	healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;

		LvlText.text = "Level: " + playerStats.currentLevel;
     }
}
