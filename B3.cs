using UnityEngine;

public class B3 : MonoBehaviour
{
    public float Speed = 5f; // Speed of movement
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Game Started");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.forward; // Move forward
        }
        transform.Translate(moveDirection * Speed * Time.deltaTime);

    }
}
// Cinemachine