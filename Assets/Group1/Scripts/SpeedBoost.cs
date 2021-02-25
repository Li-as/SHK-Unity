using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private int _speedMultiplier;

    public float Duration => _duration;
    public int SpeedMultiplier => _speedMultiplier;
}
