using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    public Text dialogue;
    public Image avatar;
    public Sprite mainCharacter;
    public Sprite staff;
    public GameObject box;
    int frame;


	// Use this for initialization
	void Start () {
        box.SetActive(false);
        frame = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (frame <= 300)
            frame++;
	}

    IEnumerator DialogueCoroutine(string s, bool pause)
    {
        if(pause)
            Time.timeScale = 0;

        box.SetActive(true);

        int i;
        String[] substrings = s.Split(';');
        foreach (var substring in substrings)
        {
            String[] subsubstrings = substring.Split('-');

            //set the avatar
            Int32.TryParse(subsubstrings[0], out i);

            switch (i)
            {
                case 0:
                    avatar.sprite = null;
                    break;
                case 1:
                    avatar.sprite = mainCharacter;
                    break;
                case 2:
                    avatar.sprite = staff;
                    break;
                default:
                    break;
            }

            //set the dialogue
            dialogue.text = subsubstrings[1];

            yield return new WaitUntil(() => Input.GetKeyDown("e"));
            yield return new WaitUntil(() => Input.GetKeyUp("e"));
          

        }
        box.SetActive(false);
        if(pause)
            Time.timeScale = 1;
        yield return null;
    }


    public void SetDialogue(string s, bool pause)
    {

        StartCoroutine(DialogueCoroutine(s, pause));

    }


}
