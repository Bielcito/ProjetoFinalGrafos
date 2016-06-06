using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Vertex : MonoBehaviour {

    public Vector3 position;
    public bool monster;
    public bool coin;
    public GameObject textobj;

    //Um dos Vizinhos de mim:
    public struct neighbor
    {
        public GameObject obj;
        public int valor; //distância desse vértice para o vértice obj.
    }

    //Lista dos meus vizinhos
    public ArrayList neighbors;
    public GameObject PathCreator;

    // Pega a posição inicial do objeto ao qual o scrip está acoplado e salva em position:
    void Start () {
        PathCreator = GameObject.Find("PathCreator");
        neighbors = new ArrayList();
        printIndexes();
        refreshValorPosition();
    }
	
	// Update is called once per frame
	void Update () {
        position = gameObject.transform.position;
    }

    void printIndexes()
    {
        GameObject aux = Resources.Load("Text", typeof(GameObject)) as GameObject;
        textobj = GameObject.Instantiate(aux);
        textobj.transform.SetParent(GameObject.Find("Buttons").transform);
        textobj.transform.localScale = new Vector3(1, 1, 1);
        textobj.GetComponent<Text>().text = name;
        textobj.GetComponent<Text>().color = Color.black;
        textobj.GetComponent<Text>().fontStyle = FontStyle.Bold;
    }

    public void refreshValorPosition()
    {
        Vector3 v = gameObject.transform.position;
        v.Set(v.x, v.y - gameObject.GetComponent<CircleCollider2D>().radius - 0.1f, v.z);
        if(textobj)
        {
            textobj.transform.position = v;
            Invoke("refreshValorPosition", 1);
        }
    }

    public void OnMouseDown()
    {
        if(PathCreator.GetComponent<MouseCatch>().writing == true)
        {
            return;
        }
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

    public void addNeighbor(GameObject obj, int valor)
    {
        neighbor aux;

        aux.obj = obj;
        aux.valor = valor;

        bool tem = false;

        foreach(neighbor x in neighbors)
        {
            if (x.obj == aux.obj)
            {
                tem = true;
            }
        }

        if(tem == false)
        {
            neighbors.Add(aux);
        }
    }
}
