using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    private AudioSource audioSource;
    public TextMeshProUGUI TurnBigTextObject;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp") || (other.gameObject.CompareTag("Pineapple")))
        {
            Debug.Log(audioSource);
            if (gameObject.activeSelf)
            {
                other.gameObject.SetActive(false);
                if (other.gameObject.CompareTag("Pineapple"))
                {
                    count += 2;
                }
                else
                {
                    count++;
                }
            }
            SetCountText();
            audioSource.Play();
        }
    }
    void SetCountText()
	{
    	countText.text = "Count: " + count.ToString();
		if (count >= 5)
    	{
        	TurnBigTextObject.text = "You can become large!";
    	}
    	else 	
        TurnBigTextObject.text = "";
	}
}