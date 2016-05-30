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

    public void executeDijkstra()
    {
        Q = new List<dist>();
        if (initialVertex == null || finalVertex == null)
        {
            return;
        }


        //Criação da array com os vértices e inicialização dos campos:
        foreach (GameObject x in GameObject.FindGameObjectsWithTag("Vertex"))
        {
            dist aux;

            aux.obj = x;
            aux.valor = int.MaxValue;
            aux.prev = null;

            Q.Add(aux);
        }

        //Distância do destino para o destino deve ser nula:
        int i = Q.FindIndex(p => p.obj == initialVertex);
        dist aux2;
        aux2 = Q[i];
        aux2.valor = 0;
        Q[i] = aux2;

        while(Q.Count > 0)
        {
            //Pega o vértice com a menor distância em Q:
            dist min = new dist();
            min.valor = int.MaxValue;
            foreach (dist u in Q)
            {
                if (u.valor < min.valor)
                {
                    min = u;
                }
            }
            print("O menor vértice é: " + min.obj + min.valor);
            Q.Remove(min);

            foreach (Vertex.neighbor v in min.obj.GetComponent<Vertex>().neighbors)
            {
                int alt = Q.Find(p => p.obj == min.obj).valor + v.valor;
                if(alt < Q.Find(p => p.obj == v.obj).valor)
                {

                }
            }

            break;
        }

    }
}
