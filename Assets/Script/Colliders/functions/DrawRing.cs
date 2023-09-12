using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class DrawRing : MonoBehaviour
{
    public LineRenderer circleRenderer;
 
    public int edges = 100;
    public float radius = 1;
    [Range(0,1)] public float percent = 1;

    private void Start()
    {
        
    }

    void DrawCircle(int steps,float radius,float percent = 1.0f)
    {
        if(percent < 0 && percent > 1)
        {
            percent = 1;
        }

        int drawSteps = (int)(steps * percent) + 2;
        circleRenderer.positionCount = drawSteps;

        for(int currentStep = 0; currentStep < drawSteps; currentStep++)
        {
            float circumferenceProgress = (float)currentStep / steps;

            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * radius; 
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x+transform.position.x, y+transform.position.y, 0);

            circleRenderer.SetPosition(currentStep, currentPosition);

        }
    }

    //使在编辑界面就可以看到
    private void OnDrawGizmos()
    {
        DrawCircle(edges, radius, percent);
    }
}