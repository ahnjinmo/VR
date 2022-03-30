using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.Interaction.Toolkit
{
    public class DoorGrabbable : XRGrabInteractable
    {
        public Transform handler;

        protected override void Drop()
        {
            base.Drop();

            transform.position = handler.transform.position;
            transform.rotation = handler.transform.rotation;

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            Rigidbody handlerrb = handler.GetComponent<Rigidbody>();
            handlerrb.velocity = Vector3.zero;
            handlerrb.angularVelocity = Vector3.zero;

        }
    }
}