using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenMover : MonoBehaviour
{
    public PlayerMoveInertia player;
    public Animator animator;
    public Rigidbody rigidBody;
    Vector3 targetPosition;
    float x, y;
    public float moveSpeed = 15;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = player.transform.position;
        
        y = Camera.main.orthographicSize;
        x = Camera.main.aspect*y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 10){
            animator.SetTrigger("Attack_1");
        }
        targetPosition = getCoords(targetPosition);
        moveDirection = getDirection(transform.position, targetPosition).normalized;
        move();
    }

    public void move(){
        rigidBody.velocity = moveDirection * moveSpeed;
    }

    public Vector3 getDirection(Vector3 from,Vector3 to){
        Vector3 coords = getCoords(to);
        Vector3 result = Vector3.zero;
        float magnitude = (x+y)*2;
        for(int _x = -1; _x<2; _x++){
            for(int _y = -1; _y<2; _y++){
                if(Vector3.Distance(from,coords + new Vector3(_x*x*2, 0,_y*y*2)) < magnitude){
                    magnitude = Vector3.Distance(from,coords+ new Vector3(_x*x*2, _y*y*2,0));
                    result = coords + new Vector3(_x*x*2, 0,_y*y*2);
                }
            }
        }
        //Debug.DrawLine(from,result);
        return from-result;
    }

    public Vector3 getCoords(Vector3 vect){
        float _x = vect.x;
        float _y = vect.y;
        while(_x>x || _x<-x){
            _x = (_x>x)?_x-x*2:_x+x*2;
        }
        while(_y>y || _y<-y){
            _y = (_y>y)?_y-y*2:_y+y*2;
        }
        return new Vector3(_x, 0, _y);
    }
}
