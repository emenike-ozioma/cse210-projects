public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public string RenderText()
    {
        return _text;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool isHidden()
    {
        return _isHidden;
    }
}