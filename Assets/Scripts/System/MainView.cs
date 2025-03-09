using System;
using UnityEngine;

public class MainView: MonoBehaviour
{
    [SerializeField] private MainPanelView _mainPanelView;
    [SerializeField] private SettingPanelView _settingPanelView;
    [SerializeField] private SOData _sOData;

    private MainControllers _mainControllers;

    public MainPanelView MainPanelView => _mainPanelView;
    public SettingPanelView SettingPanelView => _settingPanelView;
    public SOData SOData => _sOData;



    public void SetPlaerDead()
    {
    }
    public void SetEndLevel()
    {
    }

    #region System

    private void Awake()
    {
        _mainControllers = new MainControllers();
        new GameControllerInit(_mainControllers, this);

        _mainControllers.Awake();
    }

    private void Start() => _mainControllers.Init();

    private void Update()=> _mainControllers.Execute();

    private void FixedUpdate()
    {
    }

    private void LateUpdate() => _mainControllers.LateExecute();

    private void OnDestroy() => _mainControllers.Cleanup();
    #endregion
}
