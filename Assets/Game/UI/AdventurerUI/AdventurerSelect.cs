using UnityEngine;

public class AdventurerSelect : MonoBehaviour
{
    public GameObject selectedAdventurer;

    public void UpdateSelectedAdventurer(GameObject adventurer)
    {
        selectedAdventurer = adventurer;
    }
}
