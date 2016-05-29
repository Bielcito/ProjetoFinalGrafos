using UnityEngine;
using System.Collections;

public class Dijkstra : MonoBehaviour {

    public GameObject initialVertex;
    public GameObject finalVertex;
    public bool isButtonInitialPressed;
    public bool isButtonFinalPressed;
    public GameObject[] Q;

	// Use this for initialization
	void Start () {
        Q = GameObject.FindGameObjectsWithTag("Vertex");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void selectInitialVertex(GameObject obj)
    {
        initialVertex = obj;
        isButtonInitialPressed = false;
    }

    public void selectFinalVertex(GameObject obj)
    {
        finalVertex = obj;
        isButtonFinalPressed = false;
    }

    public void buttonInitialPressed()
    {
        isButtonInitialPressed = true;
    }

    public void buttonFinalPressed()
    {
        isButtonFinalPressed = true;
    }
}
