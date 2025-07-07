using UnityEngine;
using Debug = UnityEngine.Debug;

public class B1 : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(0, 0, 0); 
        Debug.Log("Player position set to (0, 0, 0)"); 
    }

}