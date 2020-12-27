using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public float Speed;
    public int Situation;
    MeshRenderer meshRenderer;
    float Zposition;
    private float time = 0;
    
    private MaterialPropertyBlock materialPropertyBlock;
    // Start is called before the first frame update
    void Start()
    {
        Zposition = transform.position.z;
        meshRenderer = GetComponent<MeshRenderer>();
        materialPropertyBlock = new MaterialPropertyBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if(Situation == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Zposition), Speed * Time.deltaTime);
        }
        if(Situation == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Zposition+1.5f), Speed * Time.deltaTime);
        }
        if (Situation == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Zposition-1.5f), Speed * Time.deltaTime);
        }
    }
    [PunRPC]
    public void PositionChange(int PlayerNumber)
    {
        if(PlayerNumber == 1)
        {
            Situation = 1;
        }
        if (PlayerNumber == 2)
        {
            Situation = 2;
        }

        StartCoroutine(StartChangeColor());
    }

    public IEnumerator StartChangeColor()
    {
        materialPropertyBlock.SetColor("_Color", new Color32(60,255,4,255));
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
        yield return new WaitForSeconds(6f);
        materialPropertyBlock.SetColor("_Color", new Color32(255,167,4,255));
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
        yield return new WaitForSeconds(6f);
        materialPropertyBlock.SetColor("_Color", new Color32(255,4,20,255));
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
        yield return new WaitForSeconds(0.3f);
        materialPropertyBlock.SetColor("_Color", new Color32(79,79,79,255));
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
        yield return new WaitForSeconds(0.3f);
        materialPropertyBlock.SetColor("_Color", new Color32(255,4,20,255));
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
        yield return new WaitForSeconds(0.3f);
        materialPropertyBlock.SetColor("_Color", new Color32(79,79,79,255));
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
        yield return new WaitForSeconds(0.3f);
        materialPropertyBlock.SetColor("_Color", new Color32(255,4,20,255));
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
        yield return new WaitForSeconds(0.3f);
        materialPropertyBlock.SetColor("_Color", new Color32(79,79,79,255));
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
        yield return new WaitForSeconds(0.3f);
        materialPropertyBlock.SetColor("_Color", new Color32(255,4,20,255));
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
        yield return new WaitForSeconds(0.3f);
        materialPropertyBlock.SetColor("_Color", new Color32(79,79,79,255));
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
        yield return new WaitForSeconds(0.3f);
        Situation = 0;
    }
}
