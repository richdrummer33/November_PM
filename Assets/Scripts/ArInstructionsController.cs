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
        currentStepIndex = 0; // To be safe

        steps[currentStepIndex].SetActive(true);

        taskSelectionCanvas.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
