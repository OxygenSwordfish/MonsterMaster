using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [Tooltip("This is the text to be typed out.")]
    public string m_textString;
    [Tooltip("The text element to type to.")]
    public Text m_text;
    [Tooltip("How fast should the text be typed out.")]
    public float m_typingSpeed;
    [Tooltip("How much time should pass before the text should be typed out.")]
    public float m_time;

    void Awake()
    {
        m_text = GetComponent<Text>();
        m_textString = m_text.text;
        m_text.text = "";
        StartCoroutine("TypeText");
    }

    IEnumerator TypeText()
    {
        yield return new WaitForSeconds(m_time);
        foreach(char character in m_textString)
        {
            m_text.text += character;
            switch(character)
            {
                case '.':
                    yield return new WaitForSeconds(1);
                    break;
                case '!':
                    yield return new WaitForSeconds(1);
                    break;
                case '?':
                    yield return new WaitForSeconds(1);
                    break;
                case ',':
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
        yield return new WaitForSeconds(m_typingSpeed);
    }
}
