//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Unity.Entities;
//using System.ComponentModel;
//using Unity.Transforms;

//public class HighlightNextNodesSystem : ComponentSystem
//{

//    private struct Filter
//    {
//        public ComponentArray<Transform> transform;
//        public ComponentArray<TreeNodeComp> treeNodeComp;
//        public EntityArray entity;
//        public readonly int Length;
//    }

//    [Inject] Filter group;

//    private Collider[] overlapSphereColliders;
//    private List<GameObject> nodesInRangeList;
    
    
//    protected override void OnUpdate()
//    {


//        for (int i = 0; i < group.Length; i++)
//        {
//            //Debug.Log(entity.GetHashCode());

//            //check if in range
//            overlapSphereColliders = Physics.OverlapSphere(group.transform[i].position, group.treeNodeComp[i].linkDistance);

//            foreach (Collider col in overlapSphereColliders)
//            {

                

//                if (col != )
//                {

//                }
//                nodesInRangeList.Add(col.gameObject);
//            }



//            PostUpdateCommands.AddComponent(group.entity[i], new OnHighlight() { nodeID = group.entity[i].Index, entity = group.entity[i], nodesInRange = nodesInRangeList });
//            PostUpdateCommands.AddComponent(group.entity[i], new OnConnecting() { nodeID = group.entity[i].Index, entity = group.entity[i] });
//        }
//    }
//}


//public struct OnHighlight : IComponentData
//{
//    public int nodeID;
//    public Entity entity;
//}
