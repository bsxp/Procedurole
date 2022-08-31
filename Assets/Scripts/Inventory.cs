using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum Currencies {
	Copper,
	Silver,
	Gold,
	Platinum,
	Arcanum
};

// Manage the players' inventory
// Includes items, spells, and currencies
public class Inventory : MonoBehaviour {

	// Each of the different currencies
	// 1 copper = 1 copper
	// 1 silver = 10 copper
	// 1 gold = 10 silver, 1 gold = 100 copper
	// 1 platinum = 10 gold, 1 platinum = 100 silver, 1 platinum = 1000 copper
	// Arcanum is its own magic currency and has no explicit conversions
	public int Copper { get; private set; } = 0;
	public int Silver { get; private set; } = 0;
	public int Gold { get; private set; } = 0;
	public int Platinum { get; private set; } = 0;
	public int Arcanum { get; private set; } = 0;

	// Text objects
	public TMP_Text cpText;
	public TMP_Text spText;
	public TMP_Text gpText;
	public TMP_Text ppText;
	public TMP_Text arcText;

	public Button giveCurrencyButton;

	// Give currency to the player, capping out at the Int32 max value for that currency
	public void giveCurrency(int cp = 0, int sp = 0, int gp = 0, int pp = 0, int arc = 0) {
		
		// Attempt to add coppre
		try  {
			checked {
				Copper += cp;
			}
		} catch {
			Copper = int.MaxValue;
		}

		// Attempt to add silver
		try  {
			checked {
				Silver += sp;
			}
		} catch {
			Silver = int.MaxValue;
		}

		// Attempt to add gold
		try  {
			checked {
				Gold += gp;
			}
		} catch {
			Gold = int.MaxValue;
		}

		// Attempt to add platinum
		try  {
			checked {
				Platinum += pp;
			}
		} catch {
			Platinum = int.MaxValue;
		}

		// Attempt to add tokena
		try  {
			checked {
				Arcanum += arc;
			}
		} catch {
			Arcanum = int.MaxValue;
		}

		// Set text object values
		cpText.text = "x " + Copper.ToString();
		spText.text = "x " + Silver.ToString();
		gpText.text = "x " + Gold.ToString();
		ppText.text = "x " + Platinum.ToString();
		arcText.text = "x " + Arcanum.ToString();

	}

	// Remove currencies from the user's inventorys
	public void takeCurrency(int cp = 0, int sp = 0, int gp = 0, int pp = 0, int arc = 0) {

		// Subtract copper
		Copper -= cp;
		if (Copper < 0)
			Copper = 0;

		// Subtract silver
		Silver -= sp;
		if (Silver < 0)
			Silver = 0;

		// Subtract gold
		Gold -= gp;
		if (Gold < 0)
			Gold = 0;

		// Subtract platinum
		Platinum -= pp;
		if (Platinum < 0)
			Platinum = 0;

		// Subtract arcanum
		Arcanum -= arc;
		if (Arcanum < 0)
			Arcanum = 0;
	}

	void Start() {
		giveCurrencyButton.onClick.AddListener(() => giveCurrency(9));
	}

}
