using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boost : MonoBehaviour
{
    [SerializeField] private float _duration;

    public float Duration => _duration;
}
