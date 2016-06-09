using UnityEngine;
using System.Collections;

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
		vertex = player.GetComponent<PlayerStatus> ().onVertex;

		if (player.GetComponent<PlayerStatus> ().life < 30) 
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
                print("entrou aqui!");
                Vertex.neighbor x;
                for (int i = 0; i < vertex.GetComponent<Vertex>().neighbors.Count; i++)
                {
                    x = vertex.GetComponent<Vertex>().neighbors[i];
                    if (x.obj.GetComponent<Vertex>().isHaveCoin == true)
                    {
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
