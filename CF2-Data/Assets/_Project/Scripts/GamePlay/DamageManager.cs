using UnityEngine;

using UnityEngine.UI;

public class DamageManager : MonoBehaviour
{

    public GameObject[] deadbody;
    public AudioClip[] hitsound;
    public int hp = 100;
    public int Score = 10;
    private float distancedamage;
    public static int KilledAnimal;
    public bool isDead;
    [Header("Enemy Injuri")]
    public bool healthbar;
    public EmeraldAI.EmeraldAISystem Enemy_data;
    public Slider health_Bar;
    public AudioSource playhit_sound;
    public AnimationClip[] change_anim_clips;
    public AnimationClip[] pre_anim_clips;
    void Start()
    {
        isDead = false;
        //	DeadAnim = this.gameObject.GetComponenet<Animation>();
    }

    void Update()
    {
        if (hp <= 0)
        {
            Dead(Random.Range(0, deadbody.Length));
        }
    }

    public void ApplyDamage(int damage, Vector3 velosity, float distance)
    {
        if (hp <= 0)
        {
            return;
        }
        distancedamage = distance;
        hp -= damage;
    }

    public void ApplyDamage(int damage, Vector3 velosity, float distance, int suffix)
    {
        if (hp <= 0)
        {
            return;
        }
        distancedamage = distance;
        hp -= damage;
        if (hp <= 0)
        {
            Dead(suffix);
        }

        if (healthbar == true)// && hp < 21)
        {
            Health_injur();
        }
    }

    void Health_injur()
    {

        health_Bar.value = hp;
        //Enemy_data.AIAnimator.ResetTrigger("Idle");
        //Enemy_data.AIAnimator.SetBool("Idle Active", false);
        //Enemy_data.AIAnimator.SetTrigger("Dead");
        //Enemy_data.WalkSpeed = 1f;
        //Enemy_data.RunSpeed = 2f;
        //Enemy_data.UseRunAttacksRef = EmeraldAI.EmeraldAISystem.UseRunAttacks.No;
        ////Enemy_data.IdleAnimationList[0].AnimationClip = change_anim_clips[0];
        ////Enemy_data.IdleAnimationList[0].AnimationSpeed = 0.5f;
        ////Enemy_data.NonCombatIdleAnimation = change_anim_clips[0];
        //playhit_sound.Play();
        //Enemy_data.AIAnimator.SetTrigger("Warning");

        //Invoke("wait", 5f);
    }

    void wait()
    {

        Enemy_data.IdleAnimationList[0].AnimationClip = pre_anim_clips[0];
        Enemy_data.IdleAnimationList[0].AnimationSpeed = 1f;
        Enemy_data.NonCombatIdleAnimation = pre_anim_clips[0];


        //Enemy_data.AIAnimator.SetBool("Idle Active", true);
        //Enemy_data.AIAnimator.SetBool("Combat State Active", true);
    }

    public void AfterDead(int suffix)
    {
        int scoreplus = Score;

        if (suffix == 2)
        {
            scoreplus = Score * 5;
        }

        ScoreManager score = (ScoreManager)GameObject.FindObjectOfType(typeof(ScoreManager));
        if (score)
        {
            score.AddScore(scoreplus, distancedamage);
        }

    }


    public void Dead(int suffix)
    {
        if (!isDead)
        {
            if (tag == "Flesh")
            {

                KilledAnimal++;
                if (MissionHandler.ins)
                    MissionHandler.ins.AnimalCounter();

                check_org();
                if (movement_controller.mv_cn)
                {
                    movement_controller.mv_cn.check_movement();
                }
            }
            else
            {
                isDead = true;
            }

            // Dead Animal Count Here


            // print("Dead Counter " + KilledAnimal);

            //DeadAnim.Play("death");
        }
        if (Constants.Getprefs(Constants.lastselectedMode) == 2)
            if (PedestrianSystem.PedestrianSystemManager.Instance)
            {
                PedestrianSystem.PedestrianSystemManager.Instance.curPedestiansSpawned--;
                PedestrianSystem.PedestrianSystemManager.Instance.Addcounter();
            }


        if (deadbody.Length > 0 && suffix >= 0 && suffix < deadbody.Length)
        {
            // this Object has removed by Dead and replaced with Ragdoll. the ObjectLookAt will null and ActionCamera will stop following and looking.
            // so we have to update ObjectLookAt to this Ragdoll replacement. then ActionCamera to continue fucusing on it.
            GameObject deadReplace = (GameObject)Instantiate(deadbody[suffix], this.transform.position, this.transform.rotation);
            // copy all of transforms to dead object replaced
            CopyTransformsRecurse(this.transform, deadReplace);
            // destroy dead object replaced after 5 sec
            Destroy(deadReplace, 5);
            // destry this game object.
            Destroy(this.gameObject, 1);
            this.gameObject.SetActive(false);
            // print("Dead After counter "+KilledAnimal);
        }
        AfterDead(suffix);
    }

    // Copy all transforms to Ragdoll object
    public void CopyTransformsRecurse(Transform src, GameObject dst)
    {


        dst.transform.position = src.position;
        dst.transform.rotation = src.rotation;


        foreach (Transform child in dst.transform)
        {
            var curSrc = src.Find(child.name);
            if (curSrc)
            {
                CopyTransformsRecurse(curSrc, child.gameObject);
            }
        }
    }


    void check_org()
    {
        if (UI_Manager.shot_org == true)
        {
            UI_Manager.instance.hitText.transform.parent.gameObject.SetActive(true);
            UI_Manager.instance.ScoreText.transform.parent.gameObject.SetActive(true);
            UI_Manager.instance.hitText.GetComponent<Text>().text = "BODY SHOT";
            UI_Manager.instance.ScoreText.GetComponent<Text>().text = "$150";
            SoundsManager.Instance.PlaySound(SoundsManager.Instance.voiceovers[Random.Range(0, SoundsManager.Instance.voiceovers.Count)]);
            //UI_Manager.instance.ScoreText.transform.parent.GetComponent<AudioSource>().Play();
            Constants.SetPref(Constants.Bodyshot, Constants.Getprefs(Constants.Bodyshot) + 150);
            UI_Manager.instance.hitText_Off();
        }
        else
        {
            UI_Manager.instance.hitText.transform.parent.gameObject.SetActive(true);
            UI_Manager.instance.ScoreText.transform.parent.gameObject.SetActive(true);
            UI_Manager.instance.hitText.GetComponent<Text>().text = "HEAD SHOT";
            UI_Manager.instance.ScoreText.GetComponent<Text>().text = "$250";
            SoundsManager.Instance.PlaySound(SoundsManager.Instance.voiceovers[Random.Range(0, SoundsManager.Instance.voiceovers.Count)]);
            //UI_Manager.instance.hitText.transform.parent.GetComponent<AudioSource>().Play();
            Constants.SetPref(Constants.Headshot, Constants.Getprefs(Constants.Headshot) + 250);
            UI_Manager.instance.hitText_Off();
        }
    }
}
