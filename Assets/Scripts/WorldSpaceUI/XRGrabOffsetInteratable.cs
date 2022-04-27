using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class XRGrabOffsetInteratable : XRGrabInteractable
{
    private Vector3 _interactorPosition = Vector3.zero;
    private Quaternion _interactorRotation = Quaternion.identity;

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);
        StoreInteractor(args);
        MatchAttachmentPoints(args);
    }

    private void StoreInteractor(SelectEnterEventArgs args)
    {
        _interactorPosition = ((XRBaseInteractor)args.interactorObject).attachTransform.localPosition;
        _interactorRotation = ((XRBaseInteractor)args.interactorObject).attachTransform.localRotation;

    }

    private void MatchAttachmentPoints(SelectEnterEventArgs args)
    {
        bool hasAttach = attachTransform != null;

        ((XRBaseInteractor)args.interactorObject).attachTransform.position = hasAttach ? attachTransform.position : transform.position;
        ((XRBaseInteractor)args.interactorObject).attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
    }


    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
        ResetAttachmentPoint(args);
        ClearInteractor(args);
    }

    private void ResetAttachmentPoint(SelectExitEventArgs args)
    {
        ((XRBaseInteractor)args.interactorObject).attachTransform.localPosition = _interactorPosition;
        ((XRBaseInteractor)args.interactorObject).attachTransform.localRotation = _interactorRotation;
    }

    private void ClearInteractor(SelectExitEventArgs args)
    {
        _interactorPosition = Vector3.zero;
        _interactorRotation = Quaternion.identity;
    }
}
