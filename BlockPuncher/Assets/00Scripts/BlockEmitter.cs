using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEmitter : MonoBehaviour {

    public GameObject player;
    public GameObject block;
    public GameObject controller;
    public GameObject scoreText;
    public GameObject blockDestroyer;

    public float timer;

    private float elapsedTime = 0.0f;

    private bool switchText;
    private bool start;
    private bool endGame;

    private InstructionBlockDestroy startGame;

    private int scoreCounter;
    private int waveNumber;

    private Scoring score;

    private string handPosition;

    // Materials
    public Material green;
    public Material blue;
    public Material red;
    public Material orange;

    //public Transform blockEmitTransform;


    // Use this for initialization
    void Start () {
        waveNumber = 1;
        startGame = controller.GetComponent<InstructionBlockDestroy>();
        scoreCounter = controller.GetComponent<BlockCollision>().GetScoreCount();
        score = scoreText.GetComponent<Scoring>();
        start = true;
        switchText = false;
        endGame = false;
    }

	// Update is called once per frame
	void Update () {

        if (startGame.GetStartGame() != false)
        {
            return;
        }

        scoreCounter = controller.GetComponent<BlockCollision>().GetScoreCount();
        score.SetCurrentScore(scoreCounter);

        switchText = true;

        if (start == true && endGame == false)
        {
            GameObject objToSpawn = block;

            //Wave selection TODO: Make this into a method so there isn't this clutter here
            if (waveNumber == 1 && GetComponent<Waves>().GetMaxBlocks() >= 0)
            {
                Debug.Log("Inside Wave One in Update");
                objToSpawn.GetComponent<BlockMovement>().speed = GetComponent<Waves>().GetSpeed();
                timer = 1f;
            }
            if (waveNumber == 2 && GetComponent<Waves>().GetMaxBlocks() >= 0)
            {
                Debug.Log("Inside Wave two in update");
                objToSpawn.GetComponent<BlockMovement>().speed = GetComponent<Waves>().GetSpeed();
            }
            if (waveNumber == 3 && GetComponent<Waves>().GetMaxBlocks() >= 0)
            {
                Debug.Log("Inside wave three in update");
                objToSpawn.GetComponent<BlockMovement>().speed = GetComponent<Waves>().GetSpeed();
                timer = .5f;
            }
            if (waveNumber == 4 && GetComponent<Waves>().GetMaxBlocks() >= 0)
            {
                Debug.Log("Inside wave four in update");
                objToSpawn.GetComponent<BlockMovement>().speed = GetComponent<Waves>().GetSpeed();
                blockDestroyer.transform.position = new Vector3(0f, 0f, 1f);
            }
            if (waveNumber == 5 && GetComponent<Waves>().GetMaxBlocks() >= 0)
            {
                Debug.Log("Inside wave five in update");
                objToSpawn.GetComponent<BlockMovement>().speed = GetComponent<Waves>().GetSpeed();
                blockDestroyer.transform.position = new Vector3(0f, 0f, -1f);
            }

            elapsedTime += Time.deltaTime;

            if (elapsedTime > timer)
            {
                elapsedTime = 0;

                Vector3 position = RandomPosition();

                objToSpawn.GetComponent<Renderer>().material = RandomMaterial(handPosition);
                objToSpawn.GetComponent<BlockMovement>().speed = GetComponent<Waves>().GetSpeed();

                Instantiate(objToSpawn, position, new Quaternion(0, 0, 0, 0));
                GetComponent<Waves>().SubMaxBlocks();
            }
        }
        if(GetComponent<Waves>().GetMaxBlocks() <= 0)
        {
            start = false;
            waveNumber += 1;
            switch (waveNumber)
            {
                case 1:
                    GetComponent<Waves>().WaveOne();
                    break;
                case 2:
                    GetComponent<Waves>().WaveTwo();
                    break;
                case 3:
                    GetComponent<Waves>().WaveThree();
                    break;
                case 4:
                    GetComponent<Waves>().WaveFour();
                    break;
                case 5:
                    GetComponent<Waves>().WaveFive();
                    break;
                default:
                    endGame = true;
                    break;
            }
        }



        if(start == false && GameObject.Find("Block(Clone)") == null)
        {
            start = true;
        }
	}

    public bool GetSwitchText()
    {
        return switchText;
    }

    private Vector3 RandomPosition()
    {
        float xPosition;
        if (waveNumber < 4)
        {
            int x = Random.Range(0, 2);
            if (x == 0)
            {
                xPosition = -.5f;
                handPosition = "Left";
            }
            else
            {
                xPosition = .5f;
                handPosition = "Right";
            }
        }
        else if(waveNumber == 4)
        {
            int x = Random.Range(0, 2);
            if (x == 0)
            {
                xPosition = -.5f;
                handPosition = "Right";
            }
            else
            {
                xPosition = .5f;
                handPosition = "Left";
            }
        }
        else
        {
            float x = Random.Range(-1.0f, 1.0f);
            if (x < 0)
            {
                xPosition = x;
                handPosition = "Left";
            }
            else
            {
                xPosition = x;
                handPosition = "Right";
            }
        }
            int y = Random.Range(0, 3);
            float yPosition;

        switch (y)
        {
            case 0:
                yPosition = player.transform.position.y - .3f;
                break;

            case 1:
                yPosition = player.transform.position.y;
                break;

            default:
                yPosition = player.transform.position.y + .3f;
                break;
        }

        return new Vector3(xPosition, yPosition, this.transform.position.z);
    }

    private Material RandomMaterial(string handPosition)//float xPosition
    {
        int ranColor = Random.Range(0,2);
        if(handPosition.Equals("Left"))// == -.5f)
        {
            if(ranColor == 0)
            {
                return red;
            }
            else
            {
                return orange;
            }
        }
        else
        {
            if(ranColor == 0)
            {
                return green;
            }
            else
            {
                return blue;
            }
        }
    }
}
