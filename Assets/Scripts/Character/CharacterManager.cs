using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private InputSystem inputSystem;
    private Vector2 currentMove;

    [SerializeField] private float velocity = 10;

    private void Awake()
    {
        inputSystem = new InputSystem();

        inputSystem.CharacterControls.Move.started += OnMoveInput;
        inputSystem.CharacterControls.Move.canceled += OnMoveInput;
        inputSystem.CharacterControls.Move.performed += OnMoveInput;

        inputSystem.CharacterControls.Fire.started += OnFireInput;
    }

    void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        transform.Translate(currentMove * velocity * Time.deltaTime);
    }

    private void OnMoveInput(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        currentMove = context.ReadValue<Vector2>();
    }

    private void OnFireInput(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }



    private void OnEnable()
    {
        inputSystem.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        inputSystem.CharacterControls.Disable();
    }
}
