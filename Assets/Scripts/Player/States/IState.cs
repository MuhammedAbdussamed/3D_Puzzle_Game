using Unity.VisualScripting;
using UnityEngine;

public interface IState
{
    void EnterState(GameManager gameManager){}

    void ExitState(GameManager gameManager){}

    void UpdateState(GameManager gameManager){}

}
