using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] Slider loadSlider;

    private float loadingTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        loadingTimer += Time.deltaTime;

        loadSlider.value = loadingTimer;

        if (loadSlider.value == 3f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
