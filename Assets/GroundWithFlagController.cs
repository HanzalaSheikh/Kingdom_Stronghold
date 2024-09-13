using UnityEngine;

public class GroundWithFlagController : MonoBehaviour
{
    public GameObject abilitiesPrefab;  // Assign the Abilities prefab here
    private GameObject instantiatedAbilities;  // To store the instantiated abilities

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast to detect what is clicked
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                // Check if the clicked object is the groundWithFlag
                if (hit.collider.gameObject == gameObject)
                {
                    // If abilities are not yet instantiated, instantiate them
                    if (instantiatedAbilities == null)
                    {
                        ShowAbilities();
                    }
                    else
                    {
                        HideAbilities();  // Optional: hide abilities if clicked again
                    }
                }
            }
        }
    }

    void ShowAbilities()
    {
        // Instantiate the Abilities prefab at the same position as groundWithFlag
        instantiatedAbilities = Instantiate(abilitiesPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    }

    void HideAbilities()
    {
        // Destroy the instantiated abilities if needed
        if (instantiatedAbilities != null)
        {
            Destroy(instantiatedAbilities);
        }
    }
}
