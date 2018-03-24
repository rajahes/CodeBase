
//PlayerJoyStick
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoyStick : MonoBehaviour {

    public float speed = 4f, hight1=6f;
    Rigidbody2D myBD;
    bool ground1, ground2 = false;
    float move;
    bool moveR, moveL;
    
    // Use this for initialization
    void Start () {
        myBD = GetComponent<Rigidbody2D>();
	}
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground" || other.gameObject.tag == "block")
        {
            ground1 = true;
        }
    }
    public void Jump()
    {
        if((ground1 || !ground2))
        {
            PlayerController.Instance.Jump();
            if (!ground1 && !ground2)
                ground2 = true;
            ground1 = false;
        }
       
    }
    public void MoveR()
    {
       myBD.velocity = new Vector2( speed, myBD.velocity.y);
    }
    public void MoveL()
    {
            myBD.velocity = new Vector2(- speed, myBD.velocity.y);
    }
    public void Stop()
    {
        moveL = moveR = false;
    }
    private void Update()
    {
        move = Input.GetAxis("Horizontal");
    }
   public void setMoveL(bool moveL)
    {
        this.moveL = moveL;
        this.moveR = !moveL;
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (ground1)
        {
            ground2 = false;
        }
        if (moveL)
        {
            MoveL();
        }
        if (moveR)
        {
            MoveR();
        }
        
    }
}


///// Need joyStick for use
// JoyStick
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour ,IPointerUpHandler,IPointerDownHandler{

    PlayerJoyStick PlayerMove;
    public void OnPointerDown(PointerEventData eventData) //an vao man hinh
    {
        if (gameObject.name == "Left")
        {
            PlayerMove.setMoveL(true);
        }
       
        if (gameObject.name == "Righ")
        {
            PlayerMove.setMoveL(false);
        }
        if (gameObject.name == "Jump")
        {
            PlayerMove.Jump();
        }
        if (gameObject.name == "Jump2")
        {
            PlayerMove.Jump();
        }
    }

    public void OnPointerUp(PointerEventData eventData) //khi nha ra NV dung im
    {
        PlayerMove.Stop();
    }



    // Use this for initialization
    void Start () {
        PlayerMove = GameObject.Find("Player"). GetComponent<PlayerJoyStick>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

