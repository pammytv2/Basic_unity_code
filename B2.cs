using UnityEngine;

public class B2 : MonoBehaviour
{
    private Renderer objectRenderer;
    public float moveSpeed = 5f; // Speed of movement

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            objectRenderer.material.color = Color.red;
            Debug.Log("Color changed to red");
        }


    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * 0.1f * moveSpeed);
    }
    void LateUpdate()
    {
        Debug.Log("LateUpdate called after all Update calls");

    }
}
