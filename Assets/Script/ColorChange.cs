using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] private bool isHookOn;
    // Update is called once per frame
    void Update()
    {
        if (isHookOn)
        {
            StartCoroutine(ColorReload());
            isHookOn = false;
        }
    }

    IEnumerator ColorReload()
    {
        int count = 0;
        while (count < 8)
        {
            float fadeCnt = 0;
            while(fadeCnt < 1.0f)
            {
                fadeCnt += 0.1f;
                yield return new WaitForSeconds(0.1f);
                this.GetComponent<MeshRenderer>().materials[0].color = new Color(1f, 0.4f, 0.2f, fadeCnt);
            }

            while (fadeCnt > 0f)
            {
                fadeCnt -= 0.1f;
                yield return new WaitForSeconds(0.1f);
                this.GetComponent<MeshRenderer>().materials[0].color = new Color(1f, 0.4f, 0.2f, fadeCnt);
            }

            count++;
        }
    }

    public void HookOn()
    {
        isHookOn = true;
    }
}
