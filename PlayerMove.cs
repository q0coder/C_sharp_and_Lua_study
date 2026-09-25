using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 30f;
     public Rigidbody2D rb;

    public Animator animator;
    public Canvas canvas;

    public TextMeshProUGUI PromptText;
    
    private bool isEnd=false;

    

    private int facingDirection = 1; // 1 for right, -1 for left

    public SimpleTypewriter simpleTypewriter;
    void Start()
    {
        moveSpeed=0f;
        canvas.gameObject.SetActive(true);
        simpleTypewriter.Play(PromptText.text,PromptEnd);
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetMouseButtonDown(0)&&isEnd)
        {
        canvas.gameObject.SetActive(false);
        moveSpeed=30f;
        isEnd=false;
            
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if(moveX>0&&transform.localScale.x<0||moveX<0&&transform.localScale.x>0)
        {
            Flip();
        }
     
       
        animator.SetFloat("Horizontal", Mathf.Abs(moveX));
        animator.SetFloat("Vertical", Mathf.Abs(moveY));

        rb.linearVelocity = new Vector2(moveX, moveY) * moveSpeed;


        
    }
    void Flip()
        {
            facingDirection *= -1;
           transform.localScale = new Vector3(facingDirection, 1, 1);
        }

       private void PromptEnd()
    {
        isEnd=true;
        
    }
}
