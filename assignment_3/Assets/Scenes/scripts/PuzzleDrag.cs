using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleDrag : MonoBehaviour
{
    
    private Vector2 startPos;
    [SerializeField] private Transform correctTrans;
    [SerializeField] private bool isFinished;//Default false

    private Animator animator;

    private void Awake() 
    {
        animator = GetComponent<Animator>();

     
    }


    private void Start()
    {
        startPos = transform.position;

    }

    private void OnMouseDrag()
    {
        if(!isFinished)
        {
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                             Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
    }

    private void OnMouseUp()
    {
        if (SceneManager.GetActiveScene().name== "Scene_01")
        {
            if (Mathf.Abs(transform.position.x - correctTrans.position.x) <= 0.5f &&
               Mathf.Abs(transform.position.y - correctTrans.position.y) <= 0.5f)
            {
                transform.position = new Vector2(correctTrans.position.x, correctTrans.position.y);
                isFinished = true;
                animator.SetTrigger("start");

            }
            else
            {
                transform.position = new Vector2(startPos.x, startPos.y);
                GetComponent<Animator>().Play("stop 0");
            }
        }
    }

   
        

}
