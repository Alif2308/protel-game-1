using Cinemachine;
using UnityEngine;

public class cinemachinePOV : CinemachineExtension
{
    [SerializeField] private float HorizontalSpeed = 10f;
    [SerializeField] private float VerticalSpeed = 10f;
    [SerializeField] private float clampangle = 80f; // limit untuk melihat ke segala arah(bisa di bilang limit rotasi kamera)
    private InputManager inputmanager;
    private Vector3 startingRotation;

    /*protected merupakan fungsi yang membantu parent untuk bisa mengakses program yang telah di buat
    bedanya dengan private adalah jika private hanya yang punya program sedangkan protected bisa diakses oleh bagian lain (misal child atau parent)
    dari objek yang memiliki program atau fungsi ini meskipun dirinya sendiri tidak punya*/

    protected override void Awake() //override berguna memaksa berjalan program ini pada objek lain yang telah memiliki fungsi sama pada programnya
    {
        inputmanager = InputManager.Instance;
        base.Awake(); // memanggil fungsi awake dari parent
    }

    
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltatime)
    {
        if(vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                if(startingRotation == null)
                {
                    startingRotation = transform.localRotation.eulerAngles;
                }
                Vector2 deltaInput = inputmanager.GetMouseDelta();
                startingRotation.x += deltaInput.x * VerticalSpeed * Time.deltaTime;
                startingRotation.y += deltaInput.y * HorizontalSpeed * Time.deltaTime;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampangle,clampangle); //Clamp berfungsi untuk mengunci nilai agar tidak lebih atau kurang dari batas
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x,0f);

            }
        }
    }
}
// jangan lupa ganti prioritas input manager pada edit -> project settings -> script execution Order  lebih tinggi dari cinemachinePOV karena basenya di inputmanager untuk fungsi Awake()