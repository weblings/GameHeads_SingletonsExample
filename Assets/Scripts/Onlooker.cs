using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onlooker : MonoBehaviour
{

    #region Variables ------------------------
    public TextMesh textMesh;

    public string taunt;
    public string laugh;

    Coroutine displayTextCoroutine;
    Coroutine resetToTauntCoroutine;
    #endregion //-----------------------------

    #region MonoBehaviours Functions ---------
    void Start(){
        displayTauntText();
    }
    #endregion //----------------------------

    #region Display Text Functions ----------
    void displayTauntText(){
        startDisplayTextLoop(taunt);
    }

    public void displayLaughText(){
        startDisplayTextLoop(laugh);
        startResetToTaunt(6);
    }
    #endregion //----------------------------

    #region Text Loop Functions -------------
    void startDisplayTextLoop(string newText){
        stopDisplayTextLoop();
        displayTextCoroutine = StartCoroutine(displayTextLoop(newText));
    }

    IEnumerator displayTextLoop(string newText){
        while(true){
            textMesh.text = newText;
            yield return new WaitForSeconds(3);
            textMesh.text = string.Empty;
            yield return new WaitForSeconds(3);
        }
    }

    void stopDisplayTextLoop(){
        if(displayTextCoroutine!= null) StopCoroutine(displayTextCoroutine);
        displayTextCoroutine = null;
    }
    #endregion //----------------------------

    #region Reset To Taunt Functions --------
        void startResetToTaunt(float delay){
        stopResetToTaunt();
        resetToTauntCoroutine = StartCoroutine(resetToTaunt(delay));
    }

    IEnumerator resetToTaunt(float delay){
        yield return new WaitForSeconds(delay);
        displayTauntText();
    }

    void stopResetToTaunt(){
        if(resetToTauntCoroutine!= null) StopCoroutine(resetToTauntCoroutine);
        resetToTauntCoroutine = null;
    }
    #endregion //----------------------------

}
