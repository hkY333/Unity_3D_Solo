using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMachine : MonoBehaviour
{
    public float machineUpPower;
    public float machineForwardPower;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.rigidbody.AddForce(Vector3.up * machineUpPower, ForceMode.Impulse);            
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
    //    { 
    //        collision.rigidbody.AddForce(Vector3.forward * machineForwardPower, ForceMode.Impulse);
    //    }
    //}
}
