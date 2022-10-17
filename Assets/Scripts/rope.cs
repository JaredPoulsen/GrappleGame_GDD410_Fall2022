﻿using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class rope : MonoBehaviour
{ 
    public Transform bob;
    public Transform target1;
    private Transform curTarget;
    LineRenderer lr;
    private bool isTarget1 = true;
    public bool hasParent;
    public Camera cam;
    public LayerMask GrappleObject;


    // Use this for initialization
    void Start()
    {

        lr = GetComponent<LineRenderer>();
        if (hasParent)
        {
            lr.SetPosition(1, transform.InverseTransformPoint(bob.position));
        }
        else
        {
            lr.SetPosition(1, bob.position);
        }

        curTarget = target1;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out hit,75))
            {
                if (hit.collider.tag == "GrappleObject")
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
                }
                print(hit.transform.name);
                lr.enabled = true;
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            lr.enabled = false;
        }

        lr = GetComponent<LineRenderer>();
        if (hasParent)
        {
            lr.SetPosition(1, transform.InverseTransformPoint(bob.position));
        }
        else
        {
            lr.SetPosition(1, bob.position);
        }

        if (hasParent)
        {
            lr.SetPosition(0, transform.InverseTransformPoint(curTarget.position));
        }
        else
        {
            lr.SetPosition(0, curTarget.position);
        }

    }

}

