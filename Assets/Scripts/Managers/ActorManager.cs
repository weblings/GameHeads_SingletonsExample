using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : MonoBehaviour
{
    public Mario mario;
    public Onlooker[] Onlookers;
    public GameObject goomba;

    #region v3
    //Singleton Stuff -------------------------------------
    /*static ActorManager instance;
    public static ActorManager Instance{
        get{
            if(instance == null){
                instance = new ActorManager();
            }
            return instance;
        }
    }

    void Awake(){
         if (instance != null && instance != this){ // if the singleton hasn't been initialized yet
             Destroy(this.gameObject);
         } 
         instance = this;
    }*/
    //-------------------------------------------------------
    #endregion

    #region Player Took Damage Functions ------------
    public void playerTookDamage(){
        foreach(Onlooker onlooker in Onlookers){
            onlooker.displayLaughText();
        }
    }
    #endregion //------------------------------------
}
