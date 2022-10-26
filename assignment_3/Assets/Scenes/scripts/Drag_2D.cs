using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Drag_2D : MonoBehaviour
{

    #region VERSION 2
    [SerializeField] private bool isSelected;

    private void OnMouseDrag()
    {
               Vector2 cursorWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
               transform.position = new Vector2(cursorWorldPos.x, cursorWorldPos.y);
    }
    #endregion
    private Animator animator;
    public GameObject seed;
    private void OnMouseEnter()
    {
        transform.localScale += Vector3.one * 0.1f;
    }

    private void OnMouseExit()
    {
        transform.localScale -= Vector3.one * 0.1f;
    }
    
    public void Update()
    {
        var dist = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        transform.position = new Vector3(
    Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
    Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
    transform.position.z

  );
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("End")) {
            Debug.Log("1111");
            StartCoroutine(TurnToNext("Scene_05"));
        }
        if (other.CompareTag("Flower"))
        {

            Debug.Log("1111");
            //seed.SetActive(true);
            seed.gameObject.SetActive(true);

        }

        if (other.CompareTag("NextScene"))
        {
            Debug.Log("1111");
            StartCoroutine(TurnToNext("Scene_02"));


        }


        if (other.CompareTag("Sea"))
        {
            animator = this.GetComponent<Animator>();
            animator.SetBool("Play", true);
            Debug.Log(123 );
            StartCoroutine(TurnToNext("Scene_03"));


        }

        if (other.CompareTag("Flowerpot")) {
              other.gameObject.GetComponent<Animator>().SetTrigger("Start");
            StartCoroutine(TurnToNext("Scene_04"));

          
        }

    }

    IEnumerator TurnToNext(string name) {

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(name);
    }

}
