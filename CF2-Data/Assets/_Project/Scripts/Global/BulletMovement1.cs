using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement1 : MonoBehaviour
{
    bool startslomotion = false;
    bool timescalebool = false;
    
    public float timeto_travel;
    public GameObject camera_follow;
   
 
    public GameObject[] weaponOrder;
    // Start is called before the first frame update
    void Start()
    {
        //Guns__OFF();
        //if (PlayerWeapons.ins.currentWeapon==1)
        //{
        //   weaponOrder[0].SetActive(true);
        //}
        //else if (PlayerWeapons.ins.currentWeapon==2)
        //{
        //    weaponOrder[1].SetActive(true);
        //}
        //else if (PlayerWeapons.ins.currentWeapon == 3)
        //{
        //    weaponOrder[2].SetActive(true);
        //}
        //else if (PlayerWeapons.ins.currentWeapon == 4)
        //{
        //    weaponOrder[3].SetActive(true);
        //}
        //else if (PlayerWeapons.ins.currentWeapon == 5)
        //{
        //    weaponOrder[4].SetActive(true);
        //}
        //else if (PlayerWeapons.ins.currentWeapon == 6)
        //{
        //    weaponOrder[5].SetActive(true);
        //}
        //else if (PlayerWeapons.ins.currentWeapon == 7)
        //{
        //    weaponOrder[6].SetActive(true);
        //}
        //else if (PlayerWeapons.ins.currentWeapon == 8)
        //{
        //    weaponOrder[7].SetActive(true);
        //}
        //else if (PlayerWeapons.ins.currentWeapon == 9)
        //{
        //    weaponOrder[8].SetActive(true);
        //}
        //else if (PlayerWeapons.ins.currentWeapon == 10)
        //{
        //    weaponOrder[9].SetActive(true);
        //}
        //Invoke("wait", 0.06f);
        //Invoke("wait1", 0.14f);
        startslomotion = true;
    }
    void wait1()
    {
        timeto_travel = 1.15f;
        print("Bullet Movement speed :"+ timeto_travel);
    }
    int dis_one = 0;
    public void Guns__OFF()
    {

        foreach(GameObject j in weaponOrder)
        {

            j.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(timescalebool == false)
        {
            Time.timeScale = 0.02f;
        }
        else if(timescalebool == true)
        {
            Time.timeScale = 0.2f;

        }
        if (startslomotion == true)
        {
        
            this.transform.position = Vector3.MoveTowards(this.transform.position, UI_Manager.instance.maincontroller_fps.enemytransform.position, timeto_travel);

            float dist = Vector3.Distance(this.transform.position, UI_Manager.instance.maincontroller_fps.enemytransform.position);
            print("dist :"+dist);
            if (dist <= 4)
            {
                camera_follow.GetComponent<Animator>().enabled = false;
                camera_follow.transform.parent = null;

                timeto_travel = 0.13f;
                //dis_one = 1;
                camera_follow.transform.LookAt(UI_Manager.instance.maincontroller_fps.enemytransform);
            }
            if (dist < 0)
            {
                print("Distnave <0");
                //Time.timeScale = 1f;
                UI_Manager.instance.endslowmo();
                Destroy(this.gameObject);
                Destroy(camera_follow);
            }
        }
    }
    void wait()
    {
        startslomotion = true;
        print("Bullet Movement start");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Body")
        {
            other.gameObject.GetComponent<Hit_Body>().damageManage.ApplyDamage(300, this.transform.position, this.transform.position.x, 0);
            UI_Manager.shot_org = true;
            startslomotion = false;
            timescalebool = true;
            print("BodyName :" + this.gameObject.transform.root.name);
            this.transform.GetChild(0).gameObject.SetActive(false);
            Time.timeScale = 1f;
            Invoke("endingslowmo", 0.5f);
        }
        if (other.gameObject.tag == "Head")
        {
            other.gameObject.GetComponent<Hit_Head>().damageManage.ApplyDamage(300, this.transform.position, this.transform.position.x, 0);
            UI_Manager.shot_org = true;
            startslomotion = false;
            timescalebool = true;
            print("HeadName :" + this.gameObject.transform.root.name);
            this.transform.GetChild(0).gameObject.SetActive(false);
            Time.timeScale = 1f;
            Invoke("endingslowmo", 0.5f);
        }
    }
    void endingslowmo()
    {
        UI_Manager.instance.endslowmo();
        Time.timeScale = 1f;
        Destroy(this.gameObject);
        Destroy(camera_follow);
    }
}
