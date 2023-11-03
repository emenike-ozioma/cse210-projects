public class MathAssignment : Assignment
{
    // Attributes
    private string _textbookSection; //eg. "7.3"
    private string _problems; //eg. "3-10,20-21"

    // Constructor

    // Notice the syntax here that the MathAssignment constructor has 4 parameters and then
    // it passes 2 of them directly to the "base" constructor, which is the "Assignment" class constructor.
    public MathAssignment(string studentName, string topic, string textBook, string problems) 
        : base(studentName, topic)
    {
        // Here we set the MathAssignment specific variables
        _textbookSection = textBook;
        _problems = problems;
    }

    // Method
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}