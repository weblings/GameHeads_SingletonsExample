using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenEffectsManager : MonoBehaviour
{
    #region Variables ------------------
    public Image image;
    Color startColor;
    public Color damagedColor;
    public float lerpSpeed;
    //----------------------------------
    #endregion

    #region v3
    //Singleton Stuff -------------------------------------
    /*static ScreenEffectsManager instance;
    public static ScreenEffectsManager Instance{
        get{
            if(instance == null){
                instance = new ScreenEffectsManager();
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

    #region MonoBehaviour Functions ---
    void Start(){
        startColor = image.color;
    }
    #endregion //----------------------

    #region Player Took Damage Functions ----------
    public void playerTookDamage(){
        StartCoroutine(lerpImageToAndFromColor(damagedColor,startColor,0));
    }

    IEnumerator lerpImageToAndFromColor(Color B, Color finalColor, float holdTime){
        Color A = image.color; //start from whatever color is image currently is
        float lerpAmount = 0;
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

        while(lerpAmount < 1){
            image.color = Color.Lerp(A,B,lerpAmount); //lerp to B color
            lerpAmount += Time.fixedDeltaTime * lerpSpeed;
            yield return waitForFixedUpdate;
        }
        image.color = B;

        yield return new WaitForSeconds(holdTime);

        lerpAmount = 0;
        while(lerpAmount < 1){
            image.color = Color.Lerp(B,finalColor,lerpAmount); //lerp to finalColor (just in case A != that)
            lerpAmount += Time.deltaTime * lerpSpeed;
            yield return waitForFixedUpdate;
        } 
        image.color = finalColor;
    }
    #endregion //------------------------------------
}
