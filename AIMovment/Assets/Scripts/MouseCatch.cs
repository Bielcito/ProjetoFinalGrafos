using UnityEngine;
using System.Collections;

public class MouseCatch : MonoBehaviour {

    public bool started = false;
    public GameObject initial;
    public GameObject final;

    public void PassObject(GameObject obj)
    {
        if(!started)
        {
            initial = obj;
            started = true;
        }
        else
        {
            final = obj;
            createPath();
            initial = null;
            final = null;
            started = false;
        }
    }

    public void createPath()
    {
        initial.GetComponent<Vertex>().addNeighbor(final);
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }
}
