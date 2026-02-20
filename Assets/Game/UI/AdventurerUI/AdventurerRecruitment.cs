using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AdventurerRecruitment : MonoBehaviour,  IAdventurerUI
    {
        public AdventurerBox selectedAdventurerBox;
        public int amountAdvToGenerate = 5;
        
        [SerializeField]
        private AdventurerGenerator _advgen;
        [SerializeField] 
        private CompanyAdventurersList _compAdv;
        [SerializeField] 
        private GameObject _adventurerGrid;
        [SerializeField]
        private List<GameObject> _spawnedBoxes = new List<GameObject>();
        [SerializeField]
        private GameObject _adventurerInfo;
        [SerializeField]
        private GameObject _adventurerBoxPrefab;
        private Statdisplay _statDisplay;
        private bool _hasListOfAdventurer = false;
        private bool _firstTime = true;
        private TimeManager _timeManager;

        public void Initialize()
        {
            _timeManager = GameManager.Instance.timeManager;
            _timeManager.OnDaySlotChanged += ClearRecruitableAdventurers;
        }

        public void Deconstruct()
        {
            _timeManager.OnDaySlotChanged -= ClearRecruitableAdventurers;
            ClearRecruitableAdventurers();
        }
        
        public void EnableUI()
        {
            if (_firstTime)
            {
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
            if (selectedAdventurerBox)
            {
                selectedAdventurerBox.DeselectBox();
            }
            selectedAdventurerBox = null;
        }
        
        private void GetBatchOfAdventurers()
        {
            for (int i = 0; i < amountAdvToGenerate; i++)
            {
                AddNewAdventurerBox();
            }
        }

        private void AddNewAdventurerBox()
        {
            GameObject advbox = Instantiate(_adventurerBoxPrefab, _adventurerGrid.transform);
            advbox.GetComponent<AdventurerBox>().InitializeAdventurerBox(_advgen.GenerateAdventurer(), this);
            
            _spawnedBoxes.Add(advbox);
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
                if (_compAdv.TryRecruitAdventurer(tadventurer))
                {
                    _adventurerInfo.SetActive(false);
                    selectedAdventurerBox.DeselectBox();
                    _spawnedBoxes.Remove(selectedAdventurerBox.gameObject);
                    Destroy(selectedAdventurerBox.gameObject);
                }
                else
                {
                    print("Cant recruit adventurer");
                }
            }
            else
            {
                print("No Adventurer Selected");
            }
        }

        private void ClearRecruitableAdventurers()
        {
            foreach (GameObject adventurerbox in _spawnedBoxes)
            {
                Destroy(adventurerbox.GetComponent<AdventurerBox>().adventurerOBJ.gameObject);
                Destroy(adventurerbox.gameObject);
            }
            _spawnedBoxes.Clear();
            _hasListOfAdventurer = false;
            selectedAdventurerBox = null;
        }
        
        private void ClearRecruitableAdventurers(TimeManager.DaySlot daySlot)
        {
            foreach (GameObject adventurerbox in _spawnedBoxes)
            {
                Destroy(adventurerbox.GetComponent<AdventurerBox>().adventurerOBJ.gameObject);
                Destroy(adventurerbox.gameObject);
            }
            _spawnedBoxes.Clear();
            _hasListOfAdventurer = false;
            selectedAdventurerBox = null;
        }
    }

}
