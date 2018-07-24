using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class LinkSclaeSystem : ComponentSystem
{
    private struct Filter
    {
        public ComponentArray<Transform> transform;
        public ComponentArray<LinkComp> linkComp;
        public readonly int Length;
    }

    [Inject] Filter group;

    protected override void OnUpdate()
    {   



        for (int i = 0; i < group.Length; i++)
        {

            if (group.linkComp[i].connectedNodes.Count == 2)
            {
                
                float linkMeshRadius;
                linkMeshRadius = group.linkComp[i].linkMeshRadius;
                group.linkComp[i].linkLength = Vector3.Distance(group.linkComp[i].connectedNodes[0].transform.position, group.linkComp[i].connectedNodes[1].transform.position);
                group.transform[i].localScale =new Vector3(linkMeshRadius, linkMeshRadius, group.linkComp[i].linkLength * group.linkComp[i].lengthModifier);
                //Debug.Log(group.linkComp[i].connectedNodes[1].name);
                //Vector3 startPoint = group.linkComp[i].connectedNodes[0].transform.position;
                //Vector3 endPoint = group.linkComp[i].connectedNodes[1].transform.position;
                //Vector3 midPoint = (startPoint + endPoint) / 2f;
                //group.transform[i].position = midPoint;
                //Debug.Log("should move to: " + midPoint);
            }
            else
            {
                // Debug.Log("index Problems");
            }
        }
    }
}
