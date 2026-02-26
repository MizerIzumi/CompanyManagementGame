using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    //TODO: Add Icons for what kind of stats will be important for this dungeon,
    //Also in general add more Icons in the game to signify things instead of text.
    public class AS_DungeonUI : ActionStack.ActionBehavior, IAdventurerUI
    {
        [Header("Local References")]
        [SerializeField]
        private GameObject _dungeonUI;
        [SerializeField]
        private TextMeshProUGUI _dungeonNameText;
        [SerializeField]
        private TextMeshProUGUI _dangerRatingNumber;
        [SerializeField]
        private TextMeshProUGUI _currentPartySizeText;
        [SerializeField]
        private TextMeshProUGUI _maxPartySizeText;
        [SerializeField] 
        private GameObject _partyGrid;
        [SerializeField] 
        private GameObject _compAdveGrid;
        //[SerializeField]
        public AS_EncounterUI asEncounterUI;
        
        [Header("Other References")]
        [SerializeField]
        private CompanyAdventurersList _companyAdventurersList;
        [SerializeField]
        private GameObject _AdventurerBox;
        
        public Dungeon _dungeon;
        private DungeonManager _dungeonManager;
        private List<GameObject> _SpawnedCompAdvBoxes = new();
        private List<GameObject> _SpawnedPartyAdvBoxes = new();
        private bool _isDone = false;
        [HideInInspector]
        public bool _firstTime = true;
        

        public override void OnBegin(bool bFirstTime)
        {
            base.OnBegin(bFirstTime);
            if (bFirstTime)
            {
                asEncounterUI.dungeonManager = _dungeonManager;
                _firstTime = false;
            }
            _isDone = false;
            if (_dungeon.isDone)
            {
                _dungeon = null;
            }
            EnableUI();
        }

        private void EnableUI()
        {
            SetupAdventurerBoxes();
            _dungeonNameText.text = _dungeon.dungeonData.dungeonName;
            _dangerRatingNumber.text = _dungeon.dungeonData.dangerRating.ToString();
            UpdatePartyNumberDisplay();
            _dungeonUI.gameObject.SetActive(true);
        }

        private void DisableUI()
        {
            _dungeonUI.gameObject.SetActive(false);
            ClearAdventurerBoxes();
        }

        public void SetDungeonManager(DungeonManager dungeonManager)
        {
            _dungeonManager = dungeonManager;
        }

        public void SetDungeon(Dungeon dungeon)
        {
            _dungeon = dungeon;
        }

        public void StartDungeon()
        {
            if (_dungeon.dungeonStarted) return;
            
            if (_dungeon == null)
            {
                Debug.LogError("AS_DungeonUI.StartDungeon: Dungeon is null, you need to make a dungeon before starting it.");
                return;
            }
            
            if (_dungeonManager.StartDungeon(_dungeon))
            {
                //Party.Count is not 0
                Exit();
            }
            //Party.Count is 0
            //TODO: Error Popup telling you that you cant start a dungeon with no party members
        }

        public void SelectAdventurerBox(AdventurerBox adventurerbox)
        {
            if (_dungeon.dungeonStarted)
            {
                adventurerbox.DeselectBox();
                return;
            }
            AdventurerStats adventurer = adventurerbox.adventurerOBJ.GetComponent<AdventurerStats>();
            if (_dungeon.party.Contains(adventurer))
            {
                RemoveAdventurerFromPary(adventurerbox);
                adventurerbox.DeselectBox();
            }
            else
            {
                AddAdventurerToPary(adventurerbox);
                adventurerbox.DeselectBox();
            }
            adventurerbox.DeselectBox();
        }

        private void AddAdventurerToPary(AdventurerBox advBox)
        {
            AdventurerStats adventurer = advBox.adventurerOBJ.GetComponent<AdventurerStats>();
            if (_dungeonManager.CanAdventurerJoinParty(_dungeon, adventurer))
            {
                //Adventurer can join the party
                _dungeonManager.AddAdventurerToParty(_dungeon, adventurer);
                _SpawnedCompAdvBoxes.Remove(advBox.gameObject);
                _SpawnedPartyAdvBoxes.Add(advBox.gameObject);
                advBox.gameObject.transform.SetParent(_partyGrid.transform);

                UpdatePartyNumberDisplay();
                return;
            }
            //Adventurer can not join the party
        }

        private void RemoveAdventurerFromPary(AdventurerBox advBox)
        {
            AdventurerStats adventurer = advBox.adventurerOBJ.GetComponent<AdventurerStats>();
            _dungeonManager.RemoveAdventurerFromParty(_dungeon, adventurer);
            _SpawnedPartyAdvBoxes.Remove(advBox.gameObject);
            _SpawnedCompAdvBoxes.Add(advBox.gameObject);
            advBox.gameObject.transform.SetParent(_compAdveGrid.transform);

            UpdatePartyNumberDisplay();
        }

        private void SetupAdventurerBoxes()
        {
            foreach (AdventurerStats pAdventurer in _dungeon.party)
            {
                AddNewAdvBox(_partyGrid, pAdventurer.gameObject, _SpawnedPartyAdvBoxes);
            }
            
            if (_dungeon.dungeonStarted) return;
            
            foreach (GameObject cAdventurer in _companyAdventurersList.GetAdventurers())
            {
                if (cAdventurer.GetComponent<AdventurerStats>().isOccupied)
                {
                    continue;
                }
                AddNewAdvBox(_compAdveGrid,  cAdventurer.gameObject, _SpawnedCompAdvBoxes);
            }
        }
        
        //TODO: A little late but I should make common UI functions into an interface that they all can inherit so I can skip writing similar functions so often in the future.
        //Or maybe not an interface, maybe a base class to derive from.
        private void AddNewAdvBox(GameObject Grid, GameObject adventurerOBJ, List<GameObject> spawnedBoxesList)
        {
            GameObject advbox = Instantiate(_AdventurerBox, Grid.transform);
            advbox.GetComponent<AdventurerBox>().InitializeAdventurerBox(adventurerOBJ, this);
            
            spawnedBoxesList.Add(advbox);
        }

        private void UpdatePartyNumberDisplay()
        {
            _maxPartySizeText.text = _dungeon.dungeonData.partySize.ToString();
            _currentPartySizeText.text = _dungeon.party.Count.ToString();
        }

        private void ClearAdventurerBoxes()
        {
            if (_SpawnedCompAdvBoxes.Count > 0)
            {
                foreach (GameObject cAdvBox in _SpawnedCompAdvBoxes)
                {
                    Destroy(cAdvBox);
                }
                _SpawnedCompAdvBoxes.Clear();
            }

            if (_SpawnedPartyAdvBoxes.Count <= 0) return;
            if (!_dungeon.dungeonStarted)
            {
                foreach (GameObject pAdvBox in _SpawnedPartyAdvBoxes)
                {
                    _dungeonManager.RemoveAdventurerFromParty(_dungeon, pAdvBox.GetComponent<AdventurerBox>().adventurerOBJ.GetComponent<AdventurerStats>());
                    Destroy(pAdvBox);
                }
            }
            else
            {
                foreach (GameObject pAdvBox in _SpawnedPartyAdvBoxes)
                {
                    Destroy(pAdvBox);
                }
            }
            
            _SpawnedPartyAdvBoxes.Clear();
        }
        
        public void Exit()
        {
            _isDone = true;
        }

        public override bool IsDone()
        {
            base.IsDone();
            return _isDone;
        }

        public override void OnEnd()
        {
            if (_dungeon.isDone)
            {
                _dungeon = null;
            }
            DisableUI();
        }
    }
}

