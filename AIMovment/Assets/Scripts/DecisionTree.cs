using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DecisionTree : MonoBehaviour {

	public GameObject vertex;
	public GameObject player;
    public bool isAddMonsterButtonClicked = false;
    public bool isAddCoinButtonClicked = false;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void AddMonsterButtonClicked()
    {
        isAddMonsterButtonClicked = true;
    }

    public void AddCoinButtonClicked()
    {
        isAddCoinButtonClicked = true;
    }

	public void executeTree()
	{
		vertex = player.GetComponent<PlayerStatus>().onVertex;

        if (vertex.GetComponent<Vertex>().isHaveMonster)
        {
            player.GetComponent<PlayerStatus>().life -= 40;
        }
        if (vertex.GetComponent<Vertex>().isHaveCoin)
        {
            player.GetComponent<PlayerStatus>().score += 10;
        }

        if (player.GetComponent<PlayerStatus>().life < 30) 
		{
            Vertex.neighbor x;
            for (int i = 0; i < vertex.GetComponent<Vertex>().neighbors.Count; i++)
            {
                x = vertex.GetComponent<Vertex>().neighbors[i];
                if(x.obj.GetComponent<Vertex>().isHaveMonster == true)
                {
                    Vertex.neighbor aux;
                    aux.obj = x.obj;
                    aux.valor = x.valor + 5;
                    vertex.GetComponent<Vertex>().neighbors[i] = aux;
                }
            }
		}
		else 
		{
			if (player.GetComponent<PlayerStatus>().Imlate) 
			{
				//do nothing
			} 
			else 
			{
                bool att = false;
                Vertex.neighbor x;
                List<int> notcoinsindexes = new List<int>();
                for (int i = 0; i < vertex.GetComponent<Vertex>().neighbors.Count; i++)
                {
                    x = vertex.GetComponent<Vertex>().neighbors[i];
                    if (x.obj.GetComponent<Vertex>().isHaveCoin == true)
                    {
                        att = true;
                    }
                    else
                    {
                        notcoinsindexes.Add(i);
                    }
                }
                if(att)
                {
                    print("HEHEHEHE");
                    foreach(int i in notcoinsindexes)
                    {
                        x = vertex.GetComponent<Vertex>().neighbors[i];
                        Vertex.neighbor aux;
                        aux.obj = x.obj;
                        aux.valor = x.valor + 5;
                        vertex.GetComponent<Vertex>().neighbors[i] = aux;
                    }
                }
            }
		}
	}
}
