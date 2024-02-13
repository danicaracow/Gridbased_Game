using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseSelection : MonoBehaviour
{
    [SerializeField] private GameObject _selectedObject;
    [SerializeField] private Camera _mainCamera;
    private LayerMask _selectableMask;
    private BuildManager buildManager;



    

    private void Start()
    {
        buildManager = GetComponent<BuildManager>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, Mathf.Infinity);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null) _selectedObject = hit.collider.gameObject;


            if (_selectedObject != null && _selectedObject.GetComponent<Collider>().tag == "ground")
            {
                Debug.Log("Build!");
                Vector3 cellPos = _selectedObject.transform.position;

                buildManager.Build(cellPos);
            }
        }
    }

    
}
