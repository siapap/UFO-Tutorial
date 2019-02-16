using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    //do we need a speed variable
    public float speed;

    public Text countText;
    public Text winText;

    private int count;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        count = 0;
        SetCountText();

        winText.text = " ";
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if(count >= 8)
        {
            winText.text = "You Win!!";
        }
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
