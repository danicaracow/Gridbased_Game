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
    private BuildSystem buildSystem;

    public static MouseSelection Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        buildSystem = GetComponent<BuildSystem>();

    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, Mathf.Infinity);

        if (Input.GetMouseButtonDown(0))
        {
            switch (state)
            {
                case State.Build:
                    if (hit.collider != null) _selectedObject = hit.collider.gameObject;


                    if (_selectedObject != null && _selectedObject.GetComponent<Collider>().tag == "ground")
                    {
                        Vector3 cellPos = _selectedObject.transform.position;

                        buildSystem.Build(cellPos);
                    }

                    _selectedObject = null;
                    break;

                case State.Destroy:
                    if (hit.collider != null) _selectedObject = hit.collider.gameObject;
                    if (_selectedObject != null && _selectedObject.GetComponent<Building>())
                    {
                        buildSystem.DestroyBuilding(_selectedObject);
                    }
                    break;
            } 
        }
    }


    public void OnBuildButtonPressed()
    {
        state = State.Build;
        Debug.Log(state);
    }

    public void OnDestroyButtonPressed()
    {
        state = State.Destroy;
        Debug.Log(state);
    }

    public void OnSelectButtonPressed()
    {
        state = State.Select;
        Debug.Log(state);
    }

}
