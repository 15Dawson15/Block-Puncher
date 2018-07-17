using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEmitter : MonoBehaviour {

    public GameObject player;
    public GameObject block;
    public GameObject controller;
    public GameObject scoreText;
    public float timer;
    public float elapsedTime = 0.0f;
    private bool switchText = false;
    private InstructionBlockDestroy startGame;
    private int scoreCounter;
    private Scoring score;

    // Materials
    public Material green;
    public Material blue;
    public Material red;
    public Material orange;

    //public Transform blockEmitTransform;


    // Use this for initialization
    void Start () {
        startGame = controller.GetComponent<InstructionBlockDestroy>();
        scoreCounter = controller.GetComponent<BlockCollision>().GetScoreCount();
        score = scoreText.GetComponent<Scoring>();
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

        elapsedTime += Time.deltaTime;

		if(elapsedTime > timer)
        {
            GameObject objToSpawn = block;
            elapsedTime = 0;

            Vector3 position = RandomPosition();

            objToSpawn.GetComponent<Renderer>().material = RandomMaterial(position.x);

            Instantiate(objToSpawn, position, new Quaternion(0, 0, 0, 0));
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
