using UnityEngine;
using System.Collections;

public class DrawPaths: MonoBehaviour {

    public LineRenderer linerenderer;

    public GameObject[] objs;

    public Vector3 initial;
    public Vector3 final;
    public Vector3[] vectors;

    // Use this for initialization
    void Start () {

        /*initial = GameObject.Find("Square 1").transform.position;
        final = GameObject.Find("Square 2").transform.position;

        vectors = new Vector3[2];
        vectors[0] = initial;
        vectors[1] = final;

        linerenderer = gameObject.AddComponent<LineRenderer>();
        linerenderer.SetVertexCount(2);
        linerenderer.SetPositions(vectors);*/
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            objs = GameObject.FindGameObjectsWithTag("Vertex");

            foreach (GameObject obj in objs)
            {
                foreach(GameObject obj2 in obj.GetComponent<Vertex>().neighbors)
                {
                    GameObject lineobj = new GameObject("Linha massa :B");
                    lineobj.AddComponent<LineRenderer>();
                    LineRenderer line = lineobj.GetComponent<LineRenderer>();
                    Material mat = Resources.Load("Arrow", typeof(Material)) as Material;

                    line.GetComponent<Renderer>().material = mat;
                    line.GetComponent<Renderer>().transform.Rotate(Vector3.right * Time.deltaTime * 60);
                    line.SetWidth(0.5f, 0.5f);
                    line.SetVertexCount(2);
                    line.SetPosition(0, obj.transform.position);
                    line.SetPosition(1, obj2.transform.position);
                }
            }
        }
    }
}