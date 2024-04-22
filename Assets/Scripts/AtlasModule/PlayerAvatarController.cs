using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Faded.Atlas 
{
    public class PlayerAvatarController : MonoBehaviour
    {

        private Animator animator;
        [SerializeField] private float speed = 2f;

        void Start()
        {
            animator = GetComponent<Animator>();
        }


        void Update()
        {
            OnMove();
        }

        private void OnMove()
        {
            float x_offset = Input.GetAxisRaw("Horizontal");
            float y_offset = Input.GetAxisRaw("Vertical");

            transform.position += new Vector3(x_offset * speed * Time.deltaTime, y_offset * speed * Time.deltaTime, 0);

            if (Input.GetKeyDown(KeyCode.W))
            {
                animator.Play("back");
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                animator.Play("left");
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                animator.Play("forward");
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                animator.Play("right");
            }


            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                animator.Play("idle");
            }
            else
            {
                AtlasManager.Instance.OnUpdateTravelTime();
            }

        }


    }
}
