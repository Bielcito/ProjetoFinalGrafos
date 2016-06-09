using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class Vertex : MonoBehaviour {

    public Vector3 position;
    public bool isHaveMonster;
    public bool isHaveCoin;
    public GameObject textobj;
    public GameObject monster;
    public GameObject coin;

    //Um dos Vizinhos de mim:
    public struct neighbor
    {
        public GameObject obj;
        public int valor; //distância desse vértice para o vértice obj.
    }

    //Lista dos meus vizinhos
    public List<neighbor> neighbors;
    public GameObject PathCreator;

    // Pega a posição inicial do objeto ao qual o scrip está acoplado e salva em position:
    void Start () {
        PathCreator = GameObject.Find("PathCreator");
        neighbors = new List<neighbor>();
        printIndexes();
        refreshValorPosition();
    }
	
	// Update is called once per frame
	void Update () {
        position = gameObject.transform.position;
    }

    public void AddMonster()
    {
        if(!monster)
        {
            GameObject aux = Resources.Load("Enemy", typeof(GameObject)) as GameObject;
            monster = GameObject.Instantiate(aux);
            monster.transform.SetParent(GameObject.Find("Players").transform);
            monster.transform.position = transform.position;
            monster.transform.localScale = new Vector3(13.5604f, 13.5604f, 13.5604f);
        }
    }

    void printIndexes()
    {
        GameObject aux = Resources.Load("Text", typeof(GameObject)) as GameObject;
        textobj = GameObject.Instantiate(aux);
        textobj.tag = "Name";
        textobj.transform.SetParent(GameObject.Find("Buttons").transform);
        textobj.transform.localScale = new Vector3(1, 1, 1);
        textobj.GetComponent<Text>().text = name;
        textobj.GetComponent<Text>().color = Color.magenta;
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
        if (PathCreator.GetComponent<Dijkstra>().isButtonInitialPressed == true)
        {
            PathCreator.GetComponent<Dijkstra>().selectInitialVertex(gameObject);
            GameObject.Find("Player").GetComponent<PlayerStatus>().startChangeVertex(gameObject);
            GameObject.Find("Player").GetComponent<PlayerStatus>().onVertex = gameObject;
        }
        else if (PathCreator.GetComponent<Dijkstra>().isButtonFinalPressed == true)
        {
            PathCreator.GetComponent<Dijkstra>().selectFinalVertex(gameObject);
        }
        else if (PathCreator.GetComponent<DecisionTree>().isAddMonsterButtonClicked == true)
        {
            if(isHaveMonster)
            {
                isHaveMonster = false;
            }
            else
            {
                isHaveMonster = true;
                AddMonster();
            }

            PathCreator.GetComponent<DecisionTree>().isAddMonsterButtonClicked = false;
        }
        else if (PathCreator.GetComponent<DecisionTree>().isAddCoinButtonClicked == true)
        {
            if (isHaveCoin)
            {
                isHaveCoin = false;
            }
            else
            {
                isHaveCoin = true;
                AddCoin();
            }

            PathCreator.GetComponent<DecisionTree>().isAddCoinButtonClicked = false;
        }
        else
        {
            PathCreator.GetComponent<MouseCatch>().PassObject(gameObject);
        }
    }

    public void AddCoin()
    {
        if(!coin)
        {
            GameObject aux = Resources.Load("Hearth", typeof(GameObject)) as GameObject;
            coin = GameObject.Instantiate(aux);
            coin.transform.SetParent(GameObject.Find("Players").transform);
            coin.transform.position = transform.position;
            coin.transform.localScale = new Vector3(4.82644f, 4.82644f, 0);
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
