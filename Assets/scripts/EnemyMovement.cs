using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float moveSpeed;
    private float radiusOfSatisfaction;

    [SerializeField] private Transform myTransform;
    [SerializeField] private Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
      moveSpeed = 5f;
      radiusOfSatisfaction = 1f;
      targetTransform = GameObject.Find("castle").transform;   
    }

    // Update is called once per frame
    void Update()
    {
        RunKinematicArrive();
    }

    private void RunKinematicArrive(){
        // Create vector from character to target
        Vector3 towardsTarget = targetTransform.position - myTransform.position;

        // Check to see if the character is close enough to the target
        if (towardsTarget.magnitude <= radiusOfSatisfaction) {
            // Close enough to stop
            return;
        }

        // Normalize vector so we only use the direction
        towardsTarget = towardsTarget.normalized;

        // Face the target
        Quaternion targetRotation = Quaternion.LookRotation (towardsTarget);
        myTransform.rotation = Quaternion.Lerp (myTransform.rotation, targetRotation, 0.1f);

        // Move along our forward vector (the direction we're facing)
        Vector3 newPosition = myTransform.position;
        newPosition += myTransform.forward * moveSpeed * Time.deltaTime;

        myTransform.position = newPosition;
    }
}
