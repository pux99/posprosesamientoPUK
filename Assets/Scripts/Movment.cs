using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class Movment : MonoBehaviour
{
    public PostProcessVolume global;
    private ChromaticAberration aber;
    private LensDistortion lent;
    public Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        global.profile.TryGetSettings(out aber);
        global.profile.TryGetSettings(out lent);
        aber.intensity.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if( aber.intensity.value>=0)
        {
            aber.intensity.value -= 0.5f*Time.deltaTime;
            lent.intensity.value -= 1f * Time.deltaTime;
        }
        rb.velocity = (new Vector3(Input.GetAxis("Horizontal") * speed , rb.velocity.y, Input.GetAxis("Vertical")*speed));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            aber.intensity.value=1;
            lent.intensity.value += 10;
        }
        if (collision.gameObject.CompareTag("espejo"))
        {
            lent.intensity.value = 3;
        }
    }
}
