using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArInstructionsController : MonoBehaviour
{
    public List<GameObject> steps = new List<GameObject>(); // Declared (created) an empty list of Game Objects

    int currentStepIndex = 0;

    public GameObject taskSelectionCanvas;

    private void OnEnable() // This runs when this game objects becomes enables
    {
        currentStepIndex = 0; // Select the 1st step

        steps[currentStepIndex].SetActive(true); // Enable the 1st step 

        taskSelectionCanvas.SetActive(false);
    }

    // A method for the "Next Step"  button
    public void NextStep()
    {
        steps[currentStepIndex].SetActive(false); // Disable current step

        currentStepIndex = currentStepIndex + 1; // Increment the step index (count)

        if(currentStepIndex < steps.Count) // Check the index is not > than the list size
        {
            steps[currentStepIndex].SetActive(true); // Enable the nexct step
        }
        else // We finished all instructions
        {
            taskSelectionCanvas.SetActive(true); // So user can select another task!

            gameObject.SetActive(false); // Disable this* object
        }
    }
}
