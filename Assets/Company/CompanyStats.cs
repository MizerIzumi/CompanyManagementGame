using UnityEngine;


namespace Company
{
    public class CompanyStats : MonoBehaviour
    {
        [SerializeField]
        private string _companyName = "Grimoire";

        [SerializeField]
        private int _companyReputationLVL = 1;

        [SerializeField]
        private int _companyInventorySize = 10;
        
        [SerializeField]
        private int _shopInventorySize = 5;

        
        void Start()
        {

        }

        void Update()
        {

        }

        public void ChangeCompanyName(string newCompanyName)
        {
            _companyName = newCompanyName;
        }

        public string GetCompanyName()
        {
            return _companyName;
        }

        public void ChangeCompanyReputationLevel(int newReputation)
        {
            _companyReputationLVL = newReputation;
        }

        public int GetCompanyReputationLevel()
        {
            return _companyReputationLVL;
        }

        public void ChangeCompanyInventorySize(int newInventorySize)
        {
            _companyInventorySize = newInventorySize;
        }

        public int GetCompanyInventorySize()
        {
            return _companyInventorySize;
        }

        public void ChangeShopInventorySize(int newShopInventorySize)
        {
            _shopInventorySize = newShopInventorySize;
        }

        public int GetShopInventorySize()
        {
            return _shopInventorySize;
        }
    }
}