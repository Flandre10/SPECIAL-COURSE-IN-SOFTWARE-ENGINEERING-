namespace LibrarySystem.Models;

public class TextBook : LibraryItem
{
    private readonly string publisher;
    public string Publisher => publisher;

    public TextBook(int id, string title, string publisher)
        : base(id, title, ItemType.TextBook)
    {
        this.publisher = publisher;
    }

    public override string GetDetails()
        => $"[TextBook] Title: {Title}, Publisher: {Publisher}";
}