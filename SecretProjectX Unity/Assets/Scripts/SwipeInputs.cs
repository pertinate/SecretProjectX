using UnityEngine;
using System.Collections;

public enum Direction
{
    Left,
    Right,
    Up,
    Down,
    DRight,//Diagonal Right Down
    DLeft,//Diagonal Left Down
    URight,//Diagonal Right Up
    Uleft//Diagonal Left Up
}
public static class DirectionExtension
{
    public static bool GetInput(this Direction en)
    {
        return SwipeInputs.GetInput(en);
    }
}
public class SwipeInputs : MonoBehaviour {
    private static Vector2 startPos;
    private static bool isSwiping = false;
    private static float minDist = 30f;
    public float minDistSwipe
    {
        get { return minDist; }
        set { minDist = value; }
    }


    public static bool GetInput(Direction en)
    {
        if (Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        isSwiping = true;
                        startPos = touch.position;
                        break;
                    case TouchPhase.Ended:
                        float gestureDist = (touch.position - startPos).magnitude;
                        if(isSwiping && gestureDist > minDist)
                        {
                            Vector2 direction = touch.position - startPos;
                            switch (en)
                            {
                                case Direction.Left: case Direction.Right:
                                    if (Mathf.Abs(direction.normalized.x) > 0.65f)
                                    {
                                        if (en == Direction.Left)
                                        {
                                            if (Mathf.Sign(direction.x) > 0)
                                                return true;
                                            else
                                                return false;
                                        }
                                        else if (en == Direction.Right)
                                        {
                                            if (Mathf.Sign(direction.x) > 0)
                                                return false;
                                            else
                                                return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    break;
                                case Direction.Up: case Direction.Down:
                                    if (Mathf.Abs(direction.normalized.y) > 0.65f)
                                    {
                                        if (en == Direction.Up)
                                        {
                                            if (Mathf.Sign(direction.y) > 0)
                                                return true;
                                            else
                                                return false;
                                        }
                                        else if (en == Direction.Down)
                                        {
                                            if (Mathf.Sign(direction.y) > 0)
                                                return false;
                                            else
                                                return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    break;
                                case Direction.DRight: case Direction.URight:
                                    if(Mathf.Sign(direction.x) > 0)
                                    {
                                        if (en == Direction.URight)
                                        {
                                            if (Mathf.Sign(direction.y) > 0)
                                                return true;
                                            else
                                                return false;
                                        }
                                        else if (en == Direction.DRight)
                                        {
                                            if (Mathf.Sign(direction.y) > 0)
                                                return false;
                                            else
                                                return true;
                                        }
                                        else
                                            return false;
                                    }
                                    break;
                                case Direction.DLeft: case Direction.Uleft:
                                    if(!(Mathf.Sign(direction.x) > 0))
                                    {
                                        if (en == Direction.Uleft)
                                        {
                                            if (Mathf.Sign(direction.y) > 0)
                                                return true;
                                            else
                                                return false;
                                        }
                                        else if (en == Direction.DLeft)
                                        {
                                            if (Mathf.Sign(direction.y) > 0)
                                                return false;
                                            else
                                                return true;
                                        }
                                        else
                                            return false;
                                    }
                                    break;
                                default:
                                    return false;
                            }
                        }
                        break;
                    case TouchPhase.Canceled:
                        break;
                    default:
                        break;
                }
            }
        }
        return false;
    }
}
