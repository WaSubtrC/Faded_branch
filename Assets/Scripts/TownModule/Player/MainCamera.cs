using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Faded.Town
{
    public class MainCamera : Singleton<MainCamera>
    {

        public bool isInside = false;
        [SerializeField] private Transform insidePos;
        [SerializeField] private Transform outsidePos;
        [SerializeField] private float speed = 0.06f;

        protected override void Awake()
        {
            base.Awake(); 

            if (isInside)
                transform.position = insidePos.position;
            else
                transform.position = outsidePos.position;
        }

        public void OnStartNewGame()
        {
            isInside = true;
            transform.position = insidePos.position;
        } 


        void Update()
        {

        }

        public void OnSwitchView()
        {
            isInside = !isInside;
            if (isInside)
                StartCoroutine(towardInside());
            else
                StartCoroutine(towardOutside());
        }
        public void OnTowardInside()
        {
            StartCoroutine(towardInside());
            isInside = true;
        }
        
        public void OnTowardOutside()
        {
            StartCoroutine(towardOutside());
            isInside = false;
        }

        IEnumerator towardInside()
        {
            transform.position = Vector3.MoveTowards(transform.position, insidePos.position, speed);
            yield return null;
            if (transform.position != insidePos.position)
                StartCoroutine(towardInside());

        }

        IEnumerator towardOutside()
        {
            transform.position = Vector3.MoveTowards(transform.position, outsidePos.position, speed);
            yield return null;
            if (transform.position != outsidePos.position)
                StartCoroutine(towardOutside());
        }

    }
}

