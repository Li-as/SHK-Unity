using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : Boost
{
    [SerializeField] private int _speedMultiplier;

    public int SpeedMultiplier => _speedMultiplier;
}
