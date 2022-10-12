using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halo : MonoBehaviour
{
    public Color HighlightColor;
    private Collider hitObject;
    private Color initialColor;
    private Material hitObjectMaterial;
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("GrappleObject"))
        {
            if (hitObject != null)
                hitObjectMaterial.color = initialColor;
            hitObject = hit.collider;
            hitObjectMaterial = hitObject.GetComponent<Renderer>().material;
            hitObjectMaterial.color = HighlightColor;
        }
        else if (hitObject != null)
        {
            hitObjectMaterial.color = initialColor;
            hitObject = null;
            hitObjectMaterial = null;
        }
    }
}
