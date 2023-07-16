using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI

public class CharacterMenu : MonoBehaviour
{
    
    //Text fields
    public Text levelText, hitpointText, pesosText, upgradeCostText, xpText;

    //Logic
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    // Character Selection
    public void OnArrowClick(bool right)
    {
        if(right)
        {
            currentCharacterSelection++;

            //IF we went too far away
            if(currentCharacterSelection == GameManager.instance.playerSprites.Count)
            {currentCharacterSelection = 0;}

            OnSelectionChanged();

        }
        else 
        {
            currentCharacterSelection--;

            //IF we went too far away
            if(currentCharacterSelection < 0) 
            {
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;
                }

            OnSelectionChanged();
        }
    }

    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
    }

    public void OnUpgradeClick(){
        //
    }

    //Update character information

    public void UpdateMenu()
    {
        //Weapon
        weaponSprite.sprite = GameManager.instance.weaponSprite[0];
        upgradeCostText.text = "NOT IMPLEMENTED";

        //Meta
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        pesosText.text = GameManager.instance.pesos.ToString();
        levelText = "NOT IMPLEMENTED";

        //xp Bar
        xpText.text = "NOT IMPLEMENTED";
        xpBar.localScale = new Vector3(0.5, 0, 0);
    }
}
