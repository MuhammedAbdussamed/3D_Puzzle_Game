using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Input Reference")]
    [SerializeField] internal InputActionAsset inputs;

    // Action Maps
    internal InputActionMap movementActionMap;
    internal InputActionMap interactionActionMap;
    internal InputActionMap cameraActionMap;

    // Actions
    internal InputAction move;
    internal InputAction interaction;
    internal InputAction cameraTurn;

    // Variables
    internal Vector2 moveAxis;              // Hareket yönü
    internal Vector2 turnDirection;         // Kamera dönüş yönü
    internal bool isInteractPressed;        // Etkileşim tuşuna basildi mi?

    void Start()
    {
        AssignInputsMaps();
    }

    void Update()
    {
        SetInputs();
    }

    #region Functions

    void AssignInputsMaps()
    {
        
        movementActionMap = inputs.FindActionMap("Movement");           //
        interactionActionMap = inputs.FindActionMap("Interaction");     //  Action Map atamalari
        cameraActionMap = inputs.FindActionMap("Camera");               //

        move = movementActionMap.FindAction("Move");                    //
        interaction = interactionActionMap.FindAction("Interaction");   //  Action atamalari
        cameraTurn = cameraActionMap.FindAction("Turn");                // 

        movementActionMap.Enable();
        cameraActionMap.Enable();
    }

    /*--------------------------------------------------------------*/

    void SetInputs()
    {
        moveAxis = move.ReadValue<Vector2>();                           // W-A-S-D yön girdisi (0, 0)
        isInteractPressed = interaction.triggered;                      // Etkileşim tuşu girdisi
        turnDirection = cameraTurn.ReadValue<Vector2>();                // Kamera dönüşü için mouse girdisi
    }

    #endregion
}
