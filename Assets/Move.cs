using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public Animator animator;
    private float lastX;
    float lastY;
    public bool isRunning;
    public Vector3 direct;
    [SerializeField] private UIManager uiManager;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(uiManager.isToggle == false)
        {
            float hor = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");

            direct = new Vector3((float)hor, (float)ver);

      

            if (hor != 0 || ver != 0)
            {
                lastX = hor;
                lastY = ver;
            }
            isRunning = Input.GetKey(KeyCode.LeftShift);
            if (isRunning){
                speed = 5f;
                animator.SetBool("Running", true);
            }
            else
            {
                speed = 3f;
                animator.SetBool("Running", false);
            }
            animator.SetFloat("lastMoveX", lastX);
            animator.SetFloat("lastMoveY", lastY);
            AnimateMovement(direct);
        }
        else
        {
            direct = Vector3.zero;
            AnimateMovement(Vector3.zero);
            animator.SetBool("Running", false);
        }

    }

    private void FixedUpdate()
    {
        this.transform.position += direct.normalized * speed * Time.deltaTime;
    }

    void AnimateMovement(Vector3 Direction)
    {
        AudioManager a = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (animator != null)
        {
            if (Direction.magnitude > 0)
            {
                
                a.WalkSFX();
                animator.SetBool("Moving", true);
                animator.SetFloat("Horizontal", Direction.x);
                animator.SetFloat("Vertical", Direction.y);

            }
            else
            {
                a.Deactivate();
                animator.SetBool("Moving", false);
            }
        }
    }
}
