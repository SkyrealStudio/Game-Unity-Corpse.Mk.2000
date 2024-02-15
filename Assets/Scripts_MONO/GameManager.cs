using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform character;

    [SerializeField]
    private float publicCharacterSpeed;

    private Vector3 characterLastPos = new();
    private Vector3 characterSpeed = new();

    private Vector3 LeftOffset;
    private Vector3 RightOffset;

    private bool mLeft;
    private bool mRight;


    // Start is called before the first frame update
    private void Start()
    {
        if (!character)
        {
            character = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        characterLastPos = character.transform.position;
    }


    // Update is called once per frame
    private void Update()
    {
        LeftOffset = new(-publicCharacterSpeed, 0f, 0f);
        RightOffset = new(publicCharacterSpeed, 0f, 0f);

        mLeft = Input.GetKey(KeyCode.A);
        mRight = Input.GetKey(KeyCode.D);
    }

    private void FixedUpdate()
    {
        if(mLeft)   character.Translate(LeftOffset * Time.deltaTime);
        if(mRight)  character.Translate(RightOffset * Time.deltaTime);
        characterSpeed = character.transform.position - characterLastPos;
        characterLastPos = character.transform.position;
        Debug.Log(characterSpeed);
        Debug.Log(Time.deltaTime);
    }

}
