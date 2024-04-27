using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Faded.Town{
    enum Direction { FORWARD, LEFT, BACK, RIGHT }

    public class PlayerController : Singleton<PlayerController>
    {

        private Animator animator;
        private CharacterController controller;

        [Header("Move")]
        [SerializeField] float speed;
        [SerializeField] float gravity;
        private Direction currDir = Direction.FORWARD;

        [Header("Light")]
        [SerializeField] private Transform VFX;
        public float targetAngle;
        private bool isFlashlightOn = true;

        [Header("OnGround")]
        private bool isMoving = false;
        private bool isOnWater = false;
        [SerializeField] private LayerMask waterMask;
        //[SerializeField] private ParticleSystem splash;

        [Header("Undersea")]
        [SerializeField] private Vector3 freshpoint = new Vector3(6.5f, 3f, 16f);
        [SerializeField] private float bottomline = -4f;


        protected override void Awake()
        {
            base.Awake();
            animator = GetComponent<Animator>();
            controller = GetComponent<CharacterController>();
        }

        void Start()
        {

            //StartCoroutine(CheckOnGround());
        }

        void Update()
        {
            OnMove();
            OnFlashlight();
        }

        private void FixedUpdate()
        {

        }

        IEnumerator CheckOnGround()
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, Vector3.down, out hit, waterMask);
            if (hit.transform.CompareTag("Water"))
                isOnWater = true;
            else
                isOnWater = false;
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(CheckOnGround());

        }

        private void OnMove()
        {
            float x_offset = Input.GetAxisRaw("Horizontal");
            float y_offset = Input.GetAxisRaw("Vertical");

            //Update Position
            Vector3 moveVec = new Vector3(x_offset * speed * Time.deltaTime, 0f, y_offset * speed * Time.deltaTime);
            
            if (!controller.isGrounded) moveVec += Vector3.down * speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftShift)) moveVec *= 1.5f;

            controller.Move(moveVec);

            //Update Animations
            if (Input.GetKeyDown(KeyCode.W))
            {
                animator.Play("back_run");
                currDir = Direction.BACK;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                animator.Play("left_run");
                currDir = Direction.LEFT;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                animator.Play("forward_run");
                currDir = Direction.FORWARD;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                animator.Play("right_run");
                currDir = Direction.RIGHT;
            }
            else
            {

            }


            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                switch (currDir)
                {
                    case Direction.BACK:
                        animator.Play("back_idle");
                        break;
                    case Direction.FORWARD:
                        animator.Play("forward_idle");
                        break;
                    case Direction.LEFT:
                        animator.Play("left_idle");
                        break;
                    case Direction.RIGHT:
                        animator.Play("right_idle");
                        break;
                }
                isMoving = false;
            }
            else
            {
                isMoving = true;
            }

            //Update VFX
            targetAngle = (int)currDir * 90f;
            float currAngle = VFX.eulerAngles.y;
            if (currAngle != targetAngle)
            {
                float newAngle = Mathf.LerpAngle(currAngle, targetAngle, 15 * Time.deltaTime);
                VFX.eulerAngles = new Vector3(transform.eulerAngles.x, newAngle, transform.eulerAngles.z);
            }

            /*
            if (isOnWater && isMoving)
            {
                if(!splash.isPlaying)
                    splash.Play();
            }

            else
                splash.Stop();
            */

            //Teleport to refresh point if falling into sea
            if (transform.position.y < bottomline)
                transform.position = freshpoint;

        }

        private void OnFlashlight()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isFlashlightOn = !isFlashlightOn;
                VFX.Find("Light").gameObject.SetActive(isFlashlightOn);
            }
        }

        public void OnMoveToward(Vector3 target)
        {
            controller.enabled = false;
            this.gameObject.transform.position = target; 
            controller.enabled = true;
        }

    }

}
