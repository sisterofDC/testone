using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*�@�e���Ǵ��µ�����ѭ�h����Android��Ҳ�}�s�������eȥ���F��߀��ă���
    �������w֮�g�Ľ�����߀�Дy�̣���C#��һЩ�����|��*/


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
        /*        FixedUpdate�� FixedUpdateͨ����Update��Ƶ���ص��á�
                    ���֡���ʽϵͣ���ÿ֡���Ե��ö�Σ����֡���ʽϸߣ�
                    ����ܸ���������֮֡����á������������͸��¶���FixedUpdate֮������������
                    ��FixedUpdate��Ӧ���ƶ�����ʱ��������Ҫ��ֵ����Time.deltaTime��
                    ������ΪFixedUpdate����һ���ɿ��ļ�ʱ���ϵ��õģ���֡�����޹ء�
        �@�eҲ�f�������ǹ̶��ģ��ٿ�to manipulate rigidbody component

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
    /*    ����ѭ�h����*/
    /*���@���e�棬߀����android�e��������ѭ�h����*/
    void Awake()
    {
/*        
        var mythemode =GetComponent<Themode>();
        var myname = mythemode.Name;
       
        Debug.Log("this is awake,and we got headlth"+health+myname);*/
    }


/*    ���@�eҲ�Дy�̵đ���*/
    void OnEnable()
    {
        Debug.Log("this is onenable");
    }

/*    �@�eͬ����disenable*/
    void Start()
    {
/*        var EnemyGo = GameObject.Find(EnemyControlName);
        Stats enemyStats = EnemyGo.GetComponent<Stats>();
        EnemyControl enemycontrol = EnemyGo.GetComponent<EnemyControl>();
        var enemyHealth = enemyStats.Health;
        Debug.Log("this is enemystats" + enemyHealth + enemycontrol.themode.Name);
        Debug.Log("this start begin");*/
    }
/*    ����Ҳ��ͬ���ģ�����������������һ��*/
     void FixedUpdate()
    {
/*        showRealTime();
        ShowTime("fixedupadte");*/
    }

    // Update is called once per frame
    void Update()
    {
        /*        ���£� ÿ֡����һ�θ��¡�����֡���µ���Ҫ��������
         ���ǹ̶��ģ���������Ӱ�
        �@�e���Խ����Ñ��Ĕ���
        ���Ʋ������w�Ĳ���

         */
        /* ShowTime("Update");*/
        myplayerControler();



         

    }

    private void LateUpdate()
    {
/*        LateUpdate�� LateUpdate�ڸ�����ɺ�ÿ֡����һ�Ρ���LateUpdate��ʼʱ��
            ��Update��ִ�е��κμ��㶼����ɡ�
            LateUpdate�ĳ�����;�Ǹ�������˳������������ý�ɫ��Update���ƶ���ת����
            ��������LateUpdate��ִ������������ƶ�����ת���㡣�⽫ȷ����ɫ�����������λ��֮ǰ����ȫ�ƶ���*/
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
