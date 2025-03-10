
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class MainPanelController
{
    private bool _example=false;
    private bool _cof=false;
    private float _result = 0f;

    private SOData _sOData;
    private MainView _mainView;

    private ButtonPanelController _buttonPanelController;

    public string AnswerStr = "";

    public MainPanelController(MainView mainView)
    {
        _buttonPanelController = new ButtonPanelController(this, mainView.MainPanelView.ButtonPanelView);
        _mainView = mainView;
        _sOData = mainView.SOData;
        _mainView.MainPanelView.CheckButton.onClick.AddListener(CheckTask);
        _sOData.Score = PlayerPrefs.GetInt("Score");
        _sOData.LocalScore = PlayerPrefs.GetInt("LocalScore");
        CreatExample();
    }

    public void Execute()
    {
        ShoweAnswer();
    }

    public void CreatExample() 
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
                    if(num2>100)
                    {
                        num2=(int)(num2/100);
                    }
                    float mum1f = num1;
                    float mum2f = num2;
                    _mainView.MainPanelView.TasckText.text = $"{num1}/{num2}=";
                    _result = mum1f / mum2f;
                    _cof = true;
                    string resultStr = _result.ToString();
                    if(resultStr.Length>6)
                    {
                        CreatExample();
                    }
                }
            break;
        }
    }
    private void CheckTask()
    {
        float tempF = 0f;
        tempF = float.Parse(AnswerStr);//tempF = float.Parse( _mainView.MainPanelView.InputField.text);
        if (tempF== _result)
        {
            AddScore();
        }
        else
        {
            RemovScore();
        }
        PlayerPrefs.SetInt("LocalScore", _sOData.LocalScore);
        PlayerPrefs.SetInt("Score", _sOData.Score);
        CreatExample();
        AnswerStr = "";
        //_mainView.MainPanelView.InputField.text = "";
    }
    private void AddScore()
    {
        if (!_cof) { _sOData.Score++; _sOData.LocalScore++; }
        else { _sOData.Score += 2; _sOData.LocalScore += 2; }
    }
    private void RemovScore()
    {
        if (!_cof) { _sOData.Score--; _sOData.LocalScore--; }
        else { _sOData.Score -= 2; _sOData.LocalScore -= 2; }
    }
    private void ShoweAnswer()
    {
        if (AnswerStr != _mainView.MainPanelView.AnswerText.text)
        {
            _mainView.MainPanelView.AnswerText.text = AnswerStr;
        }
    }
}
