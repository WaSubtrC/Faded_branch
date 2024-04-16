using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCloudShadow : MonoBehaviour
{
    public GameObject objectToFollow;
    public float skyLevel;
    private float xPosition;
    private float zPosition;
    void Start()
    {
        this.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
    }

    private void Update()
    {
        xPosition = objectToFollow.transform.position.x;
        zPosition = objectToFollow.transform.position.z;
        this.transform.position = new Vector3(xPosition, skyLevel, zPosition);
    }


}
