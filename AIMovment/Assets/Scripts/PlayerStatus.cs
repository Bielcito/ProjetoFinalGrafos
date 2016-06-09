using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

	public int life;
    public bool Imlate;
	public GameObject onVertex;
	public int score;

    public float speed = 0.1f;
    public GameObject toVertex;
    public Vector3 initialDistance;
    public float contador;

    // Use this for initialization
    void Start () {
        life = 100;
        Imlate = false;
	}

    public void startChangeVertex(GameObject obj)
    {
        onVertex = obj;
        contador = 100;
        toVertex = obj;
        initialDistance = (toVertex.transform.position - transform.position) / 100;
    }
	
	// Update is called once per frame
	void Update () {
        if(toVertex && contador > 0)
        {
            transform.position = new Vector3(transform.position.x + initialDistance.x, transform.position.y + initialDistance.y, transform.position.z);
            contador--;
        }
        else
        {
            toVertex = null;
        }
	}
}
