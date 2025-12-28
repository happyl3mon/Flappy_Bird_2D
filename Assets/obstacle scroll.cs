using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class obstaclescroll : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private KeyCode keySelect;
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * xSpeed * Time.deltaTime);            
    }
}
