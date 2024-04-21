using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faded.Town{
    public class Door : MonoBehaviour
    {

        private bool isNear = false;

        private float angle = 0f;
        public bool isClosed;

        private Transform doorTrans;

        void Start()
        {
            doorTrans = transform.Find("Door").transform;
            if (!isClosed)
            {
                angle = 75f;
                doorTrans.Rotate(Vector3.down * 75f);
            }
        }

        void Update()
        {
            if (isNear && Input.GetKeyDown(KeyCode.Return))
            {
                OnInteract();
            }
        }

        public void OnInteract()
        {
            if (isClosed)
            {
                StartCoroutine(Open());
            }

            else
                StartCoroutine(Close());
        }

        public void OnEnter()
        {
            if (!MainCamera.instance.isInside) MainCamera.instance.OnSwitchView();
            MainCamera.instance.isInside = true;
        }

        public void OnExit()
        {
            if (MainCamera.instance.isInside) MainCamera.instance.OnSwitchView();
            MainCamera.instance.isInside = false;
        }

        IEnumerator Open()
        {

            if (angle < 75f)
            {
                angle += 0.3f;
                doorTrans.Rotate(Vector3.down * 0.3f);
                yield return null;
                StartCoroutine(Open());
            }
            else
            {
                isClosed = false;
            }
            yield return null;
        }

        IEnumerator Close()
        {
            if (angle > 0)
            {
                angle -= 0.4f;
                doorTrans.Rotate(Vector3.up * 0.4f);
                yield return null;
                StartCoroutine(Close());
            }
            else
            {
                isClosed = true;
            }
            yield return null;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isNear = true;
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isNear = false;
            }
        }


    }
}

