public class Scripture
{
    private Reference _reference;
    private List<Word> _words;


    public Scripture(int position, string book, int chapter, int startVerse, int endVerse, string text)
    {

        _reference = new Reference(position, book, chapter, startVerse, endVerse);
        _words = new List<Word>();

        string[] parts = text.Split(" ");
        
        foreach(string word in parts)
        {
            _words.Add(new Word(word));
        }
    }

    public void RenderedDisplay()
    {
        Console.WriteLine(_reference.DisplayReference());
        foreach(Word word in _words)
        {
            if(word.isHidden())
            {
                Console.Write(new string('_', word.RenderText().Length) + " ");
            }
            else
            {
                Console.Write(word.RenderText() + " ");
            }
        }
    }

    public bool HideWords()
    {
        List<Word> _shownWords = ShownWords();
        if(_shownWords.Count < 2)
        {
           return false; 
        }
        
        Random randomWords = new Random();
        int textIndex1 = randomWords.Next(_shownWords.Count);
        int textIndex2;

        do
        {
            textIndex2 = randomWords.Next(_shownWords.Count);
        }
        while(textIndex1 == textIndex2);
       
        _shownWords[textIndex1].Hide();
        _shownWords[textIndex2].Hide();
        return true;
    }


    private List<Word> ShownWords()
    {
        List<Word> _shownWords = new List<Word>();
        foreach(Word word in _words)
        {
            if(!word.isHidden())
                _shownWords.Add(word);
        }
        return _shownWords;
    }
}