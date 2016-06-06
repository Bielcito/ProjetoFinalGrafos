using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dijkstra : MonoBehaviour {

    public GameObject initialVertex = null;
    public GameObject finalVertex = null;
    public bool isButtonInitialPressed;
    public bool isButtonFinalPressed;
    public struct dist
    {
        public GameObject obj;
        public int valor;
        public GameObject prev;
        public bool isRemoved;
    }

    public List<dist> Q;

	// Use this for initialization
	void Start () {
}
	
	// Update is called once per frame
	void Update ()
    {
	
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

    public void printDijkstraPath()
    {
        foreach(GameObject x in executeDijkstra())
        {
            print(x);
        }
    }

    public List<GameObject> executeDijkstra()
    {
        Q = new List<dist>();

        if (initialVertex == null || finalVertex == null)
        {

            return null;
        }


        //Criação da array com os vértices e inicialização dos campos:
        foreach (GameObject x in GameObject.FindGameObjectsWithTag("Vertex"))
        {
            dist aux;

            aux.obj = x;
            aux.valor = int.MaxValue;
            aux.prev = null;
            aux.isRemoved = false;

            Q.Add(aux);
        }

        //Distância do destino para o destino deve ser nula:
        int i = Q.FindIndex(p => p.obj == initialVertex);
        dist aux2;
        aux2 = Q[i];
        aux2.valor = 0;
        Q[i] = aux2;
        int index = 0;

        //Até aqui é certeza de que tá pegando.

        while (Q.FindAll(p => p.isRemoved).Count != Q.Count)
        {
            //Pega o vértice com a menor distância em Q:
            dist min = new dist();
            int pos = 0;
            min.valor = int.MaxValue;
            foreach (dist u in Q)
            {
                if(u.isRemoved == true)
                {
                    continue;
                }
                if (u.valor < min.valor)
                {
                    min.valor = u.valor;
                    pos = Q.FindIndex(a => a.obj == u.obj);
                }
            }
            dist pivo = Q[pos];
            dist asd = Q[pos];
            asd.isRemoved = true;

            if(pivo.obj == finalVertex)
            {
                //Retorna o caminho de vertices:
                dist aux = pivo;
                List<GameObject> caminho = new List<GameObject>();
                while(true)
                {
                    caminho.Add(aux.obj);
                    if(aux.prev != null)
                    {
                        aux = Q.Find(p => p.obj == aux.prev);
                    }
                    else
                    {
                        break;
                    }
                }

                return caminho;
            }

            Q[pos] = asd;

            foreach (Vertex.neighbor v in pivo.obj.GetComponent<Vertex>().neighbors)
            {
                if(Q.Find(p => p.obj == v.obj).isRemoved == false)
                {
                    int alt = Q.Find(p => p.obj == pivo.obj).valor + v.valor;
                    if (alt < Q.Find(p => p.obj == v.obj).valor)
                    {
                        index = Q.FindIndex(p => p.obj == v.obj);
                        dist aux;
                        aux = Q[index];
                        aux.valor = alt;
                        aux.prev = pivo.obj;
                        Q[index] = aux;
                    }
                }
            }
        }
        return null;
    }
}
