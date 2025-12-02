using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Accelerator2 : MonoBehaviour
{
    Vector2 TorchDir;
    public float TorchRatio = 0.1f;
    float JumpForce = 0;
    public float JumpRatio = 1f;
    int score = 0;

    public TextMeshProUGUI textMeshPro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMeshPro.text = "0";
    }

    public void OnMove(InputValue value)
    {
        TorchDir = value.Get<Vector2>() * TorchRatio;

        Debug.Log("OnMove Event : " + TorchDir);
    }

    public void OnJump(InputValue value)
    {
        JumpForce = value.Get<float>() * JumpRatio;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(new Vector3(0, JumpForce, 0));
        Debug.Log("OnJump Event : " + JumpForce);
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("wall_spike"))
    //    {
    //        Debug.Log("Player get hit spike damage");
    //        Debug.Log(collision.gameObject);
    //    }
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item_Coin")
        {
            score++;
            Debug.Log("Player get Coin." + score);
            textMeshPro.text = score.ToString();
            other.transform.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddTorque(new Vector3(TorchDir.y * 10, 0, -TorchDir.x * 10));
        

    }

    private void Update()
    {
       
    }
}
