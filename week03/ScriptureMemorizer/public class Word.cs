
public class Word
{
    private string _text;
    private bool _isHidden();

    public Word(string text)
    {
        _text = text;
        _isHidden() = false;
    }

    public void Hide()
    {
        _isHidden() = true;
    }

    public void Show()
    {
        _isHidden() = false;
    }
    public bool _IsHidden()
    {
        return _IsHidden();
    }

    public string GetDisplayText()
    {
        return _isHidden() ? new string('_', _text.Length) : _text;
    }

    internal bool IsHidden()
    {
        throw new NotImplementedException();
    }
}
