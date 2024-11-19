using UnityEngine;
using UnityEngine.InputSystem;

public class fovScale : MonoBehaviour
{
    [SerializeField]
    private InputAction fov = new InputAction(type: InputActionType.Value);

    [SerializeField]
    private float defaultSize = 1f;

    [SerializeField]
    private float minimalSize = 1f;

    [SerializeField]
    private float maximalSize = 1f;

    [SerializeField] 
    private float zoomSpeed = 1f;

    private Camera cam;

    private void OnEnable()
    {
        fov.Enable();
    }

    private void OnDisable()
    {
        fov.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        cam.orthographicSize = defaultSize;
    }

    // Update is called once per frame
    void Update()
    {
        //reading mouse input
        Vector2 scroll = fov.ReadValue<Vector2>();

        //getting the float value of the scroll
        float scrollValue = scroll.y;

        //calcualting new camera size based on mouse input
        if (scrollValue != 0)
        {
            cam.orthographicSize -= scrollValue * zoomSpeed * Time.deltaTime;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minimalSize, maximalSize);
        }
    }
}
