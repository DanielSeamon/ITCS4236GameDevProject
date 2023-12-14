using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{

	public bool walkable;
	public Vector3 worldPos;
	public int gridX;
	public int gridY;
	public int gCost;
	public int hCost;
	public int FCost { get { return gCost + hCost; } }

	public Node parent;

	public Node(bool pWalkable, Vector3 pWorldPos, int pGridX, int pGridY)
	{
		walkable = pWalkable;
		worldPos = pWorldPos;
		gridX = pGridX;
		gridY = pGridY;
	}
}
