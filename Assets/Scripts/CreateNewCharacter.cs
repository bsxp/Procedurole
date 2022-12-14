using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateNewCharacter : MonoBehaviour
{

	[SerializeField]
	public TMP_Text _StrText, _DexText, _ConText, _IntText, _WisText, _ChaText;

	// Manage the user's selected character type
	public PlayerClasses selectedCharacterType { get; private set; }
	
	// Stats of the selected class type
	public int Strength { get; private set; }
	public int Dexterity { get; private set; }
	public int Constitution { get; private set; }
	public int Intelligence { get; private set; }
	public int Wisdom { get; private set; }
	public int Charisma { get; private set; }

	// Update the user's character type selection
	public void UpdateCharacterType(int charType) {
		this.selectedCharacterType = (PlayerClasses)charType; // upcast to character type enum
		this.UpdateStats(charType);

		// Update display
		this.UpdateDisplay();
	}

	// Fill out the character's stats depending on the selected class
	private void UpdateStats(int charType) {

		PlayerClasses type = (PlayerClasses)charType; // Upcast to PlayerClasses type

		// Default set = 15, 14, 13, 12, 10, 8)

		switch (type) {
			case PlayerClasses.barbarian: // Total:  70
				this.Strength = 18;
				this.Dexterity = 10;
				this.Constitution = 14;
				this.Intelligence = 10;
				this.Wisdom = 8;
				this.Charisma = 10;
				break;
			case PlayerClasses.druid: // Total:  70
				this.Strength = 11;
				this.Dexterity = 13;
				this.Constitution = 12;
				this.Intelligence = 14;
				this.Wisdom = 17;
				this.Charisma = 15;
				break;
			case PlayerClasses.fighter: // Total:  71
				this.Strength = 14;
				this.Dexterity = 10;
				this.Constitution = 14;
				this.Intelligence = 12;
				this.Wisdom = 10;
				this.Charisma = 11;
				break;
			case PlayerClasses.monk: // Total:  72
				this.Strength = 14;
				this.Dexterity = 15;
				this.Constitution = 10;
				this.Intelligence = 12;
				this.Wisdom = 12;
				this.Charisma = 9;
				break;
			case PlayerClasses.paladin: // Total:  70
				this.Strength = 13;
				this.Dexterity = 10;
				this.Constitution = 17;
				this.Intelligence = 10;
				this.Wisdom = 10;
				this.Charisma = 10;
				break;
			case PlayerClasses.ranger: // Total:  72
				this.Strength = 12;
				this.Dexterity = 15;
				this.Constitution = 11;
				this.Intelligence = 13;
				this.Wisdom = 12;
				this.Charisma = 11;
				break;
			case PlayerClasses.rogue: // Total:  71
				this.Strength = 10;
				this.Dexterity = 17;
				this.Constitution = 9;
				this.Intelligence = 13;
				this.Wisdom = 10;
				this.Charisma = 12;
				break;
			case PlayerClasses.tamer: // Total:  72
				this.Strength = 9;
				this.Dexterity = 10;
				this.Constitution = 11;
				this.Intelligence = 12;
				this.Wisdom = 18;
				this.Charisma = 12;
				break;
			case PlayerClasses.warlock: // Total:  72
				this.Strength = 13;
				this.Dexterity = 9;
				this.Constitution = 13;
				this.Intelligence = 16;
				this.Wisdom = 10;
				this.Charisma = 11;
				break;
			case PlayerClasses.wizard: // Total:  72
				this.Strength = 8;
				this.Dexterity = 10;
				this.Constitution = 10;
				this.Intelligence = 17;
				this.Wisdom = 14;
				this.Charisma = 13;
				break;
			default:
				break;
		}
	}

	// Update TextMapPro objects containing text displaying the stats
	private void UpdateDisplay() {
		this._StrText.text = this.Strength.ToString();
		this._DexText.text = this.Dexterity.ToString();
		this._ConText.text = this.Constitution.ToString();
		this._IntText.text = this.Intelligence.ToString();
		this._WisText.text = this.Wisdom.ToString();
		this._ChaText.text = this.Charisma.ToString();
	}
}
