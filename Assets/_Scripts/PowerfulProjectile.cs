using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerfulProjectile : MonoBehaviour
{
    public Rigidbody projectile;
    // Start is called before the first frame update
    void Start()
    {
        projectile = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        projectile.AddForce(0, 20, 0);
    }
}
