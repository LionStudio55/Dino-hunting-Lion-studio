using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public Vector3 target;
    public RaycastHit hitObj;

    float speed = 6;
    float restoreTimeRatio = 0.05f; //0.002
    float tempTime = 0;
    bool startBulletTravel = false;
    bool isHit = false;
    float totaldistance;
    float covereddistance;
    public GameObject[] cams;
    int camIndex = 0;
    float dist = 0;
    bool camHandled = false;

    bool blurEnabled = false;
    //public Transform mainCamTransform;
    public RaycastHit SlowHit;
    public GameObject MuzzelFlash;
    public int SpawnPoolIndex = 30;
    private void OnDestroy()
    {
        Time.timeScale = 1.0f;
    }

    private void OnEnable()
    {
        MuzzelFlash.transform.parent = null;
    }
    public float FirstmidPoint;
    public float MidPoint;
    public float SecondmidPoint;
    Vector3 distance;
    private void Start()
    {
        camIndex = Random.Range(0, cams.Length - 1);

        cams[camIndex].SetActive(true);

        tempTime = 0.5f;
        Time.timeScale = 0.2f;
        totaldistance = Vector3.Distance(this.transform.position, target);
        //Toolbox.GameManager.Log("Totaldistance:" + totaldistance);
        MidPoint = Vector3.Distance(this.transform.position, target) / 2;
        //  MidPoint = (((this.gameObject.transform.position).magnitude+ target.magnitude )/ 2);
        FirstmidPoint = Vector3.Distance(this.transform.position, target) / 4;
        SecondmidPoint = Vector3.Distance(this.transform.position, target) / 1.33f;


    }
    public void EnableBulletTravel()
    {

        startBulletTravel = true;
    }

    private void Update()
    {

        if (tempTime > 0)
        {
            tempTime -= Time.deltaTime;
        }
        else
        {

            EnableBulletTravel();
            covereddistance = totaldistance - dist;
            if (covereddistance >= FirstmidPoint && covereddistance < MidPoint)
            {
                speed = 5f * covereddistance;
                // Debug.Log("FirstmidPoint:"+ speed);
            }
            else if (covereddistance >= MidPoint && covereddistance < SecondmidPoint)
            {
                speed = 1f * covereddistance;
                // Debug.Log("MidPoint_Cross:"+ speed);
            }
            else if (covereddistance >= SecondmidPoint && covereddistance < totaldistance)
            {
                speed = 4f;
                //  Debug.Log("SecondmidPoint_Cross:"+ speed);
            }
            else
            {
                speed = 1f * covereddistance;
                //  Debug.Log("Initialspeed:"+ speed);
            }
            Time.timeScale = Mathf.MoveTowards(Time.timeScale, 1.0f, Time.deltaTime * speed);
        }

        if (!startBulletTravel)
            return;
        // transform.LookAt(target);
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        //Time.timeScale += restoreTimeRatio;

        dist = Vector3.Distance(this.transform.position, target);

        if (dist <= 2 && !camHandled)
        {
            cams[camIndex].GetComponent<Animator>().enabled = false;
            cams[camIndex].transform.parent = null;
            camHandled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Body")
        {
            if (other.gameObject.GetComponent<Hit_Body>())
                other.gameObject.GetComponent<Hit_Body>().damageManage.ApplyDamage(300, this.transform.position, this.transform.position.x, 0);
            if (UI_Manager.shot_org)
                UI_Manager.shot_org = true;

            if (this.transform.GetChild(0).gameObject)
                this.transform.GetChild(0).gameObject.SetActive(false);
            Time.timeScale = 1f;
            Invoke("endingslowmo", 0.5f);
        }
        if (other.gameObject.tag == "Head")
        {
            if (other.gameObject.GetComponent<Hit_Head>())
                other.gameObject.GetComponent<Hit_Head>().damageManage.ApplyDamage(300, this.transform.position, this.transform.position.x, 0);
            if (UI_Manager.shot_org)
                UI_Manager.shot_org = false;

            if (this.transform.GetChild(0).gameObject)
                this.transform.GetChild(0).gameObject.SetActive(false);
            Time.timeScale = 1f;
            Invoke("endingslowmo", 0.5f);
        }
    }
    void endingslowmo()
    {
        if (UI_Manager.instance)
            UI_Manager.instance.endslowmo();
        Time.timeScale = 1f;
        //this.GetComponent<ReflectionProbe>().enabled = false;
        Destroy(this.gameObject);
        //Destroy(camera_follow);
    }

}
