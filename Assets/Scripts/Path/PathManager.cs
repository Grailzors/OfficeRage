using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour {

    public Color nodeColor = Color.cyan;
    public Color lineColor = Color.white;
    public float nodeRadius = 1f;
    public List<Transform> nodes; 
    
    private void OnDrawGizmosSelected()
    {
        nodes = new List<Transform>();

        //Puts the children of the PathManager into a list for node
        //visuallization
        for (int child = 0; child < transform.childCount; child++)
        {
            nodes.Add(transform.GetChild(child));
        }

        //Creates the visuals for the nodes
        for (int i = 0; i <= nodes.Count; i++)
        {
            Transform target = nodes[i+1];

            Gizmos.color = nodeColor;
            Gizmos.DrawSphere(nodes[i].position, nodeRadius);

            //Draw lines between the nodes to show the path
            if (target != null)
            {
                Gizmos.color = lineColor;
                Gizmos.DrawLine(nodes[i].position, target.position);
            }
        }


    }
}
