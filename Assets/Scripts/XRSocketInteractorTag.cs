using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class XRSocketInteractorTag : XRSocketInteractor
{
    public string targetTag = string.Empty;
    public override bool CanHover(IXRHoverInteractable interactable)
    {
        bool result = base.CanHover(interactable) && CompareTag(interactable.transform.gameObject, targetTag);
        Debug.Log(result);
        return result;
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        bool result = base.CanSelect(interactable) && CompareTag(interactable.transform.gameObject, targetTag);
        Debug.Log(result);
        return result;
    }

    private bool CompareTag(GameObject obj, string targetTag)
    {
        return obj.CompareTag(targetTag);
    }
}
