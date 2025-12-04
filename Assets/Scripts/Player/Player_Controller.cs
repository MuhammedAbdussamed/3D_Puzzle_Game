using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Controller : MonoBehaviour
{
    // Scripts
    internal GameManager gameManager;

    // Variables
    internal Vector2 moveDirection;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        // Transitions
        EnterWalkState();

        // Assign 
        moveDirection = gameManager.inputManager.moveAxis;

        gameManager.playerData.currentState.UpdateState(gameManager);
    }

    #region Transitions

    void EnterWalkState()
    {
        if (moveDirection.x != 0f || moveDirection.y != 0f)
        {
            gameManager.playerData.isWalking = true;
        }
        else
        {
            gameManager.playerData.isWalking = false;
        }
    }

    /*--------------------------------------------*/

    public void ChangeState(IState newState)
    {
        gameManager.playerData.currentState.ExitState(gameManager);
        gameManager.playerData.currentState = newState;
        gameManager.playerData.currentState.EnterState(gameManager);
    }

    #endregion
}
