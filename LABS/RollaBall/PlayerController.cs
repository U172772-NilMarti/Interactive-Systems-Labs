using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;






public class PlayerController : MonoBehaviour
{

    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject WinTextObject;
    public AudioClip pickupSound;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinTextObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();

    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;   
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 16 ) 
        {
            WinTextObject.SetActive(true);

        }
    }
        




    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);


        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            audioSource.PlayOneShot(pickupSound);


        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
