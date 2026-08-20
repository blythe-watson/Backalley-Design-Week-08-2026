using UnityEngine;

public class MoveWASD : MonoBehaviour
{
    public Rigidbody2D WASDAnt;
    public CircleCollider2D WASDAntCollider;
    public SpriteRenderer WASDAntRenderer;

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
        if (Input.GetKey(KeyCode.D))
            walkingRight = true;
        else
            walkingRight = false;

        //check player input for direction left
        if (Input.GetKey(KeyCode.A))
            walkingLeft = true;
        else
            walkingLeft = false;

        //check player input for direction up
        if (Input.GetKey(KeyCode.W))
            walkingUp = true;
        else
            walkingUp = false;

        //check player input for direction down
        if (Input.GetKey(KeyCode.S))
            walkingDown = true;
        else
            walkingDown = false;

    }

    private void FixedUpdate()
    {
        Vector2 WASDInput = new Vector2(); //vector to store the speed and amount of movement needed for the ant

        ////////// MOVEMENT IMPLEMENTATION/CALCULATIONS - Y-AXIS //////////

        //up-facing movement
        if (walkingUp == true)
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
            WASDInput.y = speedY;
            //send the playerInput vector to the movement code
            MovementUpdate(WASDInput);
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
            WASDInput.y = -speedY;
            //send the playerInput vector to the movement code
            MovementUpdate(WASDInput);
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
                WASDInput.y = speedY;
                MovementUpdate(WASDInput);
            }

            speedY -= speedToDecrease;

            if (speedY > 0)
            {
                if (WASDInput.y < 0)
                {
                    WASDInput.y += speedY * Time.fixedDeltaTime;
                    MovementUpdate(WASDInput);
                }
                else if (WASDInput.y >= 0)
                {
                    WASDInput.y += -speedY * Time.fixedDeltaTime;
                    MovementUpdate(WASDInput);
                }
                //Debug.Log(speedX);
            }

            else if (speedY <= 0)
            {
                speedY = 0;
                WASDInput.y = speedY;
                MovementUpdate(WASDInput);
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
            WASDInput.x = -speedX;
            //send the playerInput vector to the movement code
            MovementUpdate(WASDInput);
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
            WASDInput.x = speedX;
            //send the playerInput vector to the movement code
            MovementUpdate(WASDInput);
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
                WASDInput.x = speedX;
                MovementUpdate(WASDInput);
            }

            speedX -= speedToDecrease;

            if (speedX > 0)
            {
                if (WASDInput.x < 0)
                {
                    WASDInput.x += speedX * Time.fixedDeltaTime;
                    MovementUpdate(WASDInput);
                }
                else if (WASDInput.x >= 0)
                {
                    WASDInput.x += -speedX * Time.fixedDeltaTime;
                    MovementUpdate(WASDInput);
                }
                //Debug.Log(speedX);
            }

            else if (speedX <= 0)
            {
                speedX = 0;
                WASDInput.x = speedX;
                MovementUpdate(WASDInput);
            }
        }
    }


    private void MovementUpdate(Vector2 WASDInput)
    {
        WASDAnt.linearVelocityX = WASDInput.x;
        WASDAnt.linearVelocityY = WASDInput.y;
        Debug.Log(WASDAnt.linearVelocity);
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
