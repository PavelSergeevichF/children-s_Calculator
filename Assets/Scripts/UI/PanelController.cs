
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PanelController : IExecute
{
    private SOData _sOData;

    protected MainView _mainView;

    private SettingPanelController _settingPanelController;
    private MainPanelController _mainPanelController;

    public SOData SOData => _sOData;

    public PanelController(MainView mainView)
    {
        _sOData = mainView.SOData;
        _mainView = mainView;

        mainView.MainPanelView.BeackButton.onClick.AddListener(SettingPanelActive);
        mainView.SettingPanelView.BeackButton.onClick.AddListener(MainPanelActive);

        _mainPanelController = new MainPanelController(mainView);
        _settingPanelController = new SettingPanelController(mainView);
    }
    public void Execute()
    {
        _mainView.MainPanelView.ScoreText.text = _sOData.Score.ToString();
        _mainView.SettingPanelView.ScoreText.text = _sOData.Score.ToString();
        _mainView.MainPanelView.LocalScoreText.text = _sOData.LocalScore.ToString();
        _mainView.SettingPanelView.LocalScoreText.text = _sOData.LocalScore.ToString();

        if (_mainView.SettingPanelView.SettingPanel.activeSelf)
        {
            _settingPanelController.Execute();
        }

        if (_mainView.MainPanelView.MainPanel.activeSelf)
        {
            _mainPanelController.Execute();
        }
    }

    public void MainPanelActive()
    {
        _mainView.MainPanelView.MainPanel.SetActive(true);
        _mainView.SettingPanelView.SettingPanel.SetActive(false);
        _mainPanelController.CreatExample();
    }

    public void SettingPanelActive()
    {
        _mainView.MainPanelView.MainPanel.SetActive(false);
        _mainView.SettingPanelView.SettingPanel.SetActive(true);
    }
}