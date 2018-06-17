using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathManager : MonoBehaviour {

    public Color nodeColor = Color.cyan;
    public Color lineColor = Color.white;
    public float nodeRadius = 1f;
    public List<Transform> nodes; 
    
    private void OnDrawGizmos()
    {
        nodes = new List<Transform>();

        //Puts the children of the PathManager into a list for node
        //visuallization
        for (int child = 0; child < transform.childCount; child++)
        {
            nodes.Add(transform.GetChild(child));
        }

        //Creates the visuals for the nodes
        for (int i = 0; i <= nodes.Count - 1; i++)
        {
            Gizmos.color = nodeColor;
            Gizmos.DrawSphere(nodes[i].position, nodeRadius);

            //Draw lines between the nodes to show the path
            if (nodes[i + 1] != null)
            {
                Gizmos.color = lineColor;
                Gizmos.DrawLine(nodes[i].position, nodes[i + 1].position);
            }
        }
    }
}

