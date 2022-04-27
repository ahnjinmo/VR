using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class BoxColliderInteraction : MonoBehaviour
{
    private BoxCollider _collider;
    private RectTransform _rect;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _rect = GetComponent<RectTransform>();
        UpdateColliderSize();
    }

    void UpdateColliderSize()
    {
        _collider.size = new Vector3(_rect.sizeDelta.x, _rect.sizeDelta.y, _collider.size.z);
    }
}
