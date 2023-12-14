using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float moveSpeed;
    private float radiusOfSatisfaction;

    [SerializeField] private Transform myTransform;
    [SerializeField] private Transform targetTransform;

    private PathFinding path;
    private int lengthPath;
    private int position = 0;
    float wRadius = 1f;


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
        radiusOfSatisfaction = 0.01f;
        targetTransform = GameObject.Find("castle").transform;
        path = new PathFinding();
        path.FindPath(myTransform.position, targetTransform.position);
        lengthPath = path.finalPath.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (path.finalPath != null)
        {
            if (Vector3.Distance(path.finalPath[position].worldPos, myTransform.position) < wRadius && position < lengthPath - 1)
            {
                position++;
            }
            myTransform.position = Vector3.MoveTowards(myTransform.position, path.finalPath[position].worldPos, moveSpeed * Time.deltaTime);

        }
    }
}
