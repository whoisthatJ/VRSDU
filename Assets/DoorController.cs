using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90f;  // угол, на который нужно открыть дверь
    public float closeAngle = 0f;  // угол, на который нужно закрыть дверь
    public float smoothTime = 2f;  // время, за которое дверь должна открыться или закрыться

    private Quaternion openRotation;   // кватернион для хранения поворота двери в открытом состоянии
    private Quaternion closeRotation;  // кватернион для хранения поворота двери в закрытом состоянии
    private bool isOpening = false;    // флаг, который показывает, открывается ли дверь в данный момент

    void Start()
    {
        // Вычисляем кватернионы для поворота двери в открытом и закрытом состоянии
        openRotation = Quaternion.Euler(0, openAngle, 0);
        closeRotation = Quaternion.Euler(0, closeAngle, 0);
    }

    void Update()
    {
        // Проверяем, нажата ли кнопка "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Инвертируем значение флага, чтобы открыть или закрыть дверь
            isOpening = !isOpening;
        }

        // Вычисляем новый поворот для двери, основываясь на текущем состоянии
        Quaternion targetRotation = isOpening ? openRotation : closeRotation;

        // Используем метод Slerp для плавного перемещения двери к новому повороту
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothTime * Time.deltaTime);
    }
}
