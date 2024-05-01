using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Faded.Town {

    [RequireComponent(typeof(Collider))]
    public class SecretContainer : MonoBehaviour
    {
        private GameObject _target;
        [SerializeField] private Material _material;
        private float lifetime;

        private void Awake()
        {
            if (_target == null)
            {
                _target = transform.GetChild(0).gameObject;
#if UNITY_EDITOR
                if (_target == null)
                    Debug.Log("Secret _target no found");
#endif
            }

            _material = _target.GetComponent<SpriteRenderer>().material;
            OnHide();

        }

        public void OnReveal()
        {
            StartCoroutine(OnRevealAnim());
            //wDebug.Log("reveal");
        }

        IEnumerator OnRevealAnim()
        {
            _target.SetActive(true);
            while (lifetime < 1f)
            {
                lifetime += Time.deltaTime;
                _material.SetFloat("_LifeTime", lifetime);
                yield return null;
            }
            lifetime = 1;
            _material.SetFloat("_LifeTime", lifetime);
        }

        public void OnHide()
        {
            StartCoroutine(OnHideAnim());
        }

        IEnumerator OnHideAnim()
        {

            while (lifetime > 0f)
            {
                lifetime -= Time.deltaTime;
                _material.SetFloat("_LifeTime", lifetime);
                yield return null;
            }
            lifetime = 0;
            _material.SetFloat("_LifeTime", lifetime);
            _target.SetActive(false);
        }

    }
}


