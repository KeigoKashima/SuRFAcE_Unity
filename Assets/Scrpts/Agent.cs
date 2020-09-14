using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Agent : MonoBehaviour
{
    public Instantiate instantiate;
    int num = 900;
    int line = 30;

    private Rigidbody rb;
    public Rigidbody neighbor1;
    public Rigidbody neighbor2;
    public Rigidbody neighbor3;
    public Rigidbody neighbor4;

    float force;


    float m;
    float y;
    float v;
    float y1,y2,y3,y4;
    float k;
    float c;

    bool n1 = false;
    bool n2 = false;
    bool n3 = false;
    bool n4 = false;


    float acceleration;	//加速度。これがないと物理シミュレーションは始まらない。
  	float velocity=0;	//速度。微小時間dtの間の加速度を、積分でいっぱい集めると速度になる
  	float position;	//位置は速度の時間積分
  	float mass;	//質量に相当。

  	const float dt = 1f/100f;	//微小時間dtに相当する部分

    // Start is called before the first frame update
    void Start()
    {

      //Rigidbodyを取得
      rb = this.gameObject.GetComponent<Rigidbody>();
      rb.useGravity = false;

      //質量を100にする
      rb.mass = 10;
      m  = rb.mass;
      k = 100;
      c = 200;

      position = this.transform.position.y;

      //右
      if(Convert.ToInt32(this.name)%line!=0){
          n1 = true;
          neighbor1 = GameObject.Find(Convert.ToString(Convert.ToInt32(this.name)+1)).GetComponent<Rigidbody>();
      }
      //左
      if((Convert.ToInt32(this.name)%line-1)!=0){
          n2 = true;
          neighbor2 = GameObject.Find(Convert.ToString(Convert.ToInt32(this.name)-1)).GetComponent<Rigidbody>();
      }
      //上
      if(((Convert.ToInt32(this.name)-1)/line-(line-1))!=0){
          n3 = true;
          neighbor3 = GameObject.Find(Convert.ToString(Convert.ToInt32(this.name)+line)).GetComponent<Rigidbody>();
      }
      //下
      if(((Convert.ToInt32(this.name)-1)/line)!=0){
          n4 = true;
          neighbor4 = GameObject.Find(Convert.ToString(Convert.ToInt32(this.name)-line)).GetComponent<Rigidbody>();
      }
    }

    // // Update is called once per frame
    // void FixedUpdate()
    // {
    //   y = this.transform.position.y;
    //   v = rb.velocity.y;
    //   if(n1){
    //         y1 = neighbor1.position.y;
    //         f += -k*(y-y1);
    //   }
    //   if(n2){
    //         y2 = neighbor2.position.y;
    //         f += -k*(y-y2);
    //   }
    //
    //   rb.AddForce(new Vector3(0,f-c*v,0));
    // }
    //


  	public void AddForce(float force) {
  		//変更部分開始------------------------------------
  		acceleration += force / m;	//慣性質量が働く分、力をmassで割ってから加速度に入れてあげます！
  		//変更部分開始------------------------------------
  	}

    private float NeighborForce(){
      float f = 0;
      if(n1){
            y1 = neighbor1.position.y;
            f += -k*(position-y1);
      }
      if(n2){
            y2 = neighbor2.position.y;
            f += -k*(position-y2);
      }
      if(n3){
            y3 = neighbor3.position.y;
            f += -k*(position-y3);
      }
      if(n4){
            y4 = neighbor4.position.y;
            f += -k*(position-y4);
      }
      return f;
    }

  	void FixedUpdate () {
      if((Convert.ToInt32(this.name)==1)||(Convert.ToInt32(this.name)==num-line+1)||(Convert.ToInt32(this.name)==num)){
        control1();
      }else if(Convert.ToInt32(this.name)==line){
        control2();
      }else {
        force  = NeighborForce();

    		//変更部分始め----------------------------------------
        AddForce(force-c*velocity);
    		velocity += acceleration * Time.fixedDeltaTime;	//積分に使う微小時間を、デルタタイムに変更！
    		position += velocity * Time.fixedDeltaTime;	//速度を時間積分
                    //変更部分終わり---------------------------------------

    		//地面と接触したら、跳ね返る表現。
    		//地面との衝突判定の代わりに、地面に近いところまで落ちたら速度を反転している。
    		// if(position.y < 0.5f) {
    		// 	velocity = -velocity;
    		// }
    		transform.position = new Vector3(this.transform.position.x,position,this.transform.position.z);
    		acceleration = 0;	//加速度をリセット。加えた力の影響を最後にリセット
      }
      if(Input.GetKey(KeyCode.D)){
        transform.position = new Vector3(this.transform.position.x+0.1f,this.transform.position.y,this.transform.position.z);
      }
      if(Input.GetKey(KeyCode.A)){
        transform.position = new Vector3(this.transform.position.x-0.1f,this.transform.position.y,this.transform.position.z);
      }

  	}

    void control1(){

        if (Input.GetKey(KeyCode.W)) {
            transform.position = new Vector3(this.transform.position.x, transform.position.y + .1f, this.transform.position.z);
        }
        if (Input.GetKey(KeyCode.S)){
            transform.position = new Vector3(this.transform.position.x, transform.position.y - .1f, this.transform.position.z);
        }

    }
    void control2(){

        if (Input.GetKey(KeyCode.O)) {
            transform.position = new Vector3(this.transform.position.x, transform.position.y + .1f, this.transform.position.z);
        }
        if (Input.GetKey(KeyCode.L)){
            transform.position = new Vector3(this.transform.position.x, transform.position.y - .1f, this.transform.position.z);
        }

    }

}
