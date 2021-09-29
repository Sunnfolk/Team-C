using UnityEngine;

public class SpiderAnimation : MonoBehaviour
{
    private Animator _Animator;
    private SpiderMovement _Spider;

    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();
        _Spider = GetComponent<SpiderMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_Spider.action == "down")
        {
            _Animator.Play("SpiderFall");
        }
        else if (_Spider.action == "attack")
        {
            _Animator.Play("SpiderAttack");
        }
        else
        {
            _Animator.Play("SpiderIdle");
        }
    }
}
