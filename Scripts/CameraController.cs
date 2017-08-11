using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;  //check for 10 pixals of top of screen


    private bool doMovement = true;  //esc to stop camera movement

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

	// Update is called once per frame
	void Update () {

        //next two if statements prevent camera from going too far off the map
        //pressing esc stops camera movement
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;
        
        //gets input every frame
        //move up
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            //next line is also written as follows:
            //new Vector3(0f, 0f, panSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);  //move forward when w is pressed
            //Space.World ignores rotation of camera
        }

        //move down
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        //move right
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        //move left
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }


        float scroll = Input.GetAxis("Mouse ScrollWheel"); //control the scroll wheel on the mouse

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime; //this applys the posisition back in
        pos.y = Mathf.Clamp(pos.y, minY, maxY);   //restrict pos y between min and max

        transform.position = pos;



    }

    
}
