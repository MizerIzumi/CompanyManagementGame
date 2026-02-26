using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Game
{
    public class DungeonButton : MonoBehaviour
    {
        private DungeonManager _dungeonManager;
        public SO_DungeonData dungeonData;
        public TextMeshProUGUI  dungeonName;
        public Button dungeonButton;
        public GameObject noticeIcon;
        public TextMeshProUGUI dungeonLevel;
        public TextMeshProUGUI dungeonStatus;

        private void Start()
        {
            _dungeonManager = FindAnyObjectByType<DungeonManager>();
            dungeonButton.onClick.AddListener(OpenDungeon);
            dungeonName.text = dungeonData.dungeonName;
            _dungeonManager.OnEncounter += CheckEncounter;
            _dungeonManager.OnDungeonStatusChanged += UpdateDungeonStatus;
            dungeonLevel.text = "Lvl: " + dungeonData.dangerRating;
        }

        private void OpenDungeon()
        {
            _dungeonManager.OpenDungeonUI(dungeonData);
        }

        private void CheckEncounter(Encounter encounter)
        {
            if (_dungeonManager.GetDungeon(dungeonData).activeEncounter != null)
            {
                noticeIcon.SetActive(!_dungeonManager.GetDungeon(dungeonData).activeEncounter.resolved);
            }
            else
            {
                noticeIcon.SetActive(false);
            }
        }

        private void UpdateDungeonStatus(Dungeon dungeon)
        {
            if (dungeon.dungeonData != dungeonData) return;
            if (dungeon.dungeonStarted)
            {
                dungeonStatus.text = "Status: Inprogress...";
            }
            else
            {
                dungeonStatus.text = "Status: Available";
            }
        }
    }
}
