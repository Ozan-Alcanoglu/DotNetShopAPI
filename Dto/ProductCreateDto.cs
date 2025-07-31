namespace FirstCSBackend.Dto;

public partial class ProductCreateDto
{
	public string Name { get; set; } = string.Empty;
	public decimal Price { get; set; }
	
}