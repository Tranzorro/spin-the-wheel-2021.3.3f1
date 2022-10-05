using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;
using TMPro;

public class Spinthewheel : MonoBehaviour
{

    [SerializeField] private Button uiSpinButton ;
    [SerializeField] private TextMeshProUGUI uiSpinButtonText ;

    [SerializeField] private PickerWheel pickerWheel ;
    [SerializeField] private TextMeshProUGUI result;




    public void SpinIt(){ //the clicked version
    uiSpinButton.onClick.AddListener (() => {
        pickerWheel.audioSource.clip = pickerWheel.tickAudioClip ;
        uiSpinButton.interactable = false ;
        uiSpinButtonText.text = "Spinning" ;

        pickerWheel.OnSpinEnd (wheelPiece => {
            pickerWheel.audioSource.clip = pickerWheel.fanfareAudioClip ;
            pickerWheel.audioSource.PlayOneShot (pickerWheel.audioSource.clip);
            result.text = wheelPiece.Label;
            Debug.Log (
                @" <b>Index:</b> " + wheelPiece.Index + "           <b>Label:</b> " + wheelPiece.Label
                + "\n <b>Amount:</b> " + wheelPiece.Amount + "      <b>Chance:</b> " + wheelPiece.Chance + "%"
            ) ;

            uiSpinButton.interactable = true ;
            uiSpinButtonText.text = "Spin" ;
        }) ;
        result.text = "";
        pickerWheel.Spin () ;

        }) ;
}
    public void SpinItChat(){ //the chat command version
        pickerWheel.audioSource.clip = pickerWheel.tickAudioClip ;
        uiSpinButton.interactable = false ;
        uiSpinButtonText.text = "Spinning" ;

        pickerWheel.OnSpinEnd (wheelPiece => {
            pickerWheel.audioSource.clip = pickerWheel.fanfareAudioClip ;
            pickerWheel.audioSource.PlayOneShot (pickerWheel.audioSource.clip);
            result.text = wheelPiece.Label;
            StartCoroutine("Waiter");
            Debug.Log (
                @" <b>Index:</b> " + wheelPiece.Index + "           <b>Label:</b> " + wheelPiece.Label
                + "\n <b>Amount:</b> " + wheelPiece.Amount + "      <b>Chance:</b> " + wheelPiece.Chance + "%"
            ) ;

            uiSpinButton.interactable = true ;
            uiSpinButtonText.text = "Spin" ;
        }) ;
        result.text = "";
        pickerWheel.Spin () ;
}

public void RemoveText(){
    result.text = "";
}

IEnumerator Waiter(){
    yield return new WaitForSeconds(6);
    if(result.text != ""){
        RemoveText();
    }
}

void Start()
{
 
}

}
