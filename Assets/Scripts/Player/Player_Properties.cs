using UnityEngine;

public class Player_Properties : MonoBehaviour
{
    [Header("Character Properties")]
    [SerializeField] internal float speed;

    // Components
    internal Rigidbody rb;
    internal Animator animator;

    // Bools
    internal bool isWalking;
    internal bool inInteractArea;

    // States
    internal IState idleState;
    internal IState walkState;
    internal IState currentState;

    void Start()
    {
        // States
        idleState = new Idle_State();
        walkState = new Walk_State();
        currentState = idleState;

        // Components
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

}
