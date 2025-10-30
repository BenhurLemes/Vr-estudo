using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR.Management.Metadata;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// Flag: Se for colocado esse componente, o Unity vai garantir que o componente XRGrabInteractable tamb�m esteja presente no GameObject
[RequireComponent(typeof(XRGrabInteractable))]
public class LightManager : MonoBehaviour
{
    [SerializeField, HideInInspector] XRGrabInteractable GrabInteractable;
    [SerializeField] Light Light;

    #region Unity Method
    // Esse trecho � padr�o gerado pelo Unity 
#if UNITY_EDITOR
    private void OnValidate()
    {
        if(GrabInteractable == null)
        {
            GrabInteractable = GetComponent<XRGrabInteractable>();
        }
    }
#endif

    private void Awake()
    {
        if(GrabInteractable == null)
        {
            GrabInteractable = GetComponent<XRGrabInteractable>();
        }
    }

    private void OnEnable()
    {
        // Ctrl + . = criar um contextual (vari�vel / m�todo / classe)
        GrabInteractable.activated.AddListener(OnToggleLight);
    }

    private void OnToggleLight(ActivateEventArgs eventArgs)
    {
        Light.enabled = !Light.enabled; // Alterna o estado da luz (liga/desliga)
        //throw new NotImplementedException(); -> Serve para indicar que o m�todo ainda n�o foi implementado
    }

    private void OnDisable()
    {
        
    }
    #endregion
}
