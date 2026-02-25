using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CompanyAdventurersUI : MonoBehaviour,  IAdventurerUI
    {
        public AdventurerBox selectedAdventurerBox;
        
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
        private bool _firstTime = true;

        public void EnableUI()
        {
            if (_firstTime)
            {
                _statDisplay = gameObject.GetComponent<Statdisplay>();
                _firstTime = false;
            }
            
            SetupAdventurerGrid();
            
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
            
            foreach (GameObject adventurerbox in _spawnedBoxes)
            {
                Destroy(adventurerbox.gameObject);
            }
            _spawnedBoxes.Clear();
            selectedAdventurerBox = null;
        }
        
        private void SetupAdventurerGrid()
        {
            if (_compAdv.GetAdventurers().Count > 0)
            {
                foreach (var adventurer in _compAdv.GetAdventurers())
                {
                    AddNewAdventurerBox(adventurer);
                }
            }
        }

        private void AddNewAdventurerBox(GameObject adventurer)
        {
            GameObject tAdvBox = Instantiate(_adventurerBoxPrefab, _adventurerGrid.transform);
            tAdvBox.GetComponent<AdventurerBox>().InitializeAdventurerBox(adventurer, this);
            
            _spawnedBoxes.Add(tAdvBox);
        }
        
        
        public void SelectAdventurerBox(AdventurerBox adventurerbox)
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

        public void DismissSelectedAdventurer()
        {
            if (selectedAdventurerBox != null)
            {
                _adventurerInfo.SetActive(false);
                selectedAdventurerBox.DeselectBox();
                _compAdv.RemoveAdventurer(selectedAdventurerBox.adventurerOBJ);
                Destroy(selectedAdventurerBox.adventurerOBJ.gameObject);
                Destroy(selectedAdventurerBox.gameObject);
                selectedAdventurerBox = null;
            }
            else
            {
                print("No Adventurer Selected");
            }
        }
    }

}