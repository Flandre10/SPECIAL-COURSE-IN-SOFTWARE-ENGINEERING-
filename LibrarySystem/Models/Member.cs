using System.Collections.Generic;

namespace LibrarySystem.Models;

public class Member
{
    private readonly string name;
    private readonly List<LibraryItem> borrowedItems;

    public string Name => name;

    public Member(string name)
    {
        this.name = name;
        borrowedItems = new List<LibraryItem>();
    }

    public string BorrowItem(LibraryItem item)
    {
        if (borrowedItems.Count >= 3)
            return "You cannot borrow more than 3 items.";

        borrowedItems.Add(item);
        return $"Item added to {Name}'s borrowed list: {item.Title}";
    }

    // 按题目拼写：RetrunItems
    public string RetrunItems(LibraryItem item)
    {
        if (borrowedItems.Contains(item))
        {
            borrowedItems.Remove(item);
            return $"Item returned successfully: {item.Title}";
        }
        return "The item was not in the list of borrowed items.";
    }

    public List<LibraryItem> GetBorrowedItems() => borrowedItems;
}