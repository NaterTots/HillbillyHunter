using UnityEngine;
using System.Collections;

/// <summary>
/// For this game, the InputController will just be a wrapper of the Unity InputManager
/// </summary>
public class InputController : IController
{
	
    public enum Axis
    {
        Horizontal,
        Vertical
    }

    public float GetAxis(Axis a)
    {
        switch (a)
        { 
            case Axis.Horizontal:
                return Input.GetAxis("Horizontal");
            case Axis.Vertical:
                return Input.GetAxis("Vertical");
            default:
                return 0.0f;
        }
    }

    public bool GetPausePressed()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    public void Cleanup()
    {

    }
}
