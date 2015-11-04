using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IController
{
    private enum Facing
    {
        Up,
        Down,
        Left,
        Right
    };

    #region Public Interface

    public Vector2 GunLocation
    {
        get
        {
            return gunLocation.transform.position;
        }
    }

    public Vector2 ProjectileVector
    {
        get
        {
            switch (myFacing)
            {
                case Facing.Up:
                    return Vector2.up;
                case Facing.Down:
                    return Vector2.down;
                case Facing.Left:
                    return Vector2.left;
                case Facing.Right:
                    return Vector2.right;
                default:
                    return Vector2.up;
            }
        }
    }

    #endregion Public Interface

    private Rigidbody2D myRigidbody2D;
    private GameObject playerRender;
    private GameObject gunLocation;
    private Facing myFacing = Facing.Up;
    private float walkingSpeed;

    public void Awake()
    {
        Resolver.Instance.AddController(this);
    }

    // Use this for initialization
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        playerRender = transform.FindChild("PlayerRender").gameObject;
        gunLocation = playerRender.transform.FindChild("GunPoint").gameObject;

        walkingSpeed = 8.0f;
    }

    public void OnDestroy()
    {
        Resolver.Instance.RemoveController(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move senteces
        myRigidbody2D.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * walkingSpeed, 0.8f),
                                             Mathf.Lerp(0, Input.GetAxis("Vertical") * walkingSpeed, 0.8f));

        /*
         * Figure out direction we're facing based on the position of the mouse relative to the character.  The screen is divided up into quadrants:
         * |\          /|
         * | \        / |
         * |  \      /  |
         * |   \    /   |
         * |    \  /    |
         * |     \/     |
         * |     /\     |
         * |    /  \    |
         * |   /    \   |
         * |  /      \  |
         * | /        \ |
         * |/          \|
         * 
         * We can do some cheater math to figure out where in that grid (it's supposed to be a square, bear with me) the cursor is located using the fact that
         * along the lines, abs(xdiff) == abs(ydiff).  so if abs(xdiff) > abs(ydiff), for example, we know it's either in the left or right section.
         */

        Facing oldFacing = myFacing;

        Vector2 pointerPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float xDiff = pointerPosition.x - transform.position.x;
        float yDiff = pointerPosition.y - transform.position.y;

        if (Mathf.Abs(xDiff) >= Mathf.Abs(yDiff))
        {
            myFacing = ((xDiff > 0) ? Facing.Right : Facing.Left);
        }
        else
        {
            myFacing = ((yDiff > 0) ? Facing.Up : Facing.Down);
        }


        if (oldFacing != myFacing)
        {
            SetNewRotation();
        }
    }

    private void SetNewRotation()
    {
        switch (myFacing)
        {
            case Facing.Up:
                playerRender.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                break;
            case Facing.Down:
                playerRender.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
                break;
            case Facing.Left:
                playerRender.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                break;
            case Facing.Right:
                playerRender.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;
        }
    }

    public void Cleanup()
    {
        throw new NotImplementedException();
    }
}
