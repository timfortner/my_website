namespace MY_WEBSITE.Models;

public class Expense
{
    public int Name { get; set;}
    public decimal Amount { get; set;}
    [Required]
    public string? Description { get; set;}
}