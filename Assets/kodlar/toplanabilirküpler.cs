using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toplanabilirküpler : MonoBehaviour
{
    // Start is called before the first frame update
    bool collection_control;
    int index;
    public toplayıcı toplayici;
    void Start()
    {
        collection_control = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(collection_control == true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "engel")
        {
            toplayici.heightdecrase();
            transform.parent = null;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            //Destroy(this.gameObject);
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

        }
    }
    public bool Gettoplandimi()
    {
        return collection_control;
    }
    public void make_collection()
    {
        collection_control = true;
    }

    public void indexayarla(int index)
    {
       this.index = index;
    }
}
