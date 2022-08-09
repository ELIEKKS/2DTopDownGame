using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{

    public void Create(Vector3 position, int damageAmount, Transform text)
    {
        Transform damagePopUpTransform = Instantiate(text, position, Quaternion.identity);
        DamagePopUp damagePopUp = damagePopUpTransform.GetComponent<DamagePopUp>();
        damagePopUp.Setup(damageAmount);
    }

    public TextMeshProUGUI textMesh;
    private float disappearTimer;
    private Color textColor;


    public void Setup(int damageAmount)
    {   

        textMesh.text = damageAmount.ToString();
        textColor = textMesh.color;
        disappearTimer = 1f;
    }

    private void Update() 
    {
        float moveYSpeed = 20f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if (disappearTimer <= 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
