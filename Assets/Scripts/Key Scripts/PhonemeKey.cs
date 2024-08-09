using UnityEngine;
using TMPro;

public class PhonemeKey : Key
{
    public Phoneme phoneme;
    [SerializeField] private GameObject countImage;
    [SerializeField] private TMP_Text countText;
    public void Initialize(Phoneme p)
    {
        phoneme = p;
        Initialize();
    }
    public override void Initialize()
    {
        this.name = phoneme.phonemeString;
        displayText.text = phoneme.phonemeString;
        audioSource.clip = phoneme.audioClip;
        UpdateCountVisual();
    }

    private void UpdateCountVisual()
    {
        int count = phoneme.phonemeCount;
        if(count<1){
            SetColor(Color.gray);
            countImage.SetActive(false);
        } else {
            SetColor(Color.yellow);
            countText.text = count.ToString();
            countImage.SetActive(true);
        }
    }
    public override void OnLeftClick()
    {
        PlayAudio();
        if(ViewManager.CheckCurrentView<DeductionView>())       
        {
            if(phoneme.SubtractCount()<0) return;
            PhonemeKeyManager.instance.EnterAnswerkey(this);
            UpdateCountVisual();
        }
    }
    public void AddCount()
    {
        PlayAudio();
        phoneme.AddCount();
        UpdateCountVisual();
    }

    public void AddCountWithoutAudio()
    {
        phoneme.AddCount();
        UpdateCountVisual();
    }

}