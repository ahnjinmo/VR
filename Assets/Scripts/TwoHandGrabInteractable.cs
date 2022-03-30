using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandGrabInteractable : XRGrabInteractable
{
    public List<XRSimpleInteractable> secondHandGrabPoints = new List<XRSimpleInteractable>();
    private IXRSelectInteractor firstInteractor, secondInteractor;
    public enum TwoHandRotationType { None, First, Second };
    public TwoHandRotationType twoHandRotationType;
    public bool snapToSecondHand = true;
    private Quaternion initialRotationOffset;

    private void Start()
    {
        foreach (var item in secondHandGrabPoints)
        {
            item.selectEntered.AddListener(OnSecondHandGrab);
            item.selectExited.AddListener(OnSecondHandRelease);
        }
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        // compute rotation
        if (firstInteractor != null && secondInteractor != null)
        {
            firstInteractor.transform.rotation = GetTwoHandRotation();

        }
        base.ProcessInteractable(updatePhase);
    }

    private Quaternion GetTwoHandRotation()
    {
        Quaternion targetRotation;

        if (twoHandRotationType == TwoHandRotationType.None)
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.transform.position - firstInteractor.transform.position);
        }
        else if (twoHandRotationType == TwoHandRotationType.First)
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.transform.position - firstInteractor.transform.position, firstInteractor.transform.up);
        }
        else
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.transform.position - firstInteractor.transform.position, secondInteractor.transform.up);
        }

        return targetRotation;
    }

    /*---------first interactor-----------*/
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        firstInteractor = args.interactorObject;

        base.OnSelectEntered(args);
        
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {

        firstInteractor = null;
        secondInteractor = null;
        base.OnSelectExited(args);
    }
    /*-----------second intercator-----------------*/
    public void OnSecondHandGrab(SelectEnterEventArgs args)
    {
        secondInteractor = args.interactorObject;
    }

    public void OnSecondHandRelease(SelectExitEventArgs args) => secondInteractor = null;
}
