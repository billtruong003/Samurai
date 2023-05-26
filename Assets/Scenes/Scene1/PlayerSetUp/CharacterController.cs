using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace scene1
{
    public class CharacterController : MonoBehaviour
    {
        float horizontal;
        int Hmove;
        Rigidbody2D rb;
        Animator ani;
        [SerializeField] UI_Controller UI_Controll;
        [SerializeField] float Char_speed;
        [SerializeField] float Char_wspeed;
        [SerializeField] float Char_rspeed;
        [SerializeField] float Char_jumpForce;
        [SerializeField] bool isGrounded;
        [SerializeField] GroundCheck footBox;
        [SerializeField] int jumpStep;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
            flipH(-1);
        }

        // Update is called once per frame
        void Update()
        {
            isGrounded = footBox.CheckGround;
            checkRun(Char_wspeed, Char_rspeed);
            hMovement(Char_speed);
            UI_Movement(Char_speed);
            JumpControll(Char_jumpForce);
            animationPlay();
        }
        private void FixedUpdate()
        {
            if (isGrounded)
            {
                jumpStep = 1;
            }
        }
        void JumpControll(float jumpForce)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded)
            {
                if (jumpStep < 2)
                {
                    jumpStep++;
                    ani.Play("DoubleJ");
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }
        }
        public void JumpUI()
        {
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * Char_jumpForce, ForceMode2D.Impulse);
            }
            else if (!isGrounded)
            {
                if (jumpStep < 2)
                {
                    jumpStep++;
                    ani.Play("DoubleJ");
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * Char_jumpForce, ForceMode2D.Impulse);
                }
            }
        }

        // Horizontal Movement
        void hMovement(float moveSpeed)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
            if (horizontal > 0)
                flipH(1);
            else if (horizontal < 0)
                flipH(-1);

            //if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    flipH(1);
            //    horizontal = 1;
            //}
            //else if (Input.GetKey(KeyCode.LeftArrow))
            //{
            //    flipH(-1);
            //    horizontal = -1;
            //}
            //else
            //{
            //    horizontal = 0;
            //}
        }
        public void UI_Movement(float moveSpeed)
        {
            rb.velocity = new Vector2(Hmove * moveSpeed, rb.velocity.y);
            if (Input.GetKey(KeyCode.A) || UI_Controll.leftClick)
            {
                Hmove = -1;
                flipH(-1);
            }
            else if (Input.GetKey(KeyCode.D) || UI_Controll.rightClick)
            {
                Hmove = 1;
                flipH(1);
            }
            else
                Hmove = 0;

        }
        // Check Run
        void checkRun(float walkspeed, float runspeed)
        {
            if (Input.GetKey(KeyCode.LeftShift) || UI_Controll.runClick)
            {
                Char_speed = runspeed;
            }
            else Char_speed = walkspeed;
        }
        public void animationPlay()
        {
            ani.SetFloat("Move_speed", Char_speed);
            ani.SetBool("Move", AnimateCheckMove());
            ani.SetBool("isGround", isGrounded);
        }
        // Flip character
        void flipH(int scale)
        {
            Vector3 characterScale = new Vector3(scale, 1, 1);
            transform.localScale = characterScale;
        }
        // AnimationMove Check
        bool AnimateCheckMove()
        {
            bool Moving;
            if (rb.velocity.x != 0)
            {
                Moving = true;
            }
            else
            {
                Moving = false;
            }
            return Moving;
        }
    }
}