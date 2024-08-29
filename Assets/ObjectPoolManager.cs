using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.ComponentModel;

public class ObjectPoolManager : MonoBehaviour
{
   public static List<PooledObjectInfo> objectsPools = new List<PooledObjectInfo>();

   private GameObject _objectPoolEmptyHolder;

   private static GameObject _gameObjectsEmpty;

   public enum PoolType
   {
        GameObject,
        None,
   }
   public static PoolType PoolingType;
   private void Awake() {
        SetupEmptiesParents();
   }
   private void SetupEmptiesParents(){
        _objectPoolEmptyHolder = new GameObject("Pooled Objects");

        _gameObjectsEmpty = new GameObject("GameObjects");
        _gameObjectsEmpty.transform.SetParent(_objectPoolEmptyHolder.transform);
   }
   public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation, PoolType poolType = PoolType.None)
   {
        PooledObjectInfo pool = objectsPools.Find(p => p.lookupString == objectToSpawn.name);

        if(pool == null){
            pool = new PooledObjectInfo() { lookupString = objectToSpawn.name };
            objectsPools.Add(pool);
        }
        
        GameObject spawnableObj = pool.inactiveObjects.FirstOrDefault();

        if(spawnableObj == null){

            GameObject parentObject = SetParentObject(poolType);

            spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);

            if(parentObject != null){
                spawnableObj.transform.SetParent(parentObject.transform);
            }    

        }else{

            spawnableObj.transform.position = spawnPosition;
            spawnableObj.transform.rotation = spawnRotation;
            pool.inactiveObjects.Remove(spawnableObj);

            spawnableObj.SetActive(true);
            spawnableObj.SendMessage("Start");

        }
        return spawnableObj;
   }
   public static void DestroyObject(GameObject objectToDestroy){

        string fixName = objectToDestroy.name.Substring(0, objectToDestroy.name.Length - 7); // Removes the "(Clone)" from the object Instance name

        PooledObjectInfo pool = objectsPools.Find(p => p.lookupString == fixName);

        if(pool == null){
            Debug.LogWarning("Trying to destroy an non-pooled object with a pooled DestroyObject()" + objectToDestroy);
        }else{
            objectToDestroy.SetActive(false);
            pool.inactiveObjects.Add(objectToDestroy);
        }
   }
   private static GameObject SetParentObject(PoolType poolType)
   {
        switch(poolType)
        {
            case PoolType.GameObject:
                return _gameObjectsEmpty;
            case PoolType.None:
                return null;
            default:
                return null;
        }
   }
}

public class PooledObjectInfo
{
    public string lookupString;
    public List<GameObject> inactiveObjects = new List<GameObject>();

}