//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Unity.Entities;

//public class CollisionEmitter : MonoBehaviour
//{

//    public void OnCollisionEnter(Collider other)
//    {
//        GameObjectEntity otherGameObjectEntity = other.GetComponent<GameObjectEntity>();
//        if (!otherGameObjectEntity)
//        {
//            return;
//        }

//        Entity sourceEntity = GetComponent<GameObjectEntity>().Entity;
//        var entityManager = World.Active.GetExistingManager<EntityManager>();
//        Entity collisionEventEntity = entityManager.CreateEntity(typeof(CollisionComponent));
//        entityManager.SetComponentData(collisionEventEntity, new CollisionComponent
//        {
//            source = sourceEntity,
//            other = otherGameObjectEntity.Entity,
//        });
//    }
//}

//struct CollisionComponent : IComponentData
//{
//    public Entity source;
//    public Entity other;
//}