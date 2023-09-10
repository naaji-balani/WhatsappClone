using System.Collections;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public IEnumerator MoveLocal(Transform moveObject, Vector3 targetPosition,float moveSpeed)
    {
        while (moveObject.localPosition != targetPosition)
        {
            moveObject.localPosition = Vector3.MoveTowards(moveObject.localPosition, targetPosition, moveSpeed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

    public IEnumerator RotateLocal(Transform rotateObject, Quaternion targetRotation, float rotationSpeed)
    {
        Quaternion startRotation = rotateObject.localRotation;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.fixedDeltaTime * rotationSpeed;
            rotateObject.localRotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
            yield return new WaitForFixedUpdate();
        }

        rotateObject.localRotation = targetRotation;
    }


    public IEnumerator MoveObjectInUI(RectTransform targetObject, float moveSpeed, Vector3 targetPosition)
    {
        Vector3 startPosition = targetObject.anchoredPosition;

        float distance = Vector3.Distance(startPosition, targetPosition);
        float elapsedTime = 0f;

        while (elapsedTime < distance / moveSpeed)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / (distance / moveSpeed));
            targetObject.anchoredPosition3D = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        // Ensure the object reaches the exact target position
        targetObject.anchoredPosition3D = targetPosition;
    }

    public IEnumerator ObjectActivationControl(int time,GameObject objectToDisable,bool condition)
    {
        yield return new WaitForSeconds(time);
        objectToDisable.SetActive(condition);
    }

    public IEnumerator RotateObjectLocal(Transform objectToRotate,Vector3 rotationAxis,int rotationAngle,int rotationDuration)
    {
        Quaternion startRotation = objectToRotate.localRotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(rotationAxis * rotationAngle);

        float elapsedTime = 0f;

        while (elapsedTime < rotationDuration)
        {
            float t = elapsedTime / rotationDuration;
            objectToRotate.localRotation = Quaternion.Slerp(startRotation, targetRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure that the rotation ends exactly at the target rotation
        objectToRotate.localRotation = targetRotation;
    }

    public IEnumerator ScaleObject(Transform transformToScale, Vector3 targetScale, float speed)
    {
        while (transformToScale.localScale != targetScale)
        {
            transformToScale.localScale = Vector3.MoveTowards(transformToScale.localScale, targetScale, speed * Time.deltaTime);
            yield return null;
        }

        transformToScale.localScale = targetScale; // Ensure the target scale is reached accurately
    }
}
