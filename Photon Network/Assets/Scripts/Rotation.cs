using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;
    [SerializeField] float speed = 200.0f;

    public void InputRotateY()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
    }

    public void RotateY(Rigidbody rigidBody)
    {
        rigidBody.transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

    public void RotateX()
    {
        // mouseX�� ���콺�� �Է��� ���� �����Ѵ�.
        // mouseY�� -65 ~ 65 ������ ������ �����Ѵ�.
        // mouseY <- Mathf.Clamp(�����ϴ� ��, �ּҰ�, �ִ밪)
        mouseY += Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime;

        mouseY = Mathf.Clamp(mouseY, -65, 65);

        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }
}
