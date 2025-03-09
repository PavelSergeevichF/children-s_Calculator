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
    public Button BeackNumButton;
    public Button NextNumButton;
    public Button ExitButton;

    public Toggle SubtractionToggle;
    public Toggle AdditionToggle;
    public Toggle MultiplicationToggle;
    public Toggle DivisionToggle;

    public GameObject SettingPanel;
}
