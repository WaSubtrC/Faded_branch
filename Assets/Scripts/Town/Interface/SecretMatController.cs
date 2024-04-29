using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Faded.Town{
    public class SecretMatController : MonoBehaviour
    {
        [Range(0, 1)]
        public float progress = 0.5f;
        public Material _material;
        public Text progressText;

        private int propertyProgressID;

        private void Awake()
        {
            _material = GetComponent<SpriteRenderer>().material;
            propertyProgressID = Shader.PropertyToID("Progress");
        }


        void Update()
        {
            progress += 0.001f;
            _material.SetFloat(propertyProgressID, progress);
            progressText.text = $"{Mathf.Floor(progress * 100)}%";

            if (progress >= 1.01f)
            {
                progress = 0f;
            }
        }
    }

}
