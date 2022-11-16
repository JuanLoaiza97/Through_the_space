using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLife : MonoBehaviour
{
    [SerializeField] public float timeToLife;

    private void Start() {
        SoundController.instance.PlayCollisionSound();
        Destroy(this.gameObject, timeToLife);
    }
}
