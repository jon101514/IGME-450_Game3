﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum Character { Johnny, Jonathan, Lobster };

public class CharacterSelector : MonoBehaviour {

    // Accessing the input manager to keep related code here
    // intended to keep the InputManager script cleaner
    public GameObject inputManager;

    // for managing which ui is visible
    public GameObject CharacterSelect;
    public GameObject InGame;

    // music
    public GameObject music;

    // background
    public GameObject background;
    public GameObject chairs;
    public GameObject lights;

    // sprite arrays divided by character
    public Sprite[] JB; // Johnny Bravo
    public Sprite[] JC; // Jonathan Congratulations
	public Sprite[] LS; // Lobster

    // these arrays contain the images presenting the player on-screen
    public GameObject[] p1;
    public GameObject[] p2;

    // the actual player objects for storing the sprites at the end
    public GameObject[] player1;
    public GameObject[] player2;

    // for keeping track of which character is being represented
    private Character p1Character;
    private Character p2Character;

    // to make input taking quick
    private InputManager input;

    private bool p1CanChange = true, p2CanChange = true;

    // for leaving character select
    private bool p1Confirm;
    private bool p2Confirm;

	// Use this for initialization
	void Start ()
    {
        p1Character = Character.Johnny;
        p2Character = Character.Jonathan;
        input = inputManager.GetComponent<InputManager>();
        p1Confirm = false;
        p2Confirm = false;
        Color gray = new Color(138, 138, 138);
        background.GetComponent<SpriteRenderer>().color = gray;
        chairs.GetComponent<SpriteRenderer>().color = gray;
        lights.GetComponent<SpriteRenderer>().color = gray;
		p1CanChange = true;
		p2CanChange = true;
	}

	private IEnumerator Cooldown(int player) {
		if (player == 1) {
			p1CanChange = false;
		} else {
			p2CanChange = false;
		}
		yield return new WaitForSeconds(0.25f);
		p1CanChange = true;
		p2CanChange = true;
	}

    // Update is called once per frame
    void Update()
    {
        if (CharacterSelect.GetComponent<Canvas>().enabled)
        {
            // code for cycling the characters
            if (Input.GetKeyDown(input.p1Right) || (input.p1leftRight == 1 && p1CanChange))
            {
                switch (p1Character)
                {
                    case (Character.Johnny):
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                p1[i].GetComponent<Image>().sprite = JC[i];
                            }
                            p1Character++;
                            StartCoroutine(Cooldown(1));
                            break;
                        }
                    case (Character.Jonathan):
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                p1[i].GetComponent<Image>().sprite = LS[i];
                            }
                            p1Character++;
						StartCoroutine(Cooldown(1));
                            break;
                        }
                    case (Character.Lobster):
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                p1[i].GetComponent<Image>().sprite = JB[i];
                            }
                            p1Character++;
						StartCoroutine(Cooldown(1));
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                if (p1Character > Character.Lobster) { p1Character = Character.Johnny; }
            }
			if (Input.GetKeyDown(input.p1Left) || (input.p1leftRight == -1 && p1CanChange))
            {
                switch (p1Character)
                {
                    case (Character.Johnny):
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                p1[i].GetComponent<Image>().sprite = LS[i];
                            }
                            p1Character--;
						StartCoroutine(Cooldown(1));
                            break;
                        }
                    case (Character.Jonathan):
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                p1[i].GetComponent<Image>().sprite = JB[i];
                            }
                            p1Character--;
						StartCoroutine(Cooldown(1));
                            break;
                        }
                    case (Character.Lobster):
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                p1[i].GetComponent<Image>().sprite = JC[i];
                            }
                            p1Character--;
						StartCoroutine(Cooldown(1));
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                if (p1Character < Character.Johnny) { p1Character = Character.Lobster; }
            }
			if (Input.GetKeyDown(input.p2Right) || (input.p2leftRight == 1 && p2CanChange))
            {
                switch (p2Character)
                {
                    case (Character.Johnny):
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                p2[i].GetComponent<Image>().sprite = JC[i];
                            }
                            p2Character++;
						StartCoroutine(Cooldown(2));
                            break;
                        }
                    case (Character.Jonathan):
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                p2[i].GetComponent<Image>().sprite = LS[i];
                            }
                            p2Character++;
						StartCoroutine(Cooldown(2));
                            break;
                        }
                    case (Character.Lobster):
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                p2[i].GetComponent<Image>().sprite = JB[i];
                            }
                            p2Character++;
						StartCoroutine(Cooldown(2));
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                if (p2Character > Character.Lobster) { p2Character = Character.Johnny; }
            }
			if (Input.GetKeyDown(input.p2Left) || (input.p2leftRight == -1 && p2CanChange))
            {
                switch (p2Character)
                {
                    case (Character.Johnny):
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                p2[i].GetComponent<Image>().sprite = LS[i];
                            }
                            p2Character--;
						StartCoroutine(Cooldown(2));
                            break;
                        }
                    case (Character.Jonathan):
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                p2[i].GetComponent<Image>().sprite = JB[i];
                            }
                            p2Character--;
						StartCoroutine(Cooldown(2));
                            break;
                        }
                    case (Character.Lobster):
                        {
                            for(int i = 0; i < 5; i++)
                            {
                                p2[i].GetComponent<Image>().sprite = JC[i];
                            }
                            p2Character--;
						StartCoroutine(Cooldown(2));
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                if (p2Character < Character.Johnny) { p2Character = Character.Lobster; }
            }

            // code to leave character select
            if (Input.GetKeyDown(input.p1loArmAdd) || Input.GetKeyDown(input.p1loArmSub) || Input.GetKeyDown(input.p1upArmAdd) || Input.GetKeyDown(input.p1upArmSub))
            {
                p1Confirm = true;
            }
            if (Input.GetKeyDown(input.p2loArmAdd) || Input.GetKeyDown(input.p2loArmSub) || Input.GetKeyDown(input.p2upArmAdd) || Input.GetKeyDown(input.p2upArmSub))
            {
                p2Confirm = true;
            }
            if (p1Confirm && p2Confirm)
            {
                // deactivates character select and activates in-game ui
                CharacterSelect.GetComponent<Canvas>().enabled = false;
                InGame.GetComponent<Canvas>().enabled = true;

                for (int i = 0; i < 5; i++)
                {
                    player1[i].GetComponent<SpriteRenderer>().sprite = p1[i].GetComponent<Image>().sprite;
                    player2[i].GetComponent<SpriteRenderer>().sprite = p2[i].GetComponent<Image>().sprite;

                    player1[i].GetComponent<SpriteRenderer>().enabled = true;
                    player2[i].GetComponent<SpriteRenderer>().enabled = true;
                }

                background.GetComponent<SpriteRenderer>().color = Color.white;
                chairs.GetComponent<SpriteRenderer>().color = Color.white;
                lights.GetComponent<SpriteRenderer>().color = Color.white;

                music.GetComponent<AudioSource>().Play();

                input.GameStart();                
            }
        }
    }
}
