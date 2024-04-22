using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faded.Town
{
    public class ThePurpleInteract : NPCInteractable
    {

        [SerializeField] private GameObject emoji;

        public void Start()
        {
            emoji.SetActive(false);
        }

        public override void OnInteract()
        {
            base.OnInteract();
            emoji.SetActive(true);
            emoji.GetComponent<Animator>().Play("play");
            StartCoroutine(StartTask());
        }

        private IEnumerator StartTask()
        {

            while (!flowchart.GetBooleanVariable("endFirstTalkWithPurple"))
            {
                yield return null;
            }
            emoji.SetActive(false);
            TaskManager.Instance.TalkWith(this);
            yield break;
        }
    }

}
