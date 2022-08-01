using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float SpeedX = 5.0f;
    [SerializeField] private float SpeedY = 5.0f;
    private float width;
    private float height;
    private Vector3 moveVector;
    private void Awake()
    {
        width = GetComponentInChildren<SpriteRenderer>().size.x;
        height = GetComponentInChildren<SpriteRenderer>().size.y;
        moveVector = new Vector3(SpeedX * Time.deltaTime, SpeedY * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveVector;
        if (transform.position.x > width)
        {
            transform.position = new Vector3(0, transform.position.y);
        }
        if (transform.position.y>height)
        {
            transform.position = new Vector3(transform.position.x, 0);
        }
    }
}
