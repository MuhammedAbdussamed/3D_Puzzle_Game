using Unity.Cinemachine;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform player;

    // Script
    private GameManager gameManager;

    // Variables
    [SerializeField] private float sensitivity;
    private float yaw;
    private float pitch;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        TurnCamera();
    }

    #region Functions

    void TurnCamera()
    {
        float mouseY = gameManager.inputManager.turnDirection.y * sensitivity * Time.deltaTime;     // Mouseun Y ekseni girdisi
        float mouseX = gameManager.inputManager.turnDirection.x * sensitivity * Time.deltaTime;     // Mouseun X ekseni girdisi

        yaw += mouseX;                                                                              // Sağa - sol değerini tutan değişken
        pitch -= mouseY;                                                                            // Yukari - aşaği değerini tutan değişken
        pitch = Mathf.Clamp(pitch,-80f,80f);                                                        // Fazla yukari ya da aşaği bakma

        transform.rotation = Quaternion.Euler(pitch,yaw,0f);                                        // Kameranin rotasyonunu döndür
        player.rotation = Quaternion.Euler(0f,yaw,0f);                                              // Player'i sağa sola çevir
    }

    #endregion
}
