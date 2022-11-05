using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnClickEvents : MonoBehaviour
{
    [SerializeField] private TMP_Text _muteText;

    private void Start()
    {
        if(GameManager.Mute)
            _muteText.text = "/";
        else
            _muteText.text = "";
    }
    public void ToggleMute()
    {
        if(GameManager.Mute)
        {
            GameManager.Mute = false;
            _muteText.text = "";
        }
        else
        {
            GameManager.Mute = true;
            _muteText.text = "/";
        }
    }
   public void QuitGame()
    {
        Application.Quit();
    }
}
