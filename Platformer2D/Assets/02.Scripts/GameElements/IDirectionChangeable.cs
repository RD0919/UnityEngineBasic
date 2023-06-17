using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirectionChangeable
{
    int direction { get; set; }
    event Action<int> onDirectionChanged;

}
