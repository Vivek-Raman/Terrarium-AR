using UnityEngine;
using UnityEngine.Rendering;

public class SwitchDimensions : MonoBehaviour
{

    public Transform device;
    public Material[] stencilMaterials = null;
    private Camera cam = null;

    private bool wasInFront;
    private bool inOtherWorld;
    private bool isColliding;
    private static readonly int StencilTest = Shader.PropertyToID("_StencilTest");

    private void Awake()
    {
        cam = Camera.main;
        device = cam.transform;
        ShowMeshesOnlyThroughPortal();
        Debug.Log("COUNT ME");
    }

    private void OnDestroy()
    {
        ShowMaterialsEverywhere();
    }


    private void Update()
    {
        WhileCameraColliding();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != device)
            return;
        wasInFront = GetIsInFront();
        isColliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform != device)
            return;
        isColliding = false;
    }

    private bool GetIsInFront()
    {
        Vector3 worldPos = device.position + device.forward * cam.nearClipPlane;

        Vector3 pos = transform.InverseTransformPoint(worldPos);
        return pos.z >= 0 ? true : false;
    }

    private void SetMaterials(bool fullRender)
    {
        int stencilTest = (int) (fullRender ? CompareFunction.NotEqual : CompareFunction.Equal);
        // Shader.SetGlobalInt(StencilTest, stencilTest);
        foreach (Material mat in stencilMaterials)
        {
            mat.SetFloat(StencilTest, stencilTest);
        }
    }

    private void WhileCameraColliding()
    {
        if (!isColliding)
            return;
        bool isInFront = GetIsInFront();
        if ((isInFront && !wasInFront) || (wasInFront && !isInFront))
        {
            inOtherWorld = !inOtherWorld;
            SetMaterials(inOtherWorld);
        }
        wasInFront = isInFront;
    }

    [ContextMenu(nameof(ShowMaterialsEverywhere))]
    void ShowMaterialsEverywhere()
    {
        SetMaterials(true);
    }

    [ContextMenu(nameof(ShowMeshesOnlyThroughPortal))]
    void ShowMeshesOnlyThroughPortal()
    {
        SetMaterials(false);
    }
}