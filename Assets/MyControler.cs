using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*這裡就是大致的生命循環，比Android的也複雜不到哪裡去，現在還差的內容
    多個物體之間的交互，還有攜程，和C#中一些基本東西*/


public class MyControler : MonoBehaviour
{
    public TextManeger textManeger;
    public double m_height = 0;
    public Themode themode;
    public string EnemyControlName = "EnemyObject";
    public float my_player_speed;
    public Transform LeftWall;
    public Transform RightWall;
    public Transform Plane;

    private float m_Actual_Time = 0;
    private float m_Actual_Fps= 0;
    private float m_Real_Time = 0;

    public void healthdamage()
    {
        var stats = GetComponent<Stats>();
        var health = stats.Health;
        stats.Health -= 10;
        textManeger.Something(health);
        Debug.Log(health);

    }

    private void ShowTime(string state)
    {
        m_Actual_Time = m_Actual_Time + Time.deltaTime;
        m_Actual_Fps++;
        if (m_Actual_Time >= 1)
        {
            Debug.Log(state);
            Debug.Log("this is float time" + m_Actual_Time);
            Debug.Log("the fps" + m_Actual_Fps);
            m_Actual_Fps = 0;
            m_Actual_Time = 0;
        }
    }

    private void showRealTime()
    {
        /*        FixedUpdate： FixedUpdate通常比Update更频繁地调用。
                    如果帧速率较低，则每帧可以调用多次，如果帧速率较高，
                    则可能根本不会在帧之间调用。所有物理计算和更新都在FixedUpdate之后立即发生。
                    在FixedUpdate中应用移动计算时，您不需要将值乘以Time.deltaTime。
                    这是因为FixedUpdate是在一个可靠的计时器上调用的，与帧速率无关。
        這裡也說明，它是固定的，操控to manipulate rigidbody component

        */
        m_Real_Time = Time.fixedTime + m_Real_Time;
        if (m_Real_Time >= 1)
        {
            Debug.Log("this is real time"+m_Real_Time);
            m_Real_Time= 0;
        }
    }

    private double controlObject()
    {
        m_Real_Time = m_Real_Time + Time.deltaTime;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            m_height = m_height + 0.1;
        }else if (Input.GetKeyDown("c"))
        {
            m_height = m_height - 0.1;
        }
        if (Input.GetKey(KeyCode.M))
        {
            m_height = m_height + 0.2;
        }
        if (m_Real_Time >= 1)
        {
            Debug.Log("x" + horizontalInput + "y" + verticalInput);
            Debug.Log("now the height is " + m_height);
            m_Real_Time = 0;
        }
        return m_height;
    }

    private void myplayerControler()
    {
        float myplayer_x = this.transform.position.x;
        float myplayer_z = this.transform.position.z;

        float myplayer_scale_x = this.transform.localScale.x/2;

        

        float leftwall_Scale_x = this.LeftWall.transform.localScale.x;
        float leftwall_x = this.LeftWall.transform.position.x;

        float magnify = this.Plane.transform.localScale.x * leftwall_Scale_x;

        float rightwall_x = this.RightWall.transform.position.x;
        float right_Scale_x =this.RightWall.transform.localScale.x;



        m_Actual_Time = m_Actual_Time + Time.deltaTime;
        float x_Input = Input.GetAxis("Horizontal");
        float z_Input = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.Space))
            {
                m_height = m_height + Time.deltaTime*my_player_speed;
            }
            else if (Input.GetKey("c"))
            {
                m_height = m_height - Time.deltaTime * my_player_speed; 
            }
            myplayer_x = myplayer_x + x_Input*Time.deltaTime * my_player_speed;
            myplayer_z = myplayer_z + z_Input*Time.deltaTime * my_player_speed;

            float m_input_height = (float)m_height;


        var real_left = leftwall_x  + magnify;
        var real_right = rightwall_x - magnify;

        if (m_Actual_Time > 1)
        {
/*            Debug.Log("left" + leftwall_x + "and" + real_left + "right" + rightwall_x + "and" + real_right);
            Debug.Log("x" + myplayer_x + "y" + m_input_height + "z" + myplayer_z);*/
            m_Actual_Time = 0;
        }

        if ((myplayer_x+myplayer_scale_x )>= real_right)
        {
            return;
        }else if ((myplayer_x-myplayer_scale_x) <= real_left)
        {
            return ;
        }
        this.transform.position = new Vector3(myplayer_x, m_input_height,myplayer_z);
        
    }


    // Start is called before the first frame update
    /*    生命循環函數*/
    /*在這個裡面，還是像android裡面有生命循環函數*/
    void Awake()
    {
/*        
        var mythemode =GetComponent<Themode>();
        var myname = mythemode.Name;
       
        Debug.Log("this is awake,and we got headlth"+health+myname);*/
    }


/*    在這裡也有攜程的應用*/
    void OnEnable()
    {
        Debug.Log("this is onenable");
    }

/*    這裡同樣有disenable*/
    void Start()
    {
/*        var EnemyGo = GameObject.Find(EnemyControlName);
        Stats enemyStats = EnemyGo.GetComponent<Stats>();
        EnemyControl enemycontrol = EnemyGo.GetComponent<EnemyControl>();
        var enemyHealth = enemyStats.Health;
        Debug.Log("this is enemystats" + enemyHealth + enemycontrol.themode.Name);
        Debug.Log("this start begin");*/
    }
/*    更新也是同步的，會按照整個流程走一遍*/
     void FixedUpdate()
    {
/*        showRealTime();
        ShowTime("fixedupadte");*/
    }

    // Update is called once per frame
    void Update()
    {
        /*        更新： 每帧调用一次更新。它是帧更新的主要主力功能
         不是固定的，會被幀數影響
        這裡可以接受用戶的數據
        控制不是物體的部件

         */
        /* ShowTime("Update");*/
        myplayerControler();



         

    }

    private void LateUpdate()
    {
/*        LateUpdate： LateUpdate在更新完成后每帧调用一次。当LateUpdate开始时，
            在Update中执行的任何计算都将完成。
            LateUpdate的常见用途是跟随第三人称相机。如果您让角色在Update中移动和转动，
            您可以在LateUpdate中执行所有摄像机移动和旋转计算。这将确保角色在相机跟踪其位置之前已完全移动。*/
/*        ShowTime("LateUpdate");*/
    }

    private void OnApplicationQuit()
    {
        Debug.Log("this is OnApplicationQuit");
    }
    private void OnDestroy()
    {
        Debug.Log("this is ondestroy");
    }

}
