using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class XRTouchableUI : XRBaseInteractable
{
    private BoxCollider _collider;
    private RectTransform _rect;
    private Button _btn;

    void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _rect = GetComponent<RectTransform>();
        _btn = GetComponent<Button>();
        UpdateColliderSize();
    }

    void UpdateColliderSize()
    {
        _collider.size = new Vector3(_rect.sizeDelta.x, _rect.sizeDelta.y, _collider.size.z);
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        _btn.onClick.Invoke();
    }
}
