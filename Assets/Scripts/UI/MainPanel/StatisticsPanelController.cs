using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class StatisticsPanelController
{
    private SettingPanelView _settingPanelView;

    public StatisticsPanelController(SettingPanelView settingPanelView, SOData sOData)
    {
        _settingPanelView = settingPanelView;
        if (sOData.FirstStart) { ResetStatistics(); }
        _settingPanelView.StatisticsPanelView.BeackButton.onClick.AddListener(BeackToPanelSettings);
        _settingPanelView.StatisticsPanelView.ResetButton.onClick.AddListener(ResetStatistics);
        _settingPanelView.OpenStatistics += ShowDataStatistics;
    }
    private void BeackToPanelSettings()
    {
        _settingPanelView.StatisticsPanelView.gameObject.SetActive(false);
    }
    private void ShowDataStatistics()
    {
        _settingPanelView.StatisticsPanelView.SubtractionTrueText.text = PlayerPrefs.GetInt("SubtractionTrueStatistics").ToString();
        _settingPanelView.StatisticsPanelView.SubtractionFalseText.text =PlayerPrefs.GetInt("SubtractionFalseStatistics").ToString();
        _settingPanelView.StatisticsPanelView.AdditionTrueText.text =PlayerPrefs.GetInt("AdditionTrueStatistics").ToString();
        _settingPanelView.StatisticsPanelView.AdditionFalseText.text =PlayerPrefs.GetInt("AdditionFalseStatistics").ToString();
        _settingPanelView.StatisticsPanelView.MultiplicationTrueText.text =PlayerPrefs.GetInt("MultiplicationTrueStatistics").ToString();
        _settingPanelView.StatisticsPanelView.MultiplicationFalseText.text =PlayerPrefs.GetInt("MultiplicationFalseStatistics").ToString();
        _settingPanelView.StatisticsPanelView.DivisionTrueText.text =PlayerPrefs.GetInt("DivisionTrueStatistics").ToString();
        _settingPanelView.StatisticsPanelView.DivisionFalseText.text = PlayerPrefs.GetInt("DivisionFalseStatistics").ToString();
    }
    private void ResetStatistics() 
    {
        PlayerPrefs.SetInt("SubtractionTrueStatistics", 0);
        PlayerPrefs.SetInt("SubtractionFalseStatistics", 0);
        PlayerPrefs.SetInt("AdditionTrueStatistics", 0);
        PlayerPrefs.SetInt("AdditionFalseStatistics", 0);
        PlayerPrefs.SetInt("MultiplicationTrueStatistics", 0);
        PlayerPrefs.SetInt("MultiplicationFalseStatistics", 0);
        PlayerPrefs.SetInt("DivisionTrueStatistics", 0);
        PlayerPrefs.SetInt("DivisionFalseStatistics", 0);
        ShowDataStatistics();
    }
}
