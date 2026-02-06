using System;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class AdventurerRecruitment : MonoBehaviour
{
    public AdventurerBox selectedAdventurerBox;
    public int AmountAdvToGenerate = 5;
    
    [SerializeField]
    private AdventurerGenerator _advgen;
    [SerializeField] 
    private GameObject _adventurerGrid;
    [SerializeField]
    private List<GameObject> _spawnedBoxes = new List<GameObject>();
    private bool _hasListOfAdventurer = false;
    [SerializeField]
    private List<GameObject> _companyAdventurers = null;
    [SerializeField]
    private GameObject _adventurerInfo;
    [SerializeField]
    private GameObject _adventurerBoxPrefab;
    private Statdisplay _statDisplay;
    private bool _firstTime = true;

    public void EnableUI()
    {
        if (_firstTime)
        {
            FetchCompanyList();
            _statDisplay = gameObject.GetComponent<Statdisplay>();
            _firstTime = false;
        }
        
        if (!_hasListOfAdventurer)
        {
            GetBatchOfAdventurers();
            _hasListOfAdventurer = true;
        }
        
        _adventurerInfo.SetActive(false);
        
        gameObject.SetActive(true);
    }

    public void DisableUI()
    {
        gameObject.SetActive(false);
        selectedAdventurerBox.DeselectBox();
        selectedAdventurerBox = null;
    }
    
    private void GetBatchOfAdventurers()
    {
        for (int i = 0; i < AmountAdvToGenerate; i++)
        {
            AddNewAdventurerBox();
        }
    }

    private void AddNewAdventurerBox()
    {
        GameObject tAdvBox = Instantiate(_adventurerBoxPrefab, _adventurerGrid.transform);
        tAdvBox.GetComponent<AdventurerBox>().InitializeAdventurerBox(_advgen.GenerateAdventurer(), this);
        
        _spawnedBoxes.Add(tAdvBox);
    }

    private void FetchCompanyList()
    {
        
    }
    
    public void UpdateSelectedAdventurerBox(AdventurerBox adventurerbox)
    {
        if (selectedAdventurerBox != null)
        {
            selectedAdventurerBox.DeselectBox();
        }
        selectedAdventurerBox = adventurerbox;
        _statDisplay.adventurerStats = adventurerbox.adventurerOBJ.GetComponent<AdventurerStats>();
        _statDisplay.characterEquipmentSlots = adventurerbox.adventurerOBJ.GetComponent<CharacterEquipmentSlots>();
        _adventurerInfo.SetActive(true);
    }

    public void RecruitSelectedAdventurer()
    {
        if (selectedAdventurerBox != null)
        {
            GameObject tadventurer = selectedAdventurerBox.adventurerOBJ;
            _companyAdventurers.Add(tadventurer);
            _spawnedBoxes.Remove(selectedAdventurerBox.gameObject);
        }
        else
        {
            print("No Adventurer Selected");
        }
    }

    public void ClearRecruitableAdventurers()
    {
        foreach (GameObject adventurerbox in _spawnedBoxes)
        {
            Destroy(adventurerbox);
        }
        _spawnedBoxes.Clear();
        _hasListOfAdventurer = false;
        selectedAdventurerBox = null;
    }
}
