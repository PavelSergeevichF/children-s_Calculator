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
        mainView.SettingPanelView.ExitButton.onClick.AddListener(ExitProgramm);

        _sOData = mainView.SOData;
        SetToggle();
        SetViewString();
    }

    public void Execute()
    {
        if (_sOData.Subtraction != _mainView.SettingPanelView.SubtractionToggle.isOn)
        {
            _sOData.Subtraction = _mainView.SettingPanelView.SubtractionToggle.isOn;
            if (_sOData.Subtraction){ _sOData.ListTask.Add(ActionNum.Subtraction);}
            else  { _sOData.ListTask.Remove(ActionNum.Subtraction); }
        }
        if (_sOData.Addition != _mainView.SettingPanelView.AdditionToggle.isOn)
        {
            _sOData.Addition = _mainView.SettingPanelView.AdditionToggle.isOn;
            if (_sOData.Addition) { _sOData.ListTask.Add(ActionNum.Addition); }
            else { _sOData.ListTask.Remove(ActionNum.Addition); }
        }
        if (_sOData.Multiplication != _mainView.SettingPanelView.MultiplicationToggle.isOn)
        {
            _sOData.Multiplication = _mainView.SettingPanelView.MultiplicationToggle.isOn;
            if (_sOData.Multiplication) { _sOData.ListTask.Add(ActionNum.Multiplication); }
            else { _sOData.ListTask.Remove(ActionNum.Multiplication); }
        }
        if (_sOData.Division != _mainView.SettingPanelView.DivisionToggle.isOn)
        {
            _sOData.Division = _mainView.SettingPanelView.DivisionToggle.isOn;
            if (_sOData.Division) { _sOData.ListTask.Add(ActionNum.Division); }
            else { _sOData.ListTask.Remove(ActionNum.Division); }
        }
    }
    private void SetToggle()
    {
        _mainView.SettingPanelView.SubtractionToggle.isOn =_sOData.Subtraction ;
        _mainView.SettingPanelView.AdditionToggle.isOn = _sOData.Addition;
        _mainView.SettingPanelView.MultiplicationToggle.isOn = _sOData.Multiplication;
        _mainView.SettingPanelView.DivisionToggle.isOn = _sOData.Division;
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
        _sOData.str = str;
    }

    private void ResetLocalScore()
    {
        _sOData.LocalScore = 0;
    }

    private void ExitProgramm() => Application.Quit();

}
