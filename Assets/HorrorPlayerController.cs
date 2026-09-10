using UnityEngine;

public class HorrorPlayerController : MonoBehaviour
{
    [Header("Камера гравця")]
    public Transform playerCamera;

    [Header("Настройки движения")]
    public float walkSpeed = 3.5f;
    public float runSpeed = 7f;
    public float mouseSensitivity = 2f;

    [Header("Выносливость (Стамина)")]
    public float maxStamina = 5f;
    private float currentStamina;
    private bool isExhausted = false;

    private CharacterController controller;
    private float verticalRotation = 0f;

    // Нова змінна для коректної вертикальної швидкості (гравітації)
    private float verticalVelocity = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentStamina = maxStamina;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // Приховуємо курсор на старті гри
    }

    void Update()
    {
        if (playerCamera == null) return;

        // 1. Поворот миші
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -85f, 85f);
        playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // 2. Логіка СТАМІНИ
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        bool isRunning = Input.GetKey(KeyCode.LeftShift) && v > 0 && !isExhausted;
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        if (isRunning)
        {
            currentStamina -= Time.deltaTime;
            if (currentStamina <= 0) isExhausted = true;
        }
        else
        {
            currentStamina += Time.deltaTime * 0.5f;
            if (currentStamina >= maxStamina) isExhausted = false;
        }
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);

       
        Vector3 move = transform.forward * v + transform.right * h;
      
        if (move.magnitude > 1f) move.Normalize();

        Vector3 finalVelocity = move * currentSpeed;

       
        if (controller.isGrounded)
        {
         
            verticalVelocity = -2f;
        }
        else
        {
            
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        
        finalVelocity.y = verticalVelocity;

       
        controller.Move(finalVelocity * Time.deltaTime);
    }
}
