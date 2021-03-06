using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour {
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private float _fadeTime = 1;
    public void Init(int value) {
        // Parametre olarak alınan değer stringe çevrilip text'e atanıyor.
        _text.text = value.ToString();

        // DOTween sequenc'i oluşturuluyor.
        var sequence = DOTween.Sequence();

        // Textin oluşturulup fadeTime kadar zamanda hareket etmesini ve kaybolmasını sağlıyor.
        sequence.Insert(0, _text.DOFade(0, _fadeTime));
        sequence.Insert(0, _text.transform.DOMove(_text.transform.position + Vector3.up, _fadeTime));
        
        // Sequence tamamlandığında objenin oyunda gözükmemesini sağlıyor.
        sequence.OnComplete(() => gameObject.SetActive(false));

        //Oyunun performansını daha kötü etkiliyor. Fakat oyun çalıştırılırken unity'de Hierarchy'deki karmaşayı önlüyor.
        //sequence.OnComplete(() => Destroy(gameObject));  
    }
}
