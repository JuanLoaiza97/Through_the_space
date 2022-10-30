using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : ProjectileMotion
{
    public float MoveLimit;
    private void Start() {
        GetComponent<AudioSource>().volume = 0;
    }

    private void Update()
    {
        Rotation();

        if (transform.position.x > MoveLimit)
        {
            Move();
        }

        TurnUpVolumeSound();
    }

    private void TurnUpVolumeSound()
    {
        GetComponent<AudioSource>().volume += Time.deltaTime * speed / 100;
    }
}
