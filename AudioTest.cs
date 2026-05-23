using UnityEngine;

public class AudioTest : MonoBehaviour
{
    private CharacterController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerController.SimpleMove(move*100);
    }
   private void OnAnimatorIK(int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          
        }
    }
}
