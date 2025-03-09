using UnityEngine;

public class SettingPanelController
{
    private const int _maxNumSize=4;
    private const int _minNumSize = 1;

    private SOData _sOData;
    private MainView _mainView;
    public SettingPanelController(MainView mainView)
    {
        _mainView = mainView;

        mainView.SettingPanelView.NextNumButton.onClick.AddListener(AddNum);
        mainView.SettingPanelView.BeackNumButton.onClick.AddListener(ReduceNum);
        mainView.SettingPanelView.ResetButton.onClick.AddListener(ResetLocalScore);

        _sOData= mainView.SOData;
        SetToggle();
        SetViewString();
    }

    public void Execute() => GetToggle();
    private void SetToggle()
    {
        _mainView.SettingPanelView.SubtractionToggle.isOn =_sOData.Subtraction ;
        _mainView.SettingPanelView.AdditionToggle.isOn = _sOData.Addition;
        _mainView.SettingPanelView.MultiplicationToggle.isOn = _sOData.Multiplication;
        _mainView.SettingPanelView.DivisionToggle.isOn = _sOData.Division;
    }

    private void GetToggle()
    {
        _sOData.Subtraction = _mainView.SettingPanelView.SubtractionToggle.isOn;
        _sOData.Addition  = _mainView.SettingPanelView.AdditionToggle.isOn;
        _sOData.Multiplication = _mainView.SettingPanelView.MultiplicationToggle.isOn;
        _sOData.Division = _mainView.SettingPanelView.DivisionToggle.isOn;
    }
    
    private void AddNum()
    {
        if (_sOData.NumSize < _maxNumSize)
        {
            _sOData.NumSize++;
        }
        else 
        {
            _sOData.NumSize = 1;
        }
        SetViewString();
    }
    private void ReduceNum() 
    {
        if (_sOData.NumSize > _minNumSize)
        {
            _sOData.NumSize--;
        }
        else
        {
            _sOData.NumSize = 4;
        }
        SetViewString();
    }

    private void SetViewString()
    {
        string str ="";
        for (int i = 0; i < _sOData.NumSize; i++)
        {
            str += "0";
        }
        _mainView.SettingPanelView.ShowNum.text = str;
    }

    private void ResetLocalScore()
    {
        _sOData.LocalScore = 0;
    }


}
