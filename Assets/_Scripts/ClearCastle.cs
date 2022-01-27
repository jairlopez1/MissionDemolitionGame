using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCastle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ClearProjectile")
        {
            Destroy(gameObject);
        }
    }
}
