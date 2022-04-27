using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WristUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject _wristUIPrefab;
    [SerializeField]
    private Transform _wristButtonTransform;
    [SerializeField]
    private XRSocketInteractor _socket;
    private bool isOpened;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickedWristButton()
    {
        var obj = Instantiate(_wristUIPrefab, _wristButtonTransform.position, _wristButtonTransform.rotation);
        //_socket.interactionManager.SelectEnter(_socket, obj.GetComponent<IXRSelectInteractable>());
        _socket.StartManualInteraction((IXRSelectInteractable)obj.GetComponent<XRGrabOffsetInteratable>());

    }
}
