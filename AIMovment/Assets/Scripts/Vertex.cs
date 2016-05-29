using UnityEngine;
using System.Collections;

public class Vertex : MonoBehaviour {

    public Vector3 position;
    public ArrayList neighbors;
    public GameObject PathCreator;

    // Pega a posição inicial do objeto ao qual o scrip está acoplado e salva em position:
    void Start () {
        PathCreator = GameObject.Find("PathCreator");
        neighbors = new ArrayList();
    }
	
	// Update is called once per frame
	void Update () {
        position = gameObject.transform.position;
    }

    public void OnMouseDown()
    {
        if(PathCreator.GetComponent<Dijkstra>().isButtonInitialPressed != true && PathCreator.GetComponent<Dijkstra>().isButtonFinalPressed != true)
        {
            PathCreator.GetComponent<MouseCatch>().PassObject(gameObject);
        }
        else if(PathCreator.GetComponent<Dijkstra>().isButtonInitialPressed == true)
        {
            PathCreator.GetComponent<Dijkstra>().selectInitialVertex(gameObject);
        }
        else if(PathCreator.GetComponent<Dijkstra>().isButtonFinalPressed == true)
        {
            PathCreator.GetComponent<Dijkstra>().selectFinalVertex(gameObject);
        }
    }

    public void addNeighbor(GameObject obj)
    {
        if (neighbors.Contains(obj))
        {
            print("Objeto já existe aqui! :(");
        }
        else
        {
            neighbors.Add(obj);
            print("Objeto " + obj.name + " Adicionado.");
        }
    }
}
