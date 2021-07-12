using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    NewControls controls;

    [SerializeField] float playerMoveSpeed = 3.5f;
    [SerializeField] float kartMoveSpeed = 7f;

    [SerializeField] GameObject kartGameObject;
    private Vector2 move;

    private void Awake()
    {
        controls = new NewControls();


        // started
        // performed = act of pressing button or using an input
        // canceled
        controls.Gameplay.Action.performed += ctx => ActionButtonPressed();
        controls.Gameplay.Action.canceled += ctx => ActionButtonReleased();

        controls.Gameplay.ExitOrEscape.performed += ctx => ExitButtonPressed();
        controls.Gameplay.ExitOrEscape.canceled += ctx => ExitButtonReleased();



        // player directional movement, need to know what direction and how far
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        // when player releases gamepad joystick
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

    }

    private void Update()
    {

        if (Player.instance.isInKart)
        {
            Vector3 m = new Vector3(-move.y, 0, move.x) * kartMoveSpeed * Time.deltaTime;
            transform.Translate(m, Space.World);
            kartGameObject.transform.Translate(m, Space.World);
        }
        else
        {
            Vector3 m = new Vector3(-move.y, 0, move.x) * playerMoveSpeed * Time.deltaTime;
            transform.Translate(m, Space.World);
        }
    }

    private void ActionButtonPressed()
    {
        Player.instance.Action();
        Player.instance.ActionRequested = true;
    }

    private void ActionButtonReleased()
    {
        Player.instance.ActionRequested = false;
    }

    private void ExitButtonPressed()
    {
        Player.instance.ExitOrEscapeRequested = true;
    }
    private void ExitButtonReleased()
    {
        Player.instance.ExitOrEscapeRequested = false;
    }



    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
