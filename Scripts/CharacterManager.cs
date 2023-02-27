using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public TMP_Text nameText;
    public SpriteRenderer artworkSprite;
    public string artworkAnimator;

    private int selectedOption = 0;

    [SerializeField] Transform mainCamera;
    

    void Start()
    {
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }

        else
        {
            Load();
        }

        UpdateCharacter(selectedOption);
        mainCamera = Camera.main.transform;
        followCamera();
    }

    void followCamera()
    {
        gameObject.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 0f);
    }

    void Update()
    {
        followCamera();
    }

    public void NextOption()
    {
        selectedOption++;

        if(selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
    }

    public void BackOption()
    {
        selectedOption--;

        if(selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount -1;
        }

        UpdateCharacter(selectedOption);
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        artworkAnimator = character.characterAnimator;
        nameText.text = character.characterName;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    public void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }  
}
