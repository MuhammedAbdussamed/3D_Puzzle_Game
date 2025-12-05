using UnityEngine;

public abstract class Interactable_Objects : MonoBehaviour
{
    [Header("Mini-Game Canvas")] 
    [SerializeField] protected Canvas minigameCanvas;

    // Scripts
    protected GameManager gameManager;

    // Bools
    protected bool isPlayerIn;
    protected bool isMinigameOpen;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    void OnTriggerEnter(Collider col)
    {
        DetectPlayer(col,true);
    }

    void OnTriggerStay()
    {

        Open_CloseMiniGame();

    }

    void OnTriggerExit(Collider col)
    {
        DetectPlayer(col,false);
    }

    #region Functions

    void DetectPlayer(Collider col, bool isIn)
    {
        if (col.CompareTag("Player"))                                         
        {                                                                   // Karakterin içerde olup olmamasina
            isPlayerIn = isIn;                                              // göre değişkeni true ya da
            gameManager.playerData.inInteractArea = isPlayerIn;             // false döndür.
        }
    }

    /*---------------------------------------*/

    void Open_CloseMiniGame()
    {
        if(!isMinigameOpen)                                                 // Mini game açık değilse...
        {
            if (isPlayerIn && gameManager.inputManager.isInteractPressed)   // Karakter içeride ve etkileşim tuşuna basildiysa...
            {
                minigameCanvas.gameObject.SetActive(true);                  // Mini game'i aktive et.
                isMinigameOpen = true;
            }
        }

        else                                                                // Mini game açik ise...
        {
            if (gameManager.inputManager.isInteractPressed)                 // Etkileşim tuşuna basilmişsa...
            {
                minigameCanvas.gameObject.SetActive(false);                 // Minigame'i kapat
                isMinigameOpen = false;                 
            }
        }
    }

    #endregion
}
