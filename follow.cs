using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 plrPos;
    [SerializeField]
    private float maxSpeed = 10f;

    private bool alive = true;
    private bool spawning = true;

    //public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //animation
      //  animator.SetBool("Spawning", !alive);
        //rotation
        plrPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 plrRotation = plrPos - transform.position;
        float plrRotZ = Mathf.Atan2(plrRotation.y, plrRotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, plrRotZ);
        //movement
        followMousePosDelay(maxSpeed);

    }
    private void followMousePosDelay(float maxSpeed)
    {
        transform.position = Vector2.MoveTowards(transform.position, GetWorldPositionFromMouse(), maxSpeed * Time.deltaTime);
    }
    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
}
