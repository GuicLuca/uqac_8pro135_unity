using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineVersion : MonoBehaviour
{

    private TMPro.TextMeshProUGUI _versionText;
    // Start is called before the first frame update
    void Start()
    {
        _versionText = GetComponent<TMPro.TextMeshProUGUI>();
        _versionText.text = Application.unityVersion;
    }
}
