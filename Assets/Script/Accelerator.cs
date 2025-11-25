using UnityEngine;
using UnityEngine.InputSystem;

public class Accelerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnMove(InputValue value)
    {
        Vector2 TorchDir = value.Get<Vector2>();

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddTorque(new Vector3(TorchDir.y * 10, 0, -TorchDir.x * 10));

        

        Debug.Log("OnMove called");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        

    }
}
