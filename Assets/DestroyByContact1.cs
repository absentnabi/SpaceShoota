using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DestroyByContact1 : MonoBehaviour
{
   public GameObject explosion;
   public GameObject playerExplosion;
   public GameController1 gameController;
   public int scoreValue;

   private void Start()
   {
      GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
      if (gameControllerObject != null)
      {
         gameController = gameControllerObject.GetComponent<GameController1>();
      }
      else
      {
         Debug.Log("Game Controller not found");
      }
   }

   void OnTriggerEnter(Collider other)
   {
      
      //Debug.Log(other.gameObject);
      if (other.tag == "Boundary1" )
      {
         return;
      }
      
      if (other.tag == "Player")
      {
         Instantiate(playerExplosion, other.transform.position, transform.rotation);
         gameController.GameOver();
         
         Destroy(other.gameObject);
     
         Destroy(gameObject);

         return;
      }

      
      Instantiate(explosion, other.transform.position, transform.rotation);
      gameController.AddScore(scoreValue);
      
      Destroy(other.gameObject);
     
      Destroy(gameObject);
      
      
      
      
     
   }


   
   
   
   
}
