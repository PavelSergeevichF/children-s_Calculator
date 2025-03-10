

using System.IO;

public class ButtonPanelController
{
    private bool _setPoint = false;
    private MainPanelController _mainPanelController;
    private ButtonPanelView _buttonPanelView;

    public ButtonPanelController(MainPanelController mainPanelController, ButtonPanelView buttonPanelView)
    {
        _mainPanelController = mainPanelController;
        _buttonPanelView = buttonPanelView;
        _buttonPanelView.Button0.onClick.AddListener(ClicButton0);
        _buttonPanelView.Button1.onClick.AddListener(ClicButton1);
        _buttonPanelView.Button2.onClick.AddListener(ClicButton2);
        _buttonPanelView.Button3.onClick.AddListener(ClicButton3);
        _buttonPanelView.Button4.onClick.AddListener(ClicButton4);
        _buttonPanelView.Button5.onClick.AddListener(ClicButton5);
        _buttonPanelView.Button6.onClick.AddListener(ClicButton6);
        _buttonPanelView.Button7.onClick.AddListener(ClicButton7);
        _buttonPanelView.Button8.onClick.AddListener(ClicButton8);
        _buttonPanelView.Button9.onClick.AddListener(ClicButton9);
        _buttonPanelView.ButtonPoint.onClick.AddListener(ClicButtonPoint);
        _buttonPanelView.ButtonBackSpace.onClick.AddListener(ClicButtonBeackSpace);
    }
    private void ClicButton0() => _mainPanelController.AnswerStr += "0";
    private void ClicButton1() => _mainPanelController.AnswerStr += "1";
    private void ClicButton2() => _mainPanelController.AnswerStr += "2";
    private void ClicButton3() => _mainPanelController.AnswerStr += "3";
    private void ClicButton4() => _mainPanelController.AnswerStr += "4";
    private void ClicButton5() => _mainPanelController.AnswerStr += "5";
    private void ClicButton6() => _mainPanelController.AnswerStr += "6";
    private void ClicButton7() => _mainPanelController.AnswerStr += "7";
    private void ClicButton8() => _mainPanelController.AnswerStr += "8";
    private void ClicButton9() => _mainPanelController.AnswerStr += "9";
    private void ClicButtonPoint()  
    {
        if (!_setPoint)
        {
            _mainPanelController.AnswerStr += ",";
            _setPoint= true;
        }
    }
    private void ClicButtonBeackSpace()
    { 
        if(_mainPanelController.AnswerStr.Length>0)
        {
            if (_mainPanelController.AnswerStr[_mainPanelController.AnswerStr.Length - 1] == '.')
            {
                ResetPoint();
            }
            _mainPanelController.AnswerStr = _mainPanelController.AnswerStr.Remove(_mainPanelController.AnswerStr.Length - 1);
        }
    }
    public void ResetPoint() => _setPoint=false;
}
