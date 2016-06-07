using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DrawPaths: MonoBehaviour {

    public LineRenderer linerenderer;

    public GameObject[] objs;

    public Vector3 initial;
    public Vector3 final;
    public Vector3[] vectors;
    public GameObject textobj;

    struct neighbor
    {
        public GameObject obj;
        public int valor;
    }

    void Start () {

    }


    // Update is called once per frame
    void Update ()
    {
    }

    public void deleteLines()
    {
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");

        foreach(GameObject l in lines)
        {
            Destroy(l);
        }
    }

    public void deleteTexts()
    {
        GameObject[] valors = GameObject.FindGameObjectsWithTag("Valor");

        foreach(GameObject v in valors)
        {
            Destroy(v);
        }
    }

    public void printValor(Vector3 a, Vector3 b, int valor)
    {
        Vector3 result = (b - a) / 2;

        GameObject aux = Resources.Load("Text", typeof(GameObject)) as GameObject;
        textobj = GameObject.Instantiate(aux);
        textobj.transform.SetParent(GameObject.Find("Buttons").transform);
        textobj.transform.localScale = new Vector3(1, 1, 1);
        textobj.GetComponent<Text>().text = valor.ToString();
        textobj.GetComponent<Text>().color = Color.blue;
        textobj.GetComponent<Text>().fontStyle = FontStyle.Bold;
        textobj.transform.position = b - result;
    }

    public void drawLines()
    {
        deleteLines();
        deleteTexts();
        objs = GameObject.FindGameObjectsWithTag("Vertex");

        foreach (GameObject obj in objs)
        {
            foreach (Vertex.neighbor obj2 in obj.GetComponent<Vertex>().neighbors)
            {
                GameObject lineobj = new GameObject("Linha massa :B");
                lineobj.tag = "Line";
                lineobj.AddComponent<LineRenderer>();
                LineRenderer line = lineobj.GetComponent<LineRenderer>();
                Material mat = Resources.Load("Arrow", typeof(Material)) as Material;

                line.GetComponent<Renderer>().material = mat;
                line.SetWidth(0.5f, 0.5f);
                line.SetVertexCount(2);
                line.SetPosition(0, obj.transform.position);
                line.SetPosition(1, obj2.obj.transform.position);
                printValor(obj.transform.position, obj2.obj.transform.position, obj2.valor);
            }
        }
    }
}