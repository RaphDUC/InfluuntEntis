using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class TopDownPlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float rollSpeed = 10f;
    [SerializeField] private float rollDuration = 0.5f;
    [SerializeField] private float interactionRadius = 1f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private AudibleSphere audibleSphere;
    [SerializeField] private Character character;

    [SerializeField] private float smoothTime = 0.05f;
    private float _currentVelocity;

    public CharacterController characterController;
    private Animator animator;

    private Vector2 movementInput;
    private bool isSprinting;
    private bool isRolling;
    private bool isPaused;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        audibleSphere = GetComponent<AudibleSphere>();
        sprintSpeed = movementSpeed * 2;
    }

    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    private void OnSprint(InputValue value)
    {
        isSprinting = value.isPressed;
        audibleSphere.radius *= 2f;
    }

    private void OnRoll(InputValue value)
    {
        if (value.isPressed && !isRolling)
        {
            StartCoroutine(Roll());
        }
    }

    private void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            Collider[] nearbyInteractables = Physics.OverlapSphere(transform.position, interactionRadius, interactableLayer);

            if (nearbyInteractables.Length > 0)
            {
                Interactable interactable = nearbyInteractables[0].GetComponent<Interactable>();

                if (interactable != null)
                {
                    interactable.Interact(character);
                }
            }
        }
    }

    private void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            TogglePauseMenu();
        }
    }

    private void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Attack !");

        }
    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y).normalized;

            if (movement.magnitude > 0f && !isRolling)

            {
                if (movementInput != Vector2.zero)
                {
                    var targetAngle = Mathf.Atan2(movement.normalized.x, movement.normalized.z) * Mathf.Rad2Deg;
                    var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
                    animator.transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

                    // rotate to face input direction relative to camera position
                    //transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
                }

                movement = transform.right * movementInput.x + transform.forward * movementInput.y;
                characterController.Move(movement.normalized * ((isSprinting ? sprintSpeed : movementSpeed) * Time.deltaTime));


               

            }

            animator.SetFloat("MoveSpeed", movement.magnitude);
        }
    }

    private IEnumerator Roll()
    {
        isRolling = true;
        characterController.Move(transform.forward * rollSpeed);
        animator.SetTrigger("Roll");

        yield return new WaitForSeconds(rollDuration);

        isRolling = false;
    }


    private void TogglePauseMenu()
    {
        isPaused = !isPaused;
        Debug.Log("Paused");
        // Show/hide pause menu UI here
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}

