using UnityEngine;

public class Idle_State : IState
{
    public void EnterState(GameManager gameManager)
    {
        Debug.Log("Idle'a girildi");
    }

    public void ExitState(GameManager gameManager)
    {
        Debug.Log("Idle'dan çikildi");
    }
    
    public void UpdateState(GameManager gameManager)
    {
        if (gameManager.playerData.isWalking)
        {
            gameManager.playerController.ChangeState(gameManager.playerData.walkState);
        }
    }
}
