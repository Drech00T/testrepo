using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class LinkMoveSystem : ComponentSystem
{   
    private struct Filter
    {
       public ComponentArray <Transform> transform;
       public ComponentArray<LinkComp> linkComp;
       public readonly int Length;
    }

    [Inject] Filter group;

    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            //Debug.Log("try moving stuff");
            if (group.linkComp[i].connectedNodes.Count != 0)
            {

                group.transform[i].RotateAround(Vector3.zero, Vector3.up, 10);
                //Debug.Log(group.linkComp[i].connectedNodes[1].name);
                Vector3 startPoint = group.linkComp[i].connectedNodes[0].transform.position;
                Vector3 endPoint = group.linkComp[i].connectedNodes[1].transform.position;
                Vector3 midPoint = (startPoint + endPoint) / 2f;
                group.transform[i].position = midPoint;
                //Debug.Log("should move to: " + midPoint);




            }
            else
            {
               // Debug.Log("index Problems");
            }
        }
    }
}
