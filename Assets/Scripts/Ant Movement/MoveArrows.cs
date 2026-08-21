using UnityEngine;
using UnityEngine.InputSystem;

public class MoveArrows : MonoBehaviour
{
    //Vector3 direction;
    //public float speed;

    public Rigidbody2D arrowAnt;
    public CircleCollider2D arrowAntCollider;
    public SpriteRenderer arrowAntRenderer;

    bool walkingLeft;
    bool walkingRight;
    bool walkingUp;
    bool walkingDown;

    float speedX;
    float speedY;
    public float maxSpeedX;
    public float maxSpeedY;

    public float accelTime;
    public float decelTime;

    float speedToDecrease = 0;

    
    //set direction options
    public enum FacingDirection
    {
        left, right, up, down
    }
    public FacingDirection direction;


    // Update is called once per frame
    void Update()
    {
        ////////// MOVEMENT INPUT //////////
            
        //check player input for direction right
            if (Input.GetKey(KeyCode.RightArrow))
                walkingRight = true;
            else
                walkingRight = false;

            //check player input for direction left
            if (Input.GetKey(KeyCode.LeftArrow))
                walkingLeft = true;
            else
                walkingLeft = false;

        //check player input for direction up
            if (Input.GetKey(KeyCode.UpArrow))
                walkingUp = true;
            else 
                walkingUp = false;
        
        //check player input for direction down
            if (Input.GetKey(KeyCode.DownArrow))
                walkingDown = true;
            else
                walkingDown = false;
        
    }

    private void FixedUpdate()
    {
        Vector2 arrowsInput = new Vector2(); //vector to store the speed and amount of movement needed for the ant
        
        ////////// MOVEMENT IMPLEMENTATION/CALCULATIONS - Y-AXIS //////////

        //up-facing movement
            if(walkingUp == true)
            {
                direction = FacingDirection.up;

                //acceleration time
                if (speedY < maxSpeedY)
                {
                    speedY += (maxSpeedY / accelTime) * Time.fixedDeltaTime;
                }
                else
                {
                    speedY = maxSpeedY;
                }

                //make the y value of the playerInput vector the current speed
                arrowsInput.y = speedY;
                //send the playerInput vector to the movement code
                MovementUpdate(arrowsInput);
            }
        //down-facing movement
            else if (walkingDown == true)
            {
                direction = FacingDirection.down;

                //acceleration time
                if (speedY < maxSpeedY)
                {
                    speedY += (maxSpeedY / accelTime) * Time.fixedDeltaTime;
                }
                else
                {
                    speedY = maxSpeedY;
                }

                //make the y value of the playerInput vector the current speed
                arrowsInput.y = -speedY;
                //send the playerInput vector to the movement code
                MovementUpdate(arrowsInput);
            }

        //deceleration on the Y axis
            else
            {
                if (decelTime >= 1)
                {
                    speedToDecrease = maxSpeedY / decelTime;
                }

                else if (decelTime < 1)
                {
                    speedToDecrease = maxSpeedY * decelTime;
                }

                else if (decelTime == 0)
                {
                    speedY = 0;
                    arrowsInput.y = speedY;
                    MovementUpdate(arrowsInput);
                }

                speedY -= speedToDecrease;

                if (speedY > 0)
                {
                    if (arrowsInput.y < 0)
                    {
                        arrowsInput.y += speedY * Time.fixedDeltaTime;
                        MovementUpdate(arrowsInput);
                    }
                    else if (arrowsInput.y >= 0)
                    {
                        arrowsInput.y += -speedY * Time.fixedDeltaTime;
                        MovementUpdate(arrowsInput);
                    }
                    //Debug.Log(speedX);
                }

                else if (speedY <= 0)
                {
                    speedY = 0;
                    arrowsInput.y = speedY;
                    MovementUpdate(arrowsInput);
                }
            }

        ////////// MOVEMENT IMPLEMENTATION/CALCULATIONS - X-AXIS //////////
        //left-facing movement
        if (walkingLeft == true)
        {
            direction = FacingDirection.left;

            //acceleration time
            if (speedX < maxSpeedX)
            {
                speedX += (maxSpeedX / accelTime) * Time.fixedDeltaTime;
            }
            else
            {
                speedX = maxSpeedX;
            }

            //make the x value of the playerInput vector the current speed
            arrowsInput.x = -speedX;
            //send the playerInput vector to the movement code
            MovementUpdate(arrowsInput);
        }
        //right-facing movement
        else if (walkingRight == true)
        {
            direction = FacingDirection.right;

            //acceleration time
            if (speedX < maxSpeedX)
            {
                speedX += (maxSpeedX / accelTime) * Time.fixedDeltaTime;
            }
            else
            {
                speedX = maxSpeedX;
            }

            //make the x value of the playerInput vector the current speed
            arrowsInput.x = speedX;
            //send the playerInput vector to the movement code
            MovementUpdate(arrowsInput);
        }

        //deceleration on the X axis
        else
        {
            if (decelTime >= 1)
            {
                speedToDecrease = maxSpeedX / decelTime;
            }

            else if (decelTime < 1)
            {
                speedToDecrease = maxSpeedX * decelTime;
            }

            else if (decelTime == 0)
            {
                speedX = 0;
                arrowsInput.x = speedX;
                MovementUpdate(arrowsInput);
            }

            speedX -= speedToDecrease;

            if (speedX > 0)
            {
                if (arrowsInput.x < 0)
                {
                    arrowsInput.x += speedX * Time.fixedDeltaTime;
                    MovementUpdate(arrowsInput);
                }
                else if (arrowsInput.x >= 0)
                {
                    arrowsInput.x += -speedX * Time.fixedDeltaTime;
                    MovementUpdate(arrowsInput);
                }
                //Debug.Log(speedX);
            }

            else if (speedX <= 0)
            {
                speedX = 0;
                arrowsInput.x = speedX;
                MovementUpdate(arrowsInput);
            }
        }
    }


    private void MovementUpdate(Vector2 arrowsInput)
    {
        arrowAnt.linearVelocityX = arrowsInput.x;
        arrowAnt.linearVelocityY = arrowsInput.y;
        Debug.Log(arrowAnt.linearVelocity);
    }


    //set up facing direction
    public FacingDirection GetFacingDirection()
    {
        
        if (direction == FacingDirection.left)
            return FacingDirection.left;

        else if (direction == FacingDirection.right)
            return FacingDirection.right;

        else if (direction == FacingDirection.up)
            return FacingDirection.up;

        else if (direction == FacingDirection.down)
            return FacingDirection.down;
        

        else
            return direction;

    }

}


