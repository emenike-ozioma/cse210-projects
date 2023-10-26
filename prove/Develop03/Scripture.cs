public class Reference
{
    private int _position;
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(int position, string book, int chapter, int startVerse, int endVerse)
    {
        _position = position;
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string DisplayReference()
    {
        return $"{_position} {_book} {_chapter}:{_startVerse}-{_endVerse}:";
    }
}