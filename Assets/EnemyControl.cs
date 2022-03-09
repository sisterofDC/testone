using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float enemy_Speed_set;
    public Themode themode;
    public string MypalyerName = "Mypalyer";
    private float enemy_Time = 0;
    private MyControler myControler;
    // Start is called before the first frame update


   private void enemycontroler()
    {
        /*
         這裡訪問到玩家的遊戲地址
         */

        /*        var mycontroler = GetComponent<MyControler>();
                var playerPosition = mycontroler.gameObject.transform.position;*/

        var playerGo = GameObject.Find(MypalyerName);
        
        var playerPosition = playerGo.transform.position;

        var player_x = playerPosition.x;
        var player_y = playerPosition.y;
        var player_z = playerPosition.z;



        var enemy_x = this.transform.position.x;
        var enemy_y = this.transform.position.y;
        var enemy_z = this.transform.position.z;
        enemy_Time = enemy_Time + Time.deltaTime;

        if (enemy_z >= -100)
        {
            enemy_z = enemy_z - enemy_Speed_set * Time.timeScale;
        }else if (enemy_z <= -100)
        {
            Destroy(gameObject);
        }

        float distance_x = enemy_x - player_x;
        float distance_y = enemy_y - player_y;     
        float distance_z = enemy_z - player_z;

        if(Vector3.Distance(playerPosition,this.transform.position) <= 2f)
        {
            myControler.healthdamage();
            Destroy(gameObject);
        }
        
/*        這裡沒有必要，有函數可以使用
 *        if (distance_x <= 1&&distance_x >=-1&&distance_z<=1&&distance_z>=-1)
        {
            Debug.Log("this is distance" + distance_x + " ----" );
            Destroy(gameObject);
        }*/


        if (enemy_Time >= 1)
        {
            
            Debug.Log( "this is enemy"+"x" + enemy_x + "y" + enemy_y + "z" + enemy_z);
            enemy_Time = 0;
        }

        this.transform.position = new Vector3(enemy_x, enemy_y, enemy_z);
    }




    void Awake()
    {
        Stats stats = GetComponent<Stats>();
        var enemythemode = GetComponent<Themode>();
        var enemyName = enemythemode.Name;
        var health = stats.Health;
        Debug.Log("this is enemy" + health + enemyName);
        /*     Stats stats = GetComponent<Stats>();
                var enemythemode = GetComponent<Themode>();
                var enemyName = enemythemode.Name;
                var health = stats.Health;
                Debug.Log("this is enemy"+health+enemyName);
                var playerGo = GameObject.Find(MypalyerName);
                var playerStats = playerGo.GetComponent<Stats>();
                var playerHealth = playerStats.Health;
                Debug.Log("this is player,in enemycontrol" + playerHealth);*/
    }

    void Start()
    {
         myControler = GameObject.Find(MypalyerName).GetComponent<MyControler>();   
    }
    // Update is called once per frame
    void Update()
    {
        enemycontroler();  
    }
}
