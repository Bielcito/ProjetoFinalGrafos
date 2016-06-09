using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Dijkstra : MonoBehaviour {

    public GameObject player;
    public GameObject initialVertex = null;
    public GameObject finalVertex = null;
    public GameObject textobj;
    public dist pivo;
    public bool isButtonInitialPressed = false;
    public bool isButtonFinalPressed = false;
    public bool isDijkstraAlreadyInitialized = false;
    List<GameObject> path;
    public struct dist
    {
        public GameObject obj;
        public int valor;
        public GameObject prev;
        public bool isRemoved;
    }

    public List<dist> Q;
    int index = 0;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void selectInitialVertex(GameObject obj)
    {
        if(initialVertex)
        {
            initialVertex.GetComponent<SpriteRenderer>().color = Color.white;
        }
        initialVertex = obj;
        initialVertex.GetComponent<SpriteRenderer>().color = Color.green;

        isButtonInitialPressed = false;
    }

    public void selectFinalVertex(GameObject obj)
    {
        if(finalVertex)
        {
            finalVertex.GetComponent<SpriteRenderer>().color = Color.white;
        }
        finalVertex = obj;
        finalVertex.GetComponent<SpriteRenderer>().color = Color.red;
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

    public bool isInitialAndFinalVertexesAlreadySet()
    {
        if (initialVertex == null || finalVertex == null)
        {
            if (textobj)
            {
                return false;
            }

            GameObject aux = Resources.Load("Text", typeof(GameObject)) as GameObject;
            textobj = GameObject.Instantiate(aux);
            textobj.name = "EHA!";
            textobj.transform.SetParent(GameObject.Find("Players").transform);
            textobj.transform.localScale = new Vector3(1, 1, 1);
            textobj.GetComponent<Text>().text = "É preciso especificar o vértice inicial e o final antes!";
            textobj.GetComponent<Text>().color = Color.red;
            textobj.GetComponent<Text>().fontStyle = FontStyle.Bold;
            textobj.GetComponent<Text>().horizontalOverflow = HorizontalWrapMode.Overflow;
            Vector3 v = textobj.transform.localPosition;
            v.Set(197, 148, 0);
            textobj.transform.localPosition = v;
            StartCoroutine(Tempo(textobj));
            return false;
        }
        else
        {
            return true;
        }
    }

    public void movePlayer()
    {
        StartCoroutine(movePlayerCoRoutine());
    }

    IEnumerator movePlayerCoRoutine()
    {
        GameObject x;
        for (int i = path.Count -1; i >= 0; i--)
        {
            x = path[i];
            player.GetComponent<PlayerStatus>().startChangeVertex(x);
            yield return new WaitForSeconds(2);
        }
    }

    public void printDijkstraPath()
    {
        if(!isDijkstraAlreadyInitialized)
        {
            if (!isInitialAndFinalVertexesAlreadySet())
            {
                return;
            }

            if (!dijkstraInitialization())
            {
                return;
            }

            isDijkstraAlreadyInitialized = true;
        }

        string frase = "";

        GetComponent<DecisionTree>().executeTree();
        path = doADijkstraLoop();
        if (path != null)
        {
            foreach (GameObject x in path)
            {
                frase += x.name + " ";
            }
            print(frase);
            movePlayer();
        }
    }

    IEnumerator Tempo(GameObject obj)
    {
        yield return new WaitForSeconds(3);
        Destroy(obj);
    }

    public bool dijkstraInitialization()
    {
        Q = new List<dist>();

        if (initialVertex == null || finalVertex == null)
        {

            return false;
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

        return true;
    }

    public List<GameObject> doADijkstraLoop()
    {
        if (Q.FindAll(p => p.isRemoved).Count != Q.Count)
        {
            if(pivo.obj)
            {
                if(pivo.obj == initialVertex)
                {
                    pivo.obj.GetComponent<SpriteRenderer>().color = Color.green;
                }
                else if(pivo.obj == finalVertex)
                {
                    pivo.obj.GetComponent<SpriteRenderer>().color = Color.red;
                }
                else
                {
                    pivo.obj.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }

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
            pivo = Q[pos];
            dist asd = Q[pos];
            asd.isRemoved = true;

            pivo.obj.GetComponent<SpriteRenderer>().color = Color.yellow;

                //Se for o finalVertex:
                if (pivo.obj == finalVertex)
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

            //Para cada um dos vizinhos 'v' do vértice atual:
            foreach (Vertex.neighbor v in pivo.obj.GetComponent<Vertex>().neighbors)
            {
                //Caso ele não tenha sido removido:
                if(Q.Find(p => p.obj == v.obj).isRemoved == false)
                {
                    //Atualiza a distância de 'v' caso seja menor que a distância já presente nele:
                    int alt = Q.Find(p => p.obj == pivo.obj).valor + v.valor;
                    if (alt < Q.Find(p => p.obj == v.obj).valor)
                    {
                        index = Q.FindIndex(p => p.obj == v.obj);
                        dist aux;
                        aux = Q[index];
                        aux.valor = alt;
                        aux.prev = pivo.obj;
                        Q[index] = aux;

                        print("mudei o vertice " + v.obj.name + " para o valor " + Q[index].valor);
                    }
                }
            }
        }
        return null;
    }
}
