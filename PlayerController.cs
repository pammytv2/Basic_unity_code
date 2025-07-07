using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 720f;
    public float jumpSpeed = 8f;
    public float jumpButtonGracePeriod = 0.2f;

    public Transform cameraTransform; // กล้องที่ใช้ในการเคลื่อนที่

    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;

    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // รับค่าอินพุตจากผู้เล่น
        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // แปลงอินพุตให้เคลื่อนที่ตามกล้อง
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // เคลื่อนที่ตามกล้อง
        Vector3 movementDirection = (cameraForward * verticalInput + cameraRight * horizontalInput).normalized;
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        // อัปเดตแอนิเมชัน
        animator.SetFloat("Speed", inputMagnitude * speed);

        // หมุนตัวละครไปในทิศทางที่เคลื่อนที่
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // แรงโน้มถ่วง
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = movementDirection * (inputMagnitude * speed);
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);
    }
}
