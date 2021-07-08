using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    //Variables -----------------------------
    public GameManager gameManager;

    #region v2
    public AudioManager audioManager;
    public ActorManager actorManager;
    public ScreenEffectsManager screenEffectsManager;
    #endregion

    public float speed;
    //---------------------------------------

    #region MonoBehaviour Functions ---------
    void Update(){
        if(Input.GetKey(KeyCode.W)){
            moveMario(Vector3.back); //-z
        }else if(Input.GetKey(KeyCode.S)){
            moveMario(Vector3.forward); //+z
        }

        if(Input.GetKey(KeyCode.A)){
            moveMario(Vector3.right); //+x
        }else if(Input.GetKey(KeyCode.D)){
            moveMario(Vector3.left); //-x
        }
    }

    void OnTriggerEnter(Collider col){
        takeDamage();
    }
    #endregion //-----------------------------

    #region v1 Mario-Specific Functions -----
    public void takeDamage(){
        gameManager.playerTookDamage();
    }

    void moveMario(Vector3 direction){
        transform.Translate(direction * speed * Time.deltaTime);
    }
    #endregion //----------------------------

    #region v2 Mario-Specific Functions -----
    /*public void takeDamage(){
        audioManager.playerTookDamage();
        gameManager.playerTookDamage();
        actorManager.playerTookDamage();
        screenEffectsManager.playerTookDamage();
    }

    void moveMario(Vector3 direction){
        transform.Translate(direction * speed * Time.deltaTime);
    }*/
    #endregion //-----------------------------

    #region v3 Mario-Specific Functions ------
    //Mario-Specific Functions
    /*public void takeDamage(){
        AudioManager.Instance.playerTookDamage();
        GameManager.Instance.playerTookDamage();
        ActorManager.Instance.playerTookDamage();
        ScreenEffectsManager.Instance.playerTookDamage();
    }

    void moveMario(Vector3 direction){
        transform.Translate(direction * speed * Time.deltaTime);
    }*/
    #endregion //-----------------------------
}
