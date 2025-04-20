using UnityEngine;

public class P2Controller: MonoBehaviour
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



        var blue = LayerMask.NameToLayer("blue");
        Physics2D.IgnoreLayerCollision(blue, blue);



    }

    // Update is called once per frame
    void Update()

    {

        var grounded = Physics2D.OverlapBox(feet.position, feetBox, 0, groundMask);

        move = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) move = -1;
        if (Input.GetKey(KeyCode.RightArrow)) move = 1;
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocityX = move * 3;

        if (jump)
        {
            jump = false;
            rb.AddForce(transform.up * 8, ForceMode2D.Impulse);
        }
    }
}
