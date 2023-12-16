using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
   
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public string Description { get; set; }
    
}

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
}

public class Review
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ReviewerName { get; set; }
    public string Content { get; set; }
    
}

public class CartItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    
}
