using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : ProjectileMotion
{
    public int points;
    
    void Update()
    {
        Move();
        Rotation();
        ValidateDestroy();
    }
}
