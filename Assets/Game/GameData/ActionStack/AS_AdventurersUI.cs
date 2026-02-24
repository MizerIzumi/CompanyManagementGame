using Game;
using UnityEngine;

public class AS_AdventurersUI : ActionStack.ActionBehavior
{
    [SerializeField]
    private GameObject _adventurersUI;
    [SerializeField]
    private AdventurerRecruitment _recruitUI;
    [SerializeField]
    private CompanyAdventurersUI _companyAdvUI;
    
    private bool _isDone;
    
    public override void OnBegin(bool bFirstTime)
    {
        if (bFirstTime)
        {
            _recruitUI.Initialize();
        }
        _isDone = false;
        _adventurersUI.SetActive(true);
    }

    public void RecruitOrCompanyView(bool recruit)
    {
        if (recruit)
        {
            _companyAdvUI.DisableUI();
            _recruitUI.EnableUI();
        }
        else
        {
            _recruitUI.DisableUI();
            _companyAdvUI.EnableUI();
        }
    }

    public void Exit()
    {
        _isDone = true;
    }

    public override bool IsDone()
    {
        return _isDone;
    }
    
    public override void OnEnd()
    {
        _companyAdvUI.DisableUI();
        _recruitUI.DisableUI();
        _adventurersUI.SetActive(false);
    }
}
