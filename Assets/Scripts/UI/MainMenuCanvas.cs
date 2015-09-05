using UnityEngine;
using System.Collections;

public class MainMenuCanvas : MonoBehaviour 
{
    public void OnStartButton()
    {
        Resolver.Instance.GetController<GameStateEngine>().ChangeGameState(GameStateEngine.States.Playing);
    }

    public void OnTerrainGeneratorButton()
    {
        Resolver.Instance.GetController<GameStateEngine>().ChangeGameState(GameStateEngine.States.TerrainGenerator);
    }
}
