using System;
namespace FirstCSBackend.Dto;

public class ReviewCreateDto
{
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public int ProductId { get; set; }
    public int UserId { get; set; }
}
