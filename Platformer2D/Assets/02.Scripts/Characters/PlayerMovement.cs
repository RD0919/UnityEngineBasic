using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : Movement
{
    protected override void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        base.Update();
    }
}
