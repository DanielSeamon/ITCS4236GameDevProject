using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{

	Grid grid;

	public static PathFinding Instance { get; private set; }

	public List<Node> finalPath;

	//remove this for my sake of sanity

	// Use this for initialization
	//I did use an awake method here for grid component
	void Awake()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//Debug.Log("started path");
		//FindPath(seeker.position, target.position);
	}

	public void FindPath(Vector3 startPos, Vector3 targetPos)
	{
		grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
		Node startNode = grid.NodeWorldPoint(startPos);
		Node targetNode = grid.NodeWorldPoint(targetPos);
		//Debug.Log(startPos);

		List<Node> openSet = new List<Node>();
		HashSet<Node> closedSet = new HashSet<Node>();
		openSet.Add(startNode);

		while (openSet.Count > 0)
		{
			Node node = openSet[0];
			for (int i = 1; i < openSet.Count; i++)
			{
				if (openSet[i].FCost < node.FCost || openSet[i].FCost == node.FCost)
				{
					if (openSet[i].hCost < node.hCost)
						node = openSet[i];
				}
			}

			openSet.Remove(node);
			closedSet.Add(node);

			if (node == targetNode)
			{
				RetracePath(startNode, targetNode);
				return;
			}

			foreach (Node neighbor in grid.GetNeighbors(node))
			{
				if (!neighbor.walkable || closedSet.Contains(neighbor))
				{
					continue;
				}

				int newNeighborCost = node.gCost + GetDistance(node, neighbor);
				if (newNeighborCost < neighbor.gCost || !openSet.Contains(neighbor))
				{
					neighbor.gCost = newNeighborCost;
					neighbor.hCost = GetDistance(neighbor, targetNode);
					neighbor.parent = node;

					if (!openSet.Contains(neighbor))
						openSet.Add(neighbor);
				}
			}
		}
	}

	void RetracePath(Node startNode, Node endNode)
	{
		List<Node> path = new List<Node>();
		Node currentNode = endNode;

		while (currentNode != startNode)
		{
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}
		path.Reverse();

		grid.path = path;
		finalPath = path;
	}

	int GetDistance(Node nodeA, Node nodeB)
	{
		int distanceX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int distanceY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		if (distanceX > distanceY)
			return 14 * distanceY + 10 * (distanceX - distanceY);
		return 14 * distanceX + 10 * (distanceY - distanceX);
	}
}
