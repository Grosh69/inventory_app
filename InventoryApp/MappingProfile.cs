using AutoMapper;
using InventoryApp.DTOs;
using InventoryApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Product entitás -> CreateProductDto (és vissza)
        CreateMap<CreateProductDto, Product>();

        // Product entitás -> UpdateProductDto (és vissza)
        CreateMap<UpdateProductDto, Product>();
    }
}