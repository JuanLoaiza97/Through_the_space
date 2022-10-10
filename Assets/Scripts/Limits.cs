using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits : MonoBehaviour
{
    public Vector2 horizontalRange = Vector2.zero;
    public Vector2 verticalRange = Vector2.zero;

    private Transform theTransfomr;

    void LateUpdate() {
        theTransfomr.position = new Vector3(
            Mathf.Clamp(transform.position.x, verticalRange.x, verticalRange.y),
            Mathf.Clamp(transform.position.x, horizontalRange.x, horizontalRange.y),
            transform.position.z
        );
    }

    void Start()
    {
        theTransfomr = GetComponent<Transform>();
    }
}
