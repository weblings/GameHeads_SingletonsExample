using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Variables ------------------------
    [Header("Coin Vars")]
    public int totalCoins;
    public Text coinText;

    #region v1 Variables
    [Header("Onlooker Vars")]
    public Onlooker[] Onlookers;

    [Header("Audio Vars")]
    public AudioClip playerDamagedClip;
    public AudioSource audioSource;

    [Header("Fake Post-Processing Vars")]
    public Image image;
    Color startColor;
    public Color damagedColor;
    public float lerpSpeed;
    #endregion
    //----------------------------------

    #region v3 Logic
    //Singleton Stuff -------------------------------------
    static GameManager instance;
    /*public static GameManager Instance{
        get{
            if(instance == null){
                instance = new GameManager();
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

    #region MonoBehaviour Functions ---------
    void Start(){
        setCoinText(totalCoins);
    }
    #endregion //----------------------------

    #region Player Took Damage Functions ----------
    public void playerTookDamage(){
        setCoinText(totalCoins--);

        #region v1 playerTookDamage
        foreach(Onlooker onlooker in Onlookers){
            onlooker.displayLaughText();
        }

        playClip(playerDamagedClip);

        StartCoroutine(lerpImageToAndFromColor(damagedColor,startColor,0));
        #endregion
    }

    void setCoinText(int newCoinAmount){
        coinText.text = totalCoins.ToString();
    }
    #endregion //------------------------------------

    #region v1 Functions ------------------
    public void playClip(AudioClip newClip){
        audioSource.clip = newClip;
        audioSource.Play();
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
    //----------------------------------
    #endregion
}
