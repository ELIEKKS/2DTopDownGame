 // C#
 // WaveGenerator.cs
 using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 
 [System.Serializable]
 public class WaveAction
 {
     public string name;
     public float delay;
     public Transform prefab;
     public GameObject enemyPrefab;
     public int spawnCount;
     public string message;
 }
 
 [System.Serializable]
 public class Wave
 {
     public string name;
     public List<WaveAction> actions;
 }
 
 
 
 public class WaveGenerator : MonoBehaviour
 {
     public float difficultyFactor = 0.9f;

     public List<Wave> waves;
     private Wave m_CurrentWave;
     public Wave CurrentWave { get {return m_CurrentWave;} }
     private float m_DelayFactor = 1.0f;
 
     IEnumerator SpawnLoop()
     {
         m_DelayFactor = 1.0f;
         while(true)
         {
             foreach(Wave W in waves)
             {
                 m_CurrentWave = W;
                 foreach(WaveAction A in W.actions)
                 {
                     if(A.delay > 0)
                         yield return new WaitForSeconds(A.delay * m_DelayFactor);
                     if (A.message != "")
                     {
                         // TODO: print ingame message
                     }
                     if (A.prefab != null && A.spawnCount > 0)
                     {
                         for(int i = 0; i < A.spawnCount; i++)
                         {
                            float spawnY = Random.Range
                            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                            float spawnX = Random.Range
                            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
     
                            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
                            Instantiate(A.enemyPrefab, spawnPosition, Quaternion.identity);

                         }
                     }
                 }
                 yield return null;  // prevents crash if all delays are 0
             }
             m_DelayFactor *= difficultyFactor;
             yield return null;  // prevents crash if all delays are 0
         }
     }

     void Start()
     {
         StartCoroutine(SpawnLoop());
     }
 
 }