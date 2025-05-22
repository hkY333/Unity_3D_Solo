using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMachine : MonoBehaviour
{
    public float machinePower;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.rigidbody.AddForce(Vector3.up * machinePower, ForceMode.Impulse);
        }
    }
}
