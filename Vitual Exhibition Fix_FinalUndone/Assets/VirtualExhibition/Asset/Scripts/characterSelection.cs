using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
//referensi by dapper dino

public class characterSelection : NetworkBehaviour
{
    [SerializeField] private GameObject characterSelectDisplay = default;
    [SerializeField] private Transform characterPreviewParent = default;
    [SerializeField] private TMP_Text characterNameText = default;
    [SerializeField] private float turnSpeed = 90f;
    [SerializeField] private characterPreview[] characters = default;

    private int indexCharacterSekarang = 0;
    private List<GameObject> character_nya = new List<GameObject>();
    //private bool trig=false;

    public override void OnStartClient()
    {
        //if (trig == false)
        //{
            if(characterPreviewParent.childCount == 0)
            {
                foreach(var chara in characters)
                {
                    GameObject character_e = Instantiate(chara.CharacterPreviewPrefab, characterPreviewParent);
                    character_e.SetActive(false);
                    character_nya.Add(character_e);
                }
            }
            character_nya[indexCharacterSekarang].SetActive(true);
            characterNameText.text = characters[indexCharacterSekarang].CharacterName;

            characterSelectDisplay.SetActive(true);
        //}
        
    }

    private void Update()
    {
        characterPreviewParent.RotateAround(characterPreviewParent.position, characterPreviewParent.up, turnSpeed * Time.deltaTime);
    }

    public void Selectbutton()
    {
        CmdSelect(indexCharacterSekarang);
        characterSelectDisplay.SetActive(false);
        //trig = false;
    }

    [Command(requiresAuthority = false)] //ignore authority agar commad dapat di akses oleh cliet juga
    public void CmdSelect(int characterIndex, NetworkConnectionToClient sender = null) // sender di urus otomatis oleh mirror
    {
        GameObject character_e = Instantiate(characters[characterIndex].GameplayCharacterPrefab);
        NetworkServer.Spawn(character_e, sender);
    }

    public void Rightbutton()
    {
        character_nya[indexCharacterSekarang].SetActive(false);

        indexCharacterSekarang = (indexCharacterSekarang + 1) % character_nya.Count;

        character_nya[indexCharacterSekarang].SetActive(true);
        characterNameText.text = characters[indexCharacterSekarang].CharacterName;
    }

    public void Leftbutton()
    {
        character_nya[indexCharacterSekarang].SetActive(false);

        indexCharacterSekarang--;
        if(indexCharacterSekarang < 0)
        {
            indexCharacterSekarang += character_nya.Count;
        }

        character_nya[indexCharacterSekarang].SetActive(true);
        characterNameText.text = characters[indexCharacterSekarang].CharacterName;
    }
}
