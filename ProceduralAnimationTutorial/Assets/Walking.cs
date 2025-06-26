using UnityEngine;

public class Walking : MonoBehaviour
{
    public Transform LeftFootFTarget;
    public Transform RightFootFTarget;
    public Transform LeftFootBTarget;
    public Transform RightFootBTarget;
    public AnimationCurve horizontalCurve;
    public AnimationCurve verticalCurve;
    public AnimationCurve rotationCurve;
    
    private Vector3 LeftFootFOffset;
    private Vector3 RightFootFOffset;
    private Vector3 LeftFootBOffset;
    private Vector3 RightFootBOffset;

    void Start()
    {
        LeftFootBOffset = LeftFootBTarget.localPosition;
        RightFootBOffset = RightFootBTarget.localPosition;
        LeftFootFOffset = LeftFootFTarget.localPosition;
        RightFootFOffset = RightFootFTarget.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        LeftFootFTarget.localPosition = LeftFootFOffset + 
                this.transform.InverseTransformVector(LeftFootFTarget.forward) * horizontalCurve.Evaluate(Time.time) + 
                this.transform.InverseTransformVector(LeftFootFTarget.up) * verticalCurve.Evaluate(Time.time + 0.5f) + 
                this.transform.InverseTransformVector(LeftFootFTarget.right) * rotationCurve.Evaluate(Time.time + 0.5f);
        
        RightFootFTarget.localPosition = RightFootFOffset + 
                this.transform.InverseTransformVector(RightFootFTarget.forward) * horizontalCurve.Evaluate(Time.time - 1) + 
                this.transform.InverseTransformVector(RightFootFTarget.up) * verticalCurve.Evaluate(Time.time - 0.5f) + 
                this.transform.InverseTransformVector(RightFootFTarget.right) * rotationCurve.Evaluate(Time.time - 1);
        LeftFootBTarget.localPosition = LeftFootBOffset + 
                this.transform.InverseTransformVector(LeftFootBTarget.forward) * horizontalCurve.Evaluate(Time.time - 1) + 
                this.transform.InverseTransformVector(LeftFootBTarget.up) * verticalCurve.Evaluate(Time.time - 0.5f) + 
                this.transform.InverseTransformVector(LeftFootBTarget.right) * rotationCurve.Evaluate(Time.time - 1);
        RightFootBTarget.localPosition = RightFootBOffset + 
                this.transform.InverseTransformVector(RightFootBTarget.forward) * horizontalCurve.Evaluate(Time.time) + 
                this.transform.InverseTransformVector(RightFootBTarget.up) * verticalCurve.Evaluate(Time.time + 0.5f) + 
                this.transform.InverseTransformVector(RightFootBTarget.right) * rotationCurve.Evaluate(Time.time);
    }
}
