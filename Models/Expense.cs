namespace MY_WEBSITE.Models;

public class Expense
{
    public int Id { get; set;}
    public string Name { get; set;}
    public decimal Amount { get; set;}
    [Required]
    public string? Description { get; set;}
}