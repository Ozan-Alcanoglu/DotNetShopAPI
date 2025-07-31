namespace FirstCSBackend.Dto;

public class OrderCreateDto
{
	public int Quantity { get; set; }
	public int UserId { get; set; }
	public int ProductId { get; set; }
}