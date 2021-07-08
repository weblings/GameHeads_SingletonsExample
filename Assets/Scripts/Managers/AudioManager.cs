using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip playerDamagedClip;
    public AudioSource audioSource;

    #region v3
    //Singleton Stuff -------------------------------------
    /*static AudioManager instance;
    public static AudioManager Instance{
        get{
            if(instance == null){
                instance = new AudioManager();
            }
            return instance;
        }
    }

    void Awake(){
         if (instance != null && instance != this){ // if the singleton hasn't been initialized yet
             Destroy(this.gameObject);
         } 
         instance = this;
         //DontDestroyOnLoad( this.gameObject );
    }*/
    //-------------------------------------------------------
    #endregion

    #region Player Took Damage Functions ----------
    public void playClip(AudioClip newClip){
        audioSource.clip = newClip;
        audioSource.Play();
    }

    public void playerTookDamage(){
        playClip(playerDamagedClip);
    }
    #endregion //----------------------------------
}
