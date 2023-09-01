using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartSpawner : MonoBehaviour
{
    public GameObject DartPrefab;  // Reference to your dart prefab
    public Transform DartSpawnPoint;  // Reference to the GameObject where the dart should be spawned

    // Start is called before the first frame update
    void Start()
    {
        // Register the method to be called when the ball is placed
        PlaceObjectOnPlane.onPlacedObject += SpawnDartAfterDelay;
    }
    

    // This method will be called when the ball is placed
    void SpawnDartAfterDelay()
    {
        StartCoroutine(SpawnDartDelayed());
    }

    // Coroutine to spawn the dart after a delay
    IEnumerator SpawnDartDelayed()
    {
        yield return new WaitForSeconds(0.1f);  // Wait for 0.1 seconds

        // Spawn the dart at the specified GameObject's transform
        Instantiate(DartPrefab, DartSpawnPoint.position, DartSpawnPoint.rotation);
    }

    // Unregister the method when this script is disabled
    void OnDisable()
    {
        PlaceObjectOnPlane.onPlacedObject -= SpawnDartAfterDelay;
    }
}
