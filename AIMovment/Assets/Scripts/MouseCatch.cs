using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class MouseCatch : MonoBehaviour {

    public InputField.SubmitEvent submitEvent = new InputField.SubmitEvent();

    public bool started = false;
    public bool writing = false;
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
        writing = true;
        GameObject aux = Resources.Load("Input", typeof(GameObject)) as GameObject;
        input = GameObject.Instantiate(aux);

        input.transform.SetParent(GameObject.Find("Buttons").transform);
        input.transform.localScale = new Vector3(1, 1, 1);
        input.transform.localPosition = new Vector3(0, 0, 0);
        input.GetComponent<InputField>().onEndEdit = submitEvent;
        EventSystem.current.SetSelectedGameObject(input);
    }

    public void createPath(int valor)
    {
        initial.GetComponent<Vertex>().addNeighbor(final, valor);
        gameObject.GetComponent<DrawPaths>().drawLines();
    }



    // Use this for initialization
    void Start () {
        submitEvent.AddListener(SubmitName);
    }

    void SubmitName(string name)
    {
        createPath(int.Parse(name));
        writing = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(input)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                Destroy(input);
            }
        }
    }
}
