using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MouseCatch : MonoBehaviour {

    public bool started = false;
    public GameObject initial;
    public GameObject final;
    public GameObject input;

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
            showinput();
            started = false;
        }
    }

    public void showinput()
    {
        GameObject aux = Resources.Load("Input", typeof(GameObject)) as GameObject;
        input = GameObject.Instantiate(aux);

        input.transform.SetParent(GameObject.Find("Canvas").transform);
        input.transform.localScale = new Vector3(1, 1, 1);
        input.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void createPath(int valor)
    {
        print(valor);
        initial.GetComponent<Vertex>().addNeighbor(final, valor);
        gameObject.GetComponent<DrawPaths>().drawLines();
    }



    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (input.GetComponent<InputField>().isFocused == true)
            {
                string textvalor = input.GetComponent<InputField>().text;
                createPath(int.Parse(textvalor));
                Destroy(input);
            }
        }
    }
}
