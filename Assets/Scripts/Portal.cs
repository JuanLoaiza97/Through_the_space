using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : ProjectileMotion
{
    public float moveLimit;
    private void Start() {
        GetComponent<AudioSource>().volume = 0;
    }

    private void Update()
    {
        Rotation();

        if (transform.position.x > moveLimit)
        {
            Move();
        }

        TurnUpVolumeSound();
    }

    private void TurnUpVolumeSound()
    {
        GetComponent<AudioSource>().volume += Time.deltaTime * speed * 7 / 100;
    }
}
