using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePaintbrush : InteractableObject
{
    public GameObject paintTrailPrefab;

    GameObject paintTrailInstance; // inst of trail we are currently painting (default is null)

    public Material paintMaterial; // Material that has the paint color

    public Renderer paintBrushRenderer; // So we can take on the color of the paint that we touch

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Paint") // Check that the object we collided with is paint
        {
            paintMaterial = collision.gameObject.GetComponent<Renderer>().material;

            paintBrushRenderer.GetComponent<Renderer>().material = paintMaterial;
        }
    }

    public override void Interact() // To paint: Will run when pulling the trigger on controller
    {
        base.Interact();

        if(paintTrailInstance == null) // Then create a trail!
        {
            paintTrailInstance = Instantiate(paintTrailPrefab, paintBrushRenderer.transform.position, Quaternion.identity, paintBrushRenderer.transform); // Paint trail child of brush - will; follow

            paintTrailInstance.GetComponent<TrailRenderer>().material = paintMaterial; // Set material/color of paint trail
        }
    }

    public override void StopInteract() // To stop painting: Will run when trigger is released
    {
        base.StopInteract();

        if(paintTrailInstance != null) // Just in case
        {
            paintTrailInstance.transform.parent = null; // Parentless 

            paintTrailInstance = null; // Forget it
        }
    }

}
