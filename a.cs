using System;
using System.Collections.Generic;

class Book{public int Id;public string Title;public bool IsIssued;}
class Member{public int Id;public string Name;}
class Issue{public int BookId;public int MemberId;public DateTime IssueDate;public DateTime DueDate;}

class Program
{
    static List<Book> books=new(){new Book{Id=1,Title="C#"}};
    static List<Member> members=new(){new Member{Id=1,Name="Ali"}};
    static List<Issue> issues=new();
    static void Main()
    {
        Console.WriteLine("Issue Book: 1");
        int bookId=1, memId=1;
        issues.Add(new Issue{BookId=bookId,MemberId=memId,IssueDate=DateTime.Now,DueDate=DateTime.Now.AddDays(7)});
        books[0].IsIssued=true;

        // Return
        var i=issues[0];
        int fine=(DateTime.Now-i.DueDate).Days*10;
        if(fine>0) Console.WriteLine($"Fine: {fine}");
        else Console.WriteLine("No Fine");
    }
}