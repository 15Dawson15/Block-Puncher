using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEmitter : MonoBehaviour {

    public GameObject player;
    public GameObject block;
    public GameObject controller;
    public GameObject scoreText;
    public float timer;
    private float elapsedTime = 0.0f;
    private bool switchText = false;
    private bool start;
    private InstructionBlockDestroy startGame;
    private int scoreCounter;
    private int waveNumber;
    private Scoring score;

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
    }

	// Update is called once per frame
	void Update () {

        if (startGame.GetStartGame() != true)
        {
            return;
        }

        scoreCounter = controller.GetComponent<BlockCollision>().GetScoreCount();
        score.SetCurrentScore(scoreCounter);

        switchText = true;

        if (start == true)
        {
            GameObject objToSpawn = block;

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

            elapsedTime += Time.deltaTime;

            if (elapsedTime > timer)
            {
                elapsedTime = 0;

                Vector3 position = RandomPosition();

                objToSpawn.GetComponent<Renderer>().material = RandomMaterial(position.x);
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
        int x = Random.Range(0, 2);
        float xPosition;
        if(x == 0)
        {
            xPosition = -.5f;
        }
        else
        {
            xPosition = .5f;
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

    private Material RandomMaterial(float xPosition)
    {
        int ranColor = Random.Range(0,2);
        if(xPosition == -.5f)
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
