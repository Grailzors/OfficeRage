using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathManager : MonoBehaviour {

    public Color nodeColor = Color.cyan;
    public Color lineColor = Color.white;
    public float nodeRadius = 1f;
    public List<Transform> nodes;

    //Just for debuggin
    static public List<Transform> pathNodes;

    private void Awake()
    {
        GetNodes();
        pathNodes = nodes;
    }

    private void OnDrawGizmos()
    {
        GetNodes();

        //Creates the visuals for the nodes
        for (int i = 0; i < nodes.Count; i++)
        {
            Gizmos.color = nodeColor;
            Gizmos.DrawSphere(nodes[i].position, nodeRadius);

            //Draw lines between the nodes to show the path
            if (i+1 < nodes.Count)
            {
                Gizmos.color = lineColor;
                Gizmos.DrawLine(nodes[i].position, nodes[i+1].position);
            }
        }
    }

    void GetNodes()
    {
        nodes = new List<Transform>();

        //Puts the children of the PathManager into a list for node
        //visuallization
        for (int child = 0; child < transform.childCount; child++)
        {
            nodes.Add(transform.GetChild(child));
        }
    }

}