using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class Event : MonoBehaviour
{
    public TalkManager talkManager;
    private bool isPlaying = false;
    public Animator anim;

    public CinemachineCamera vcam;

    public Transform Player;
    public Transform Target;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(talkManager.isFinished==true&&isPlaying==false)
        {
            MoveCameraTo(Target);

            anim.SetBool("isOut", true);

            isPlaying = true;

             StartCoroutine(ReturnCameraAfterDelay(3f));
        }
    }

    private void MoveCameraTo(Transform target)
    {
        vcam.Follow = target;
        // 顺便让镜头看向事件中心
        vcam.LookAt = target; 
    }

      private IEnumerator ReturnCameraAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // 恢复跟随玩家
        vcam.Follow = Player;
        vcam.LookAt = Player;
    }
}
