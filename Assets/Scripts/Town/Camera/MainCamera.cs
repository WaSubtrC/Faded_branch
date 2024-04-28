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

        private bool isMoving = false;
        [SerializeField] private Transform churchPos;
        
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnTowardInChurch();
            }
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
            transform.eulerAngles = new Vector3(20f, transform.eulerAngles.y, transform.eulerAngles.z);
            while(transform.position != insidePos.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, insidePos.position, speed);
                yield return null;
            }
            isMoving = false; 
        }

        IEnumerator towardOutside()
        {
            transform.eulerAngles = new Vector3(20f, transform.eulerAngles.y, transform.eulerAngles.z);
            while (transform.position != outsidePos.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, outsidePos.position, speed);
                yield return null;
            }
            isMoving = false;
        }

        public void OnTowardInChurch()
        {
            if (!isMoving)
            {
                isMoving = true;
                StartCoroutine(towardInChurch());
            }
        }

        public void OnTowardOutChurch()
        {

            if (!isMoving)
            {
                isMoving = true;
                OnTowardOutside();
            }

        }

        IEnumerator towardInChurch()
        {
            transform.eulerAngles = new Vector3(22f, transform.eulerAngles.y, transform.eulerAngles.z);
            while(transform.position != churchPos.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, churchPos.position, speed);
                yield return null;
            }
            isMoving = false;
        }

    }
}

