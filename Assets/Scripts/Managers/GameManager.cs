using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Script References")]
    [SerializeField] internal Player_Properties playerData;
    [SerializeField] internal Player_Controller playerController;
    [SerializeField] internal InputManager inputManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   // Fareyi kilitle ve gizle
    }

}
