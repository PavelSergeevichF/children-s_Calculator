using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SettingPanelView : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text LocalScoreText;
    public TMP_Text ShowNum;

    public Button BeackButton;
    public Button ResetButton;
    public Button StatisticsButton;
    public Button BeackNumButton;
    public Button NextNumButton;
    public Button ExitButton;

    public Toggle SubtractionToggle;
    public Toggle AdditionToggle;
    public Toggle MultiplicationToggle;
    public Toggle DivisionToggle;

    public GameObject SettingPanel;
    public StatisticsPanelView StatisticsPanelView;

    public delegate void OpenPanelStatistics();
    public event OpenPanelStatistics OpenStatistics;

    public void OpenStatisticsInvoke() => OpenStatistics?.Invoke();
}
