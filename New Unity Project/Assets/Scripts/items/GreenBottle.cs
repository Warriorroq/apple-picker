using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBottle : Item
{
    public float force;
    private void Start()
    {
        GetStats();
        GetComponent<Rigidbody>().AddForce((Vector3.left * Random.Range(-2, 2) + Vector3.up) * force);
    }
}
