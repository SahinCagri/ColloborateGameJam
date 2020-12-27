using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batik : MonoBehaviour
{
    public GameObject Tekne;
    public float X1, X2,Y,Z1,Z2;
    public float speed;
    GameObject tekne;
    int a;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        a = Random.Range(0, 2);
        if( a == 0)
        {
            tekne = Instantiate(Tekne, new Vector3(X1, Y, Random.Range(Z1, Z2)), Tekne.transform.rotation);
            x = X1;
        }
        if (a == 1)
        {
            tekne = Instantiate(Tekne, new Vector3(X2, Y, Random.Range(Z1, Z2)), Tekne.transform.rotation);
            x = X2;
        }
        //tekne=Instantiate(Tekne, new Vector3(Random.Range(X1, X2), Y, Random.Range(Z1, Z2)),Quaternion.identity);    
    }

    // Update is called once per frame
    void Update()
    {
        if (a == 0)
        {
            x += Time.deltaTime * speed;
            tekne.transform.position = new Vector3(x, tekne.transform.position.y, tekne.transform.position.z);
        }
        if (a == 1)
        {
            x -= Time.deltaTime * speed;
            tekne.transform.position = new Vector3(x, tekne.transform.position.y, tekne.transform.position.z);
        }
    }
}
