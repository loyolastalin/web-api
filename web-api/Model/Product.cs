namespace web_api.Model
{
   public class Product
{
    public int Product_Id { get; set; }
    public string Product_Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public int Stock_Quantity { get; set; }
    public DateTime Created_At { get; set; }
}
}