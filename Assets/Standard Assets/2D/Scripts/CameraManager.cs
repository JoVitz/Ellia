using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    private Bounds currentBounds;
    public Enemy1Manager enemy;


    public float alignDuration = 0.7f;

    IEnumerator AlignToNewBounds(int nbEnemy1)
    {

        Vector3 startVect = transform.position;
        Vector3 trackingVect = transform.position;

        float targX = currentBounds.center.x;
        float targY = currentBounds.center.y;
        Vector3 targetPosition = new Vector3(targX, targY, transform.position.z);

        float lerpTime = 0;
        while (lerpTime < alignDuration)
        {

            lerpTime += Time.deltaTime;
            trackingVect = Vec3Lerp(lerpTime, alignDuration, startVect, targetPosition);
            transform.position = trackingVect;
            yield return 0;
        }

        transform.position = targetPosition;
        for (int i = 0; i < nbEnemy1; i++)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.farClipPlane / 2));
            Instantiate(enemy, pos, Quaternion.identity);//todo adjust position (2,15
        }
        //Instantiate(enemy);
    }

    public void SetNewBounds(Bounds newBounds, int nbEnemy1)
    {
        if (currentBounds != newBounds)
        {
            currentBounds = newBounds;
            StartCoroutine(AlignToNewBounds(nbEnemy1));
        }
    }

    public static Vector3 Vec3Lerp(float currentTime, float duration, Vector3 v3_start, Vector3 v3_target)
    {
        float step = (currentTime / duration);
        Vector3 v3_ret = Vector3.Lerp(v3_start, v3_target, step);
        return v3_ret;
    }

}
