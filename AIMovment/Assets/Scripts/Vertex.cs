using UnityEngine;
using System.Collections;

public class Vertex : MonoBehaviour {

    public Vector3 position;
    public ArrayList neighbors;
    public GameObject obj;

    // Pega a posição inicial do objeto ao qual o scrip está acoplado e salva em position:
    void Start () {
        obj = GameObject.Find("PathCreator");
        neighbors = new ArrayList();
    }
	
	// Update is called once per frame
	void Update () {
        position = gameObject.transform.position;
    }

    public void OnMouseDown()
    {
        obj.GetComponent<MouseCatch>().PassObject(gameObject);
    }

    public void addNeighbor(GameObject obj)
    {
        neighbors.Add(obj);
        print("Objeto " + obj.name + " Adicionado.");
    }
}
