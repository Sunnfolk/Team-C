using UnityEngine;

public class GnomeAnimation : MonoBehaviour
{
    private Animator _Animator;
    private GnomeMovement _Gnome;
    
    private string _CurrentAnimation = "closed";
    private float _Timer;
    private string _NextAnimation;
    private bool _SwapAnimation;

    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();
        _Gnome = GetComponent<GnomeMovement>();
        
        ChangeAnimation("closed");
    }

    // Update is called once per frame
    void Update()
    {

        if (_Timer > 0)
        {
            print("--");
            _Timer -= Time.deltaTime;
        }

        if (_Timer <= 0 && _SwapAnimation)
        {
            _CurrentAnimation = _NextAnimation;
            _SwapAnimation = false;
        }

        switch (_CurrentAnimation)
        {
            case "opening":
                print("open");
                _Animator.Play("GnomeOpeningMouth");
                break;
            case "open":
                _Animator.Play("GnomeOpen");
                break;
            case "lick":
                _Animator.Play("GnomeLick");
                break;
            default:
                _Animator.Play("GnomeClosed");
                break;
        }

        var dir = _Gnome.goingRight ? 1f : -1f;
        transform.localScale = new Vector2( dir * 3f, 3f);
    }

    private void ChangeAnimation(string str)
    {
        _CurrentAnimation = str;
        if (str == "closed")
        {
            _Timer = Random.Range(1.5f, 4f);
            _NextAnimation = "opening";
            _SwapAnimation = true;
        }
        else if (str == "open")
        {
            _Timer = Random.Range(1f, 2.5f);
            _NextAnimation = "lick";
            _SwapAnimation = true;
        }
    }
}
