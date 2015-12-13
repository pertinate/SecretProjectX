using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public Quaternion[] rotations = new Quaternion[] { new Quaternion(0, 0, 0, 0), new Quaternion(0, 90, 0, 0), new Quaternion(0, 180, 0, 0), new Quaternion(0, 270, 0 ,0), new Quaternion(0, 360, 0, 0)};

    public int currentRotation;

    private void Start()
    {
        Debug.Log(Direction.Left);
        for(int i = 0; i < rotations.Length; i++)
        {
            if (this.transform.rotation == rotations[i])
                currentRotation = i;
        }
    }
    private void Update()
    {
        Debug.Log(currentRotation);
        ControlCamera();
        if (this.transform.rotation == rotations[currentRotation])
            StopAllCoroutines();
    }
    private void ControlCamera()
    {
        if (Direction.Left.GetInput())
        {
            currentRotation++;
            transform.rotation = Quaternion.Lerp(this.transform.rotation, rotations[currentRotation], Time.deltaTime * 0.06f);
        }
        else if(Direction.Right.GetInput() || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("pressed");
            currentRotation--;
            StartCoroutine(rotateTo());
        }
    }
    private IEnumerator rotateTo()
    {
        while (true)
        {
            transform.rotation = Quaternion.LerpUnclamped(transform.rotation, rotations[currentRotation], Time.deltaTime * 0.06f);
            yield return null;
        }
    }
}