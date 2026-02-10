using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game
{
    public class AdventurerBox : MonoBehaviour
    {
        public GameObject adventurerOBJ;
        private AdventurerRecruitment _advRecruitment;
        [SerializeField]
        private GameObject _selectedBorder;
        [SerializeField]
        private TextMeshProUGUI _advNameText;

        public void InitializeAdventurerBox(GameObject adventurer, AdventurerRecruitment  advrecruitment)
        {
            adventurerOBJ = adventurer;
            _advRecruitment = advrecruitment;
            _advNameText.text = adventurer.GetComponent<AdventurerStats>().GetName();
        }
        
        public void SelectBox()
        {
            _advRecruitment.UpdateSelectedAdventurerBox(this);
            _selectedBorder.SetActive(true);
        }

        public void DeselectBox()
        {
            _selectedBorder.SetActive(false);
        }
    }
}