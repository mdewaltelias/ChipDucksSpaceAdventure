using UnityEngine;

public class P1Controller : MonoBehaviour
{
    float move = 0;
    bool jump = false;

    Rigidbody2D rb;

    Transform feet;
    Vector2 feetBox;
    LayerMask groundMask;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        feet = transform.Find("Feet");
        feetBox = new Vector2(0.8f, 0.2f);
        groundMask = LayerMask.GetMask("ground");

        var yellow = LayerMask.NameToLayer("yellow");
        Physics2D.IgnoreLayerCollision(yellow, yellow); 


    }

    // Update is called once per frame
    void Update()

    {

        var grounded = Physics2D.OverlapBox(feet.position, feetBox, 0, groundMask);

        move = 0;
        if (Input.GetKey(KeyCode.A)) move = -1;
        if (Input.GetKey(KeyCode.D)) move = 1;
        if (Input.GetKeyDown(KeyCode.W) &&grounded) {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocityX = move * 4;
        
        if (jump)
        {
            jump = false;
            rb.AddForce(transform.up * 6, ForceMode2D.Impulse); 
        }
    }
}
