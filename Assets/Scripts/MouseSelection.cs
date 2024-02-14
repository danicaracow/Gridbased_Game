using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelection : MonoBehaviour
{
    public enum State
    {
        Select,
        Build,
        Destroy
    }
    private State state = State.Select;

    [SerializeField] private GameObject _selectedObject;
    [SerializeField] private Camera _mainCamera;
    private LayerMask _selectableMask;
    private BuildManager buildManager;


    private void Start()
    {


        buildManager = GetComponent<BuildManager>();

        UIManager.Instance.buildButton.onClick.AddListener(OnBuildButtonPressed);
        UIManager.Instance.destroyButton.onClick.AddListener(OnDestroyButtonPressed);
        UIManager.Instance.selectButton.onClick.AddListener(OnSelectButtonPressed);
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

            _selectedObject = null;
        }

        if (Input.GetMouseButtonUp(1)) 
        {
            if (hit.collider != null) _selectedObject = hit.collider.gameObject;
            Debug.Log("Input received!");
            if (_selectedObject != null && _selectedObject.GetComponent<Building>())
            {
                Debug.Log("Building received!");
                buildManager.DestroyBuilding(_selectedObject);
            }
        }
    }


    private void OnBuildButtonPressed()
    {
        state = State.Build;
        Debug.Log(state);
    }

    private void OnDestroyButtonPressed()
    {
        state = State.Destroy;
        Debug.Log(state);
    }

    private void OnSelectButtonPressed()
    {
        state = State.Select;
        Debug.Log(state);
    }

}
