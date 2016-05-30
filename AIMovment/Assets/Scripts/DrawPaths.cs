using UnityEngine;
using System.Collections;

public class DrawPaths: MonoBehaviour {

    public LineRenderer linerenderer;

    public GameObject[] objs;

    public Vector3 initial;
    public Vector3 final;
    public Vector3[] vectors;

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

    public void drawLines()
    {
        deleteLines();
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
                line.GetComponent<Renderer>().transform.Rotate(Vector3.right * Time.deltaTime * 60);
                line.SetWidth(0.5f, 0.5f);
                line.SetVertexCount(2);
                line.SetPosition(0, obj.transform.position);
                line.SetPosition(1, obj2.obj.transform.position);
            }
        }
    }
}