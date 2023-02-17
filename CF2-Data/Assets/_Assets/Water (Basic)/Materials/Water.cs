using UnityEngine;

public class Water : MonoBehaviour
{
    public Material waterMat;
    public float waterSpeed;

    // Start is called before the first frame update
    void Start()
    {
        waterMat = GetComponent<MeshRenderer>().material;
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        waterMat.mainTextureOffset += new Vector2(0, 0.01f * waterSpeed);
        Debug.Log("uzair " + waterSpeed);
    }

}
