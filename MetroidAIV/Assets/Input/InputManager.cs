using UnityEngine.InputSystem;
using UnityEngine;

public static class InputManager
{

    private static Inputs input;

    static InputManager () {
        input = new Inputs();
    }


    public static InputActionMap PlayerMap {
        get {
            return input.Player;
        }
    }

    public static float Player_Horizontal {
        get {
            return input.Player.Horizontal.ReadValue<float>();
        }
    }

    public static InputAction PlayerJumpAction {
        get {
            return input.Player.Jump;
        }
    }

    public static InputAction PlayerDashAction {
        get {
            return input.Player.Dash;
        }
    }
}
