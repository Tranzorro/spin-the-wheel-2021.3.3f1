using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowConnection : MonoBehaviour
{
    public TwitchChatManager twitch;
    public TMP_Text display;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        display.text = twitch.Connected.ToString();
    }
}
