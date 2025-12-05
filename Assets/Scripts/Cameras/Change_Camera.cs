using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Change_Camera : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private CinemachineCamera camDefault;

    // Script
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    void OnTriggerEnter(Collider col)
    {
        StartCoroutine(ChangeCamera(col,true));
    }
    
    void OnTriggerExit(Collider col)
    {
        StartCoroutine(ChangeCamera(col,false));
    }

    #region Functions

    IEnumerator ChangeCamera(Collider col,bool isIn)
    {
        if (col.CompareTag("Player"))
        {
            if (isIn)
            {
                gameManager.inputManager.movementActionMap.Disable();
                camDefault.Priority = 1;
                yield return new WaitForSeconds(2f);
                gameManager.inputManager.movementActionMap.Enable();
            }
            else
            {
                gameManager.inputManager.movementActionMap.Disable();
                camDefault.Priority = 5;
                yield return new WaitForSeconds(2f);
                gameManager.inputManager.movementActionMap.Enable();
            }
            
        }
    }

    /*--------------------------------------*/

    #endregion
}
