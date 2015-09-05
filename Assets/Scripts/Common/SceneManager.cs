using UnityEngine;
using System.Collections;

class SceneManager : MonoBehaviour, IController
{
    void Awake()
    {
        Resolver.Instance.GetController<EventHandler>().Register(Events.GameStateTransition.TransitionTo, OnTransitionToState);

        //no matter what scene we start in, we want to begin with the null state
        Resolver.Instance.GetController<GameStateEngine>().ChangeGameState(GameStateEngine.States.NullState);
    }

    void OnTransitionToState(int id, object param)
    {
        GameStateEngine.States newState = (GameStateEngine.States)param;

        switch (newState)
        {
            case GameStateEngine.States.NullState:
                Application.LoadLevel("EmptyStartScene");
                break;
            case GameStateEngine.States.MainMenu:
                Application.LoadLevel("MainMenu");
                break;
            case GameStateEngine.States.Playing:
                Application.LoadLevel("Game");
                break;
            case GameStateEngine.States.TerrainGenerator:
                Application.LoadLevel("TerrainGenerator");
                break;
            case GameStateEngine.States.GameOver:
                Application.LoadLevel("MainMenu");
                break;
            case GameStateEngine.States.Credits:
                break;
            case GameStateEngine.States.Settings:
                Application.LoadLevel("Settings");
                break;
            default:
                Debug.LogError("Invalid state transition");
                break;
        }
    }

    #region IController

    public void Cleanup()
    {

    }

    #endregion IController


}