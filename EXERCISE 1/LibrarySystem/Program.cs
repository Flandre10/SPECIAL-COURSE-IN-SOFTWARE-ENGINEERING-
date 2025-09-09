using System;
using LibrarySystem.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        // 1. 创建 LibraryManager
        var library = new LibraryManager();

        // 2. 添加各类馆藏
        library.AddItem(new Novel(1, "The Great Gatsby", "F. Scott Fitzgerald"));
        library.AddItem(new Magazine(2, "National Geographic", 202));
        library.AddItem(new TextBook(3, "Introduction to Algorithms", "MIT Press"));

        // 3. 创建成员
        var alice = new Member("alice");
        var bob = new Member("bob");

        // 4. 注册成员
        library.RegisterMember(alice);
        library.RegisterMember(bob);

        // 5. 展示目录
        library.ShowCatalog();

        // 6. 借阅 ID 1, 2, 3 给 alice
        var item = library.FindItemById(1);
        if (item != null) Console.WriteLine(alice.BorrowItem(item));

        item = library.FindItemById(2);
        if (item != null) Console.WriteLine(alice.BorrowItem(item));

        item = library.FindItemById(3);
        if (item != null) Console.WriteLine(alice.BorrowItem(item));

        // 7. 新增一本小说，尝试借给 alice（应提示超过 3 件）
        var newNovel = new Novel(4, "1984", "George Orwell");
        library.AddItem(newNovel);

        item = newNovel;
        Console.WriteLine(alice.BorrowItem(item));

        // 可选：演示归还
        Console.WriteLine(alice.RetrunItems(newNovel)); // 不在列表
        var first = library.FindItemById(1);
        if (first != null) Console.WriteLine(alice.RetrunItems(first)); // 成功归还

        // 输出 alice 当前借阅清单
        Console.WriteLine("=== Alice Borrowed Items ===");
        foreach (var bi in alice.GetBorrowedItems())
            Console.WriteLine(bi.GetDetails());
    }
}