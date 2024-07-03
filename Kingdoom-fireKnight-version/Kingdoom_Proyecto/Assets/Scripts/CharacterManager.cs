using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDatabase;

    public TextMeshProUGUI nameText;
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

    public void NextOption()
    {
        selectedOption++;

        if(selectedOption >= characterDatabase.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdateChracter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;

        if(selectedOption < 0)
        {
            selectedOption = characterDatabase.CharacterCount - 1;
        }

        UpdateChracter(selectedOption);
        Save();
    }

    private void UpdateChracter(int selectedOption)
    {
        Character character = characterDatabase.GetCharacter(selectedOption);
        artSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("opcion");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("opcion", selectedOption);
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
