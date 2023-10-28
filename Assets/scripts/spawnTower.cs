using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTower : MonoBehaviour
{

    public Vector3 worldPosition;
	Plane plane = new Plane(Vector3.up, 0);
	public GameObject Tower1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (plane.Raycast(ray,out distance)){
			worldPosition = ray.GetPoint(distance);
		}

		if(Input.GetMouseButtonDown(1)){
			Debug.Log(worldPosition);
			Instantiate(Tower1, worldPosition, Quaternion.identity);
		}
        
    }
}
