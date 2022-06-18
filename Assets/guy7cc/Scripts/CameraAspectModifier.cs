using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspectModifier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera cam = gameObject.GetComponent<Camera>();

        // ���z�̉�ʂ̔䗦
        float targetRatio = 16f / 9f;
        // ���݂̉�ʂ̔䗦
        float currentRatio = Screen.width * 1f / Screen.height;
        // ���z�ƌ��݂̔䗦
        float ratio = targetRatio / currentRatio;

        //�J�����̕`��J�n�ʒu��X���W�ɂǂ̂��炢���炷��
        float rectX = (1.0f - ratio) / 2f;
        float rectY = (1.0f - 1f / ratio) / 2f;
        //�J�����̕`��J�n�ʒu�ƕ\���̈�̐ݒ�
        //cam.rect = new Rect(rectX, 0f, ratio, 1f);
        cam.rect = new Rect(rectX, rectY, ratio, 1 / ratio);
    }

}
