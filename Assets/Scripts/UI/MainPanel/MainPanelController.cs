
using UnityEngine;

public class MainPanelController
{
    private bool _example=false;
    private bool _cof=false;
    private float _result = 0f;

    private SOData _sOData;
    private MainView _mainView;

    public MainPanelController(MainView mainView)
    {
        _mainView = mainView;
        _sOData = mainView.SOData;
        _mainView.MainPanelView.CheckButton.onClick.AddListener(CheckTask);
        CreatExample();
    }

    public void Execute()
    { }

    private void CreatExample() 
    {
        int actionTask=Random.Range(1, _sOData.ListTask.Count);
        int min =(int) Mathf.Pow(10,(_sOData.str.Length-1));
        int max = (int)(9.99999* Mathf.Pow(10, (_sOData.str.Length - 1)));
        int num1 = Random.Range(min, max);
        int num2 = Random.Range(min, max);
        
        switch (_sOData.ListTask[actionTask-1]) 
        { 
            case ActionNum.Subtraction: 
                {
                    if (num1 < num2)
                    {
                        int tmp = num1;
                        num1 = num2;
                        num2 = tmp;
                    }
                    _mainView.MainPanelView.TasckText.text = $"{num1}-{num2}=";
                    _result = num1 - num2;
                    _cof = false;
                }
            break;
            case ActionNum.Addition: 
                {
                    _mainView.MainPanelView.TasckText.text = $"{num1}+{num2}=";
                    _result = num1 + num2;
                    _cof = false;
                }
            break;
            case ActionNum.Multiplication: 
                {
                    _mainView.MainPanelView.TasckText.text = $"{num1}*{num2}=";
                    _result = num1 * num2;
                    _cof = true;
                }
            break;
            case ActionNum.Division: 
                {
                    _mainView.MainPanelView.TasckText.text = $"{num1}/{num2}=";
                    _result = num1 / num2;
                    _cof = true;
                }
            break;
        }
    }
    private void CheckTask()
    {
        float tempF = 0f;
        tempF = float.Parse( _mainView.MainPanelView.InputField.text);
        if (tempF== _result)
        {
            if(!_cof) { _sOData.Score++; _sOData.LocalScore++; }
            else { _sOData.Score +=2; _sOData.LocalScore +=2; }
            
        }
        else
        {
            if (!_cof) { _sOData.Score--; _sOData.LocalScore--; }
            else { _sOData.Score -= 2; _sOData.LocalScore-=2; }
        }
        CreatExample();
        _mainView.MainPanelView.InputField.text = "";
    }
}
