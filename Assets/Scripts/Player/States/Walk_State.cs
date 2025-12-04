using UnityEngine;
using UnityEngine.EventSystems;

public class Walk_State : IState
{
    private WalkDirection walkDirection;

    public void EnterState(GameManager gameManager)
    {
        
    }

    public void ExitState(GameManager gameManager)
    {
        ResetAnimations(gameManager);
    }

    public void UpdateState(GameManager gameManager)
    {
        SetWalkDirection(gameManager);
        SetWalkAnimations(gameManager);
        Walk(gameManager);
        
        if (!gameManager.playerData.isWalking)
        {
            gameManager.playerController.ChangeState(gameManager.playerData.idleState);
        }
    }

    void Walk(GameManager gameManager)
    {
        Vector3 input = new Vector3 (
            gameManager.playerController.moveDirection.x,
            0f,
            gameManager.playerController.moveDirection.y
        );

        Vector3 moveDir = gameManager.playerController.transform.TransformDirection(input);

        gameManager.playerData.rb.linearVelocity = moveDir * gameManager.playerData.speed;
    }

    /*-------------------------------------------------------*/

    void SetWalkDirection(GameManager gameManager)
    {
        Vector2 moveDirection = gameManager.playerController.moveDirection;     

        if (moveDirection.y > 0f && moveDirection.x == 0f)  // İleri kuvvet varsa ve sağa sola kuvvet yoksa
        {
            walkDirection = WalkDirection.Forward;
        }
        else if (moveDirection.y < 0f && moveDirection.x == 0f)  // Geriye kuvvet varsa ve sağa sola kuvvet yoksa
        {
            walkDirection = WalkDirection.Backward;
        }
        else if (moveDirection.x > 0f && moveDirection.y == 0f)  // Sağa kuvvet varsa ve ileri - geri kuvvet yoksa
        {
            walkDirection = WalkDirection.Right;
        }
        else if (moveDirection.x < 0f && moveDirection.y == 0f)  // Sola kuvvet varsa ve ileri - geri kuvvet yoksa
        {
            walkDirection = WalkDirection.Left;
        }
        else if (moveDirection.y > 0f && moveDirection.x > 0f)   // İleri ve sağa kuvvet varsa
        {
            walkDirection = WalkDirection.Forward_Right;
        }
        else if (moveDirection.y > 0f && moveDirection.x < 0f)   // İleri ve sola kuvvet varsa
        {
            walkDirection = WalkDirection.Forward_Left;
        }
        else if (moveDirection.y < 0f && moveDirection.x > 0f)   // Geri ve sağa kuvvet varsa
        {
            walkDirection = WalkDirection.Backward_Right;
        }
        else if (moveDirection.y < 0f && moveDirection.x < 0f)   // Geri ve sola kuvvet varsa
        {
            walkDirection = WalkDirection.Backward_Left;
        }
    }

    /*-------------------------------------------------------*/

    void SetWalkAnimations(GameManager gameManager)
    {
        
        switch (walkDirection)
        {
            case WalkDirection.Forward:
                ResetAnimations(gameManager);
                gameManager.playerData.animator.SetBool("Walk_Forward",true);
                break;

            case WalkDirection.Backward:
                ResetAnimations(gameManager);
                gameManager.playerData.animator.SetBool("Walk_Backward",true);
                break;

            case WalkDirection.Right:
                ResetAnimations(gameManager);
                gameManager.playerData.animator.SetBool("Walk_Right",true);
                break;

            case WalkDirection.Left:
                ResetAnimations(gameManager);
                gameManager.playerData.animator.SetBool("Walk_Left",true);
                break;

            case WalkDirection.Forward_Right:
                ResetAnimations(gameManager);
                gameManager.playerData.animator.SetBool("Walk_Forward_Right",true);
                break;

            case WalkDirection.Forward_Left:
                ResetAnimations(gameManager);
                gameManager.playerData.animator.SetBool("Walk_Forward_Left",true);
                break;

            case WalkDirection.Backward_Right:
                ResetAnimations(gameManager);
                gameManager.playerData.animator.SetBool("Walk_Backward_Right",true);
                break;

            case WalkDirection.Backward_Left:
                ResetAnimations(gameManager);
                gameManager.playerData.animator.SetBool("Walk_Backward_Left",true);
                break;
        }
    }

    /*-------------------------------------------------------*/

    void ResetAnimations(GameManager gameManager)
    {
        gameManager.playerData.animator.SetBool("Walk_Forward",false);
        gameManager.playerData.animator.SetBool("Walk_Backward",false);
        gameManager.playerData.animator.SetBool("Walk_Right",false);
        gameManager.playerData.animator.SetBool("Walk_Left",false);
        gameManager.playerData.animator.SetBool("Walk_Forward_Right",false);
        gameManager.playerData.animator.SetBool("Walk_Forward_Left",false);
        gameManager.playerData.animator.SetBool("Walk_Backward_Right",false);
        gameManager.playerData.animator.SetBool("Walk_Backward_Left",false);
    }

    /*-------------------------------------------------------*/

    public enum WalkDirection
    {
        Forward,
        Backward,
        Right,
        Left,
        Forward_Right,
        Forward_Left,
        Backward_Right,
        Backward_Left
    }

}
