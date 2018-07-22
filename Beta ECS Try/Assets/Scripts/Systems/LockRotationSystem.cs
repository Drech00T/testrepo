using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
public class LockRotationSystem : ComponentSystem {
    private struct Filter
    {
        private Vector3 Rotation;
        private CubeComponent cubeComp;
    }

	protected override void OnUpdate () {
        foreach (var entity in GetEntities<Filter>())
        {
            entity.   entity.Rotation
        }
    }
}   
