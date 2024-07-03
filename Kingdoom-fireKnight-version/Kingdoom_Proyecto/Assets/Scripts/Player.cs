using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterDatabase characterDatabase;

    public SpriteRenderer artSprite;

    private int selectedOption = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("opcion"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }

        UpdateChracter(selectedOption);
    }

    private void UpdateChracter(int selectedOption)
    {
        Character character = characterDatabase.GetCharacter(selectedOption);
        artSprite.sprite = character.characterSprite;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("opcion");
    }


}
