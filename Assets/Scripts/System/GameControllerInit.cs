using System.Collections;
using UnityEngine;

public class GameControllerInit
{
    private MainView _mainView;

    public GameControllerInit(MainControllers controllers, MainView mainView)
    {
        controllers.Add(new PanelController(mainView));
    }

}
