using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

	public LayerMask unwalkable;
	public Vector2 gridSize;
	public float nodeR;
	Node[,] grid;

	float nodeD;
	int gridSizeX;
	int gridSizeY;

	//Script needs to be called to update grid for obstacles
	void Awake()
	{
		nodeD = nodeR * 2;
		gridSizeX = Mathf.RoundToInt(gridSize.x / nodeD);
		gridSizeY = Mathf.RoundToInt(gridSize.y / nodeD);
		CreateGrid();
	}

	void CreateGrid()
	{
		grid = new Node[gridSizeX, gridSizeY];
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridSize.x / 2 - Vector3.forward * gridSize.y / 2;

		for (int x = 0; x < gridSizeX; x++)
		{
			for (int y = 0; y < gridSizeY; y++)
			{
				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeD + nodeR) + Vector3.forward * (y * nodeD + nodeR);
				bool walkable = !(Physics.CheckSphere(worldPoint, nodeR, unwalkable));
				grid[x, y] = new Node(walkable, worldPoint, x, y);
			}
		}
	}

	public List<Node> GetNeighbors(Node node)
	{
		List<Node> neighbors = new List<Node>();

		for (int x = -1; x <= 1; x++)
		{
			for (int y = -1; y <= 1; y++)
			{
				if (x == 0 && y == 0)
					continue;

				int checkX = node.gridX + x;
				int checkY = node.gridY + y;

				if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
				{
					neighbors.Add(grid[checkX, checkY]);
				}
			}
		}

		return neighbors;
	}

	public Node NodeWorldPoint(Vector3 worldPos)
	{
		float percentX = (worldPos.x + gridSize.x / 2) / gridSize.x;
		float percentY = (worldPos.z + gridSize.y / 2) / gridSize.y;

		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
		int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
		//Debug.Log(grid[x, y].worldPos);
		return grid[x, y];
	}

	public List<Node> path;

	public List<Node> getPath()
	{
		return path;
	}
	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(gridSize.x, 1, gridSize.y));

		if (grid != null)
		{
			foreach (Node n in grid)
			{
				Gizmos.color = (n.walkable) ? Color.white : Color.red;
				if (path != null)
					if (path.Contains(n))
						Gizmos.color = Color.black;
				Gizmos.DrawCube(n.worldPos, Vector3.one * (nodeD - .1f));
			}
		}
	}
}
