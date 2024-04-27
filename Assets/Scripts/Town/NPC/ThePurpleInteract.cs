using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faded.Town
{
    public class ThePurpleInteract : NPCInteractable
    {

        [SerializeField] private GameObject emoji;
        [SerializeField] private Animator animator;

        private ThePurpleController controller;
        private Rigidbody rb;

        public void Start()
        {
            emoji.SetActive(false);
            animator = GetComponent<Animator>();
            controller = GetComponent<ThePurpleController>();
            controller.enabled = false;
            rb = GetComponent<Rigidbody>();
        }

        public override void OnInteract()
        {
            base.OnInteract();
            
            emoji.SetActive(true);
            emoji.GetComponent<Animator>().Play("play");
            animator.Play("left_idle");
            StartCoroutine(StartTask());
        }

        private IEnumerator StartTask()
        {

            while (!flowchart.GetBooleanVariable("endFirstTalkWithPurple"))
            {
                yield return null;
            }
            emoji.SetActive(false);
            controller.enabled = true;

            TaskManager.Instance.TalkWith(this);
            yield break;
        }
    }

}
