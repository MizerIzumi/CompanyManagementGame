using UnityEngine;


namespace Game
{
    public class CompanyStats : StatBlock
    {
        string Name = "asfsfg";
        
        [SerializeField]
        private string _companyName = "Grimoire";

        [SerializeField]
        private int _companyReputationLVL = 1;

        [SerializeField]
        private int _companyInventorySize = 10;
        
        [SerializeField]
        private int _shopInventorySize = 5;

        [SerializeField]
        private int _companyFunds = 0;

        public int CompanyFunds
        {
            get
            {
                return _companyFunds;
            }

            set
            {
                _companyFunds = value;
            }
        }
    }
}