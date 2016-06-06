using UnityEngine;
using System.Collections;

public class DecisionTree : MonoBehaviour {

	public GameObject vertex;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void executeTree()
	{
		player = GameObject.Find("Player");
		vertex = player.GetComponent<PlayerStatus> ().onVertex;

		if (player.GetComponent<PlayerStatus> ().life < 100*0.3f) 
		{
            int i = 0;
			foreach (Vertex.neighbor x in vertex.GetComponent<Vertex>().neighbors) 
			{
				if (x.obj.GetComponent<Vertex>().monster) 
				{
                    Vertex.neighbor aux;
                    aux.obj = x.obj;
                    aux.valor = x.valor + 5;
                    vertex.GetComponent<Vertex>().neighbors[i] = aux;
				}
                i += 1;
			}
		}

		else 
		{
			if (player.GetComponent<PlayerStatus> ().Imlate) 
			{
				//do nothing
			} 
			else 
			{
                int i = 0;
                foreach (Vertex.neighbor x in vertex.GetComponent<Vertex>().neighbors)
                {
                    if (x.obj.GetComponent<Vertex>().coin)
                    {
                        Vertex.neighbor aux;
                        aux.obj = x.obj;
                        aux.valor = x.valor + 5;
                        vertex.GetComponent<Vertex>().neighbors[i] = aux;
                    }
                    i += 1;
                }
            }
		}
	}
}
