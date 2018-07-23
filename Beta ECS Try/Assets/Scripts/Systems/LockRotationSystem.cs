using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
public class LockRotationSystem : ComponentSystem {
    private struct Filter
    {
        private CubeComponent cubeComp;
        public Transform transform;
    }

	protected override void OnUpdate () {
        foreach (var entity in GetEntities<Filter>())
        {
            entity.transform.rotation = Quaternion.identity; 
        }
    }
}   
