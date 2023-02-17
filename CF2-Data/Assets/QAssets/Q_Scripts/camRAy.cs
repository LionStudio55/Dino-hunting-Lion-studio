using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class camRAy : AS_ActionPreset
{
    public static camRAy instancee;

    public GameObject currentObjectRaycast;
    public Image simpleAim;
    public Text showDistance, BodyDetectiontext;
    public float distace_con;
    public bool slowmo_health;
    DamageManager current_enemy;
    private const int ignoreWalkThru = ~((1 << 29) | (1 << 2) | (1 << 27) | (1 << 4) | (1 << 26));
    // Start is called before the first frame update
    // Script attach to FPS camera for enemy detection before fire
    void Start()
    {
        instancee = this;
    }
    public override void FirstDetected(AS_Bullet bullet, AS_BulletHiter target, Vector3 point)
    {
        //Debug.Log("FirstDetected");
        base.FirstDetected(bullet, target, point);
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(myRay, out hit, 2000f, ignoreWalkThru))
        {
            AS_BulletHiter bullet = hit.collider.GetComponent<AS_BulletHiter>();
            if (bullet)
            {
                // detected last raycast hitted object
                RaycastHit[] hits;
                hits = Physics.RaycastAll(transform.position, transform.forward, 2000f);

               
                if (hits[hits.Length - 1].collider.gameObject.tag == "Head")
                {
                    // print(" Head D");
                    BodyDetectiontext.enabled = true;
                    BodyDetectiontext.text = "HEAD";
                    slowmo_health = true;
                }

                else if (hits[hits.Length - 1].collider.gameObject.tag == "Brain")
                {
                    // print(" Body D ");
                    BodyDetectiontext.enabled = true;
                    BodyDetectiontext.text = "BRAIN";
                }
                else if (hits[hits.Length - 1].collider.gameObject.tag == "Heart")
                {
                    // print(" Body D ");
                    BodyDetectiontext.enabled = true;
                    BodyDetectiontext.text = "HEART";
                }
                else if (hits[hits.Length - 1].collider.gameObject.tag == "Lungs")
                {
                    // print(" Body D ");
                    BodyDetectiontext.enabled = true;
                    BodyDetectiontext.text = "LUNGS";
                }
                else if (hits[hits.Length - 1].collider.gameObject.tag == "Body")
                {
                    // print(" Body D ");
                    BodyDetectiontext.enabled = true;
                    BodyDetectiontext.text = "BODY";
                    currentObjectRaycast = hits[hits.Length - 1].collider.gameObject.transform.root.gameObject;
                 
                }

                
                simpleAim.color = Color.green;
                simpleAim.GetComponent<Animator>().enabled = true;
                follow.followChk = true;
                if(currentObjectRaycast && currentObjectRaycast.GetComponent<Outline>())
                    currentObjectRaycast.GetComponent<Outline>().enabled = true;
                //Debug.Log("hit" + hits[hits.Length - 1].collider.transform.root.tag);
                if (hits[hits.Length - 1].collider.transform.root.tag == "Enemy")
                {
                    follow.followChk = true;
                    UI_Manager.onFollowCam = true;
                }
                else
                {
                    follow.followChk = false;
                    UI_Manager.onFollowCam = false;
                }



                showDistance.enabled = true;
                float dist = Vector3.Distance(hit.transform.position, transform.position);
                showDistance.text = dist.ToString("0") + "M";
                distace_con = dist;
                
               
            }
            else
            {

                simpleAim.color = Color.red;
                simpleAim.GetComponent<Animator>().enabled = false;
                if (currentObjectRaycast && currentObjectRaycast.GetComponent<Outline>())
                    currentObjectRaycast.GetComponent<Outline>().enabled = false;
                showDistance.enabled = false;
                BodyDetectiontext.enabled = false;
                slowmo_health = false;
            }
        }
    }
}
