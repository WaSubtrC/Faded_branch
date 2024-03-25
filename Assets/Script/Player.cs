using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("ÒÆ¶¯")]
    private float xInput;
    private float yInput;
    [SerializeField] private float moveSpeed;
    [Header("·½Ïò")]
    [SerializeField] int facingDir = 1;
    //[SerializeField] private bool facingRight;


    private Rigidbody rb;
    //private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(xInput, rb.velocity.y, yInput).normalized * moveSpeed;
        if (rb != null)
        {
            rb.velocity = new Vector3(dir.x, rb.velocity.y, dir.z);

        }
        if (rb.velocity.x > 0 && facingDir == -1 )
        { Flip();}
        else if (rb.velocity.x < 0 && facingDir ==1)
        { Flip(); }
    
    }

    private void Flip()
        {
        facingDir *= -1;
        // facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
         }
    }   