using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : ProjectileMotion
{
    public float healing;
    private void Update()
    {
        Move();
        Rotation();
        ValidateDestroy();
    }
}
