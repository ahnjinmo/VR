using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : XRGrabInteractable
{
    private GripHold gripHold = null;

    private XRBaseInteractor gripHand = null;

    private readonly Vector3 gripRotation = new Vector3(45, 0, 0);

    protected override void Awake()
    {
        base.Awake();
        SetupHolds();

        onSelectEntered.AddListener(SetInitialRotation);
    }

    private void SetupHolds()
    {
        gripHold = GetComponentInChildren<GripHold>();
        gripHold.Setup(this);
    }

    private void SetupExtras()
    {

    }

    private void OnDestroy()
    {
        onSelectEntered.RemoveListener(SetInitialRotation);
    }

    private void SetInitialRotation(XRBaseInteractor interactor)
    {
        Quaternion newRotation = Quaternion.Euler(gripRotation);
        interactor.attachTransform.localRotation = newRotation;
    }

    public void SetGripHand(XRBaseInteractor interactor)
    {
        gripHand = interactor;
        ManualSelect(interactor);
    }

    private void ManualSelect(XRBaseInteractor interactor)
    {
        OnSelectEntering(interactor);
        OnSelectEntered(interactor);
    }

    public void ClearGripHand(XRBaseInteractor interactor)
    {
        gripHand = null;
        ManualDeselect(interactor);
    }

    private void ManualDeselect(XRBaseInteractor interactor)
    {
        OnSelectExiting(interactor);
        OnSelectExited(interactor);
    }
}
