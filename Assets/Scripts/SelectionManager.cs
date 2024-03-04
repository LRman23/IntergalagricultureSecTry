using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{

    public static SelectionManager instance { get; set; }


    public bool onTar;

    public GameObject selectObj;

    public GameObject infoText;
    TextMeshProUGUI interactionText;

    private void Start()
    {
        onTar = false;
        interactionText = infoText.GetComponent<TextMeshProUGUI>();
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;

            InteractableObject interactable = selectionTransform.GetComponent<InteractableObject>();

            if (interactable && interactable.inRange)
            {
                onTar = true;
                selectObj = interactable.gameObject;
                interactionText.text = interactable.GetItemName();
                infoText.SetActive(true);
            }
            else
            {
                onTar = false;
                infoText.SetActive(false);
            }

        }
        else
        {
            onTar = false;
            infoText.SetActive(false);
        }
    }
}
