using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public static MainCamera instance;

    public bool isInside = false;
    [SerializeField] private Transform insidePos;
    [SerializeField] private Transform outsidePos;
    [SerializeField] private float speed = 0.06f;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        transform.position = outsidePos.position;
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

    private void OnApplicationQuit()
    {
        Destroy(instance);
    }

}
