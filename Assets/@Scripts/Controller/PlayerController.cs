using UnityEngine;
using static Define;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : Controller
{
    public float speed;

    [SerializeField] private GameObject[] belt;
    [SerializeField] private GameObject[] cloth;
    [SerializeField] private GameObject[] crown;
    [SerializeField] private GameObject[] face;
    [SerializeField] private GameObject[] glove;
    [SerializeField] private GameObject[] hair;
    [SerializeField] private GameObject[] hat;
    [SerializeField] private GameObject[] helm;
    [SerializeField] private GameObject[] leftWeapon;
    [SerializeField] private GameObject[] rightWeapon;

    protected CharacterController controller;
    protected Animator animator;

    private Vector2 joystickDir;
    private Vector3 jumpDir = Vector3.zero;
    private float jumpPower = 0f;
    private float jumpPowerDecrease = 0.1f;
    private PLAYBUTTON activeButton = PLAYBUTTON.END;
    private ANIMLAYER nowAnimLayer = ANIMLAYER.NOWEAPON;

    private int leftWeaponNum = -1;
    private int rightWeaponNum = -1;

    public void InputJoystickDir(Vector2 Input) => joystickDir = Input;
    public void PressButton(PLAYBUTTON button) => activeButton = button;

    protected override void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        joystickDir = transform.forward;
        activeButton = PLAYBUTTON.END;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        jumpPower = 0f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (activeButton == PLAYBUTTON.BUTTON3)
        {
            Debug.Log("JUMP");
            jumpPower = 3f;
        }


        if (jumpPower > 0f)
        {
            jumpPower -= jumpPowerDecrease;
            if (jumpPower < 0.01f)
            {
                jumpPower = 0f;
                jumpDir = Vector3.zero;
            }
        }

        if (activeButton == PLAYBUTTON.BUTTON1)
        {
            if (leftWeaponNum > -1) leftWeapon[leftWeaponNum].SetActive(false);
            
            ++leftWeaponNum;
            if (leftWeaponNum < leftWeapon.Length)
                leftWeapon[leftWeaponNum].SetActive(true);
            else
                leftWeaponNum = -1;
        }

        if (activeButton == PLAYBUTTON.BUTTON2)
        {
            if (rightWeaponNum > -1) rightWeapon[rightWeaponNum].SetActive(false);
            
            ++rightWeaponNum;
            if (rightWeaponNum < rightWeapon.Length)
                rightWeapon[rightWeaponNum].SetActive(true);
            else
                rightWeaponNum = -1;
        }




        if (Mathf.Sqrt(Mathf.Pow(joystickDir.x, 2) + Mathf.Pow(joystickDir.y, 2)) < 0.1f)
        {
            //idle
            controller.Move(Vector3.zero);
            animator.SetBool("Walk", false);
        }
        else
        {
            Vector3 direction = new Vector3(joystickDir.x, 0f, joystickDir.y);
            controller.Move(direction * Time.deltaTime * speed);
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, speed);
            animator.SetBool("Walk", true);
        }

        // ม฿ทย 
        Vector3 Gravity = new Vector3(0f,-1f + jumpPower, 0f);
        controller.Move(Gravity * Time.deltaTime * GravitySpeed);


        ChangeAnimLayer();
    }


    protected void LateUpdate()
    {
        activeButton = PLAYBUTTON.END;
    }


    private void ChangeAnimLayer()
    {
        if ((rightWeaponNum >= (int)RIGHTHAND.SWORD1) && (rightWeaponNum <= (int)RIGHTHAND.SWORD7))
        {
            if ((leftWeaponNum >= (int)LEFTHAND.SWORD1) && (leftWeaponNum <= (int)LEFTHAND.SWORD7))
            {
                if (nowAnimLayer != ANIMLAYER.DOUBLESWORD)
                {
                    animator.SetLayerWeight((int)nowAnimLayer, 0f);
                    animator.SetLayerWeight((int)ANIMLAYER.DOUBLESWORD, 1f);
                    nowAnimLayer = ANIMLAYER.DOUBLESWORD;
                }
            }
            else if ((leftWeaponNum >= (int)LEFTHAND.SHIELD1) && (leftWeaponNum <= (int)LEFTHAND.SHIELD8))
            {
                if (nowAnimLayer != ANIMLAYER.SWORDSHIELD)
                {
                    animator.SetLayerWeight((int)nowAnimLayer, 0f);
                    animator.SetLayerWeight((int)ANIMLAYER.SWORDSHIELD, 1f);
                    nowAnimLayer = ANIMLAYER.SWORDSHIELD;
                }
            }
        }
        else if (nowAnimLayer != ANIMLAYER.NOWEAPON)
        {
            animator.SetLayerWeight((int)nowAnimLayer, 0f);
            animator.SetLayerWeight((int)ANIMLAYER.NOWEAPON, 1f);
        }
    }



}
