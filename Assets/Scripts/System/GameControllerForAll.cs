using UnityEngine;

public class GameControllerForAll : IExecute, IInitialization, ILateExecute, ICleanup, IFixedExecute, IAwake
{
    //private TurretsView _turretsView;

    public GameControllerForAll(MainView mainController)
    {
        //_turretsView = mainController.TurretsView;
    }

    public void Awake()
    {
    }

    public void Cleanup()
    {
    }

    public void Execute()
    {
        //foreach (var spawnPointTurret in _turretsView.SpawnsPointsTurretsView)
        //{
        //    spawnPointTurret.Execute();
       // }
    }

    public void FixedExecute()
    {
    }

    public void Init()
    {
       // foreach (var spawnPointTurret in _turretsView.SpawnsPointsTurretsView)
       // {
       //     spawnPointTurret.Init();
       // }
    }

    public void LateExecute()
    {
    }
}
