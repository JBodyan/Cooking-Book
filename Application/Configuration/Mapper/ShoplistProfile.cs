using System;
using System.Collections.Generic;
using System.Text;
using Application.Dto.Shoplist;
using Application.Dto.Shoplist.Category;
using Application.Dto.Shoplist.Product;
using Application.Dto.Shoplist.User;
using AutoMapper;
using Data.Entities.Shoplist;

namespace Application.Configuration.Mapper
{
    public class ShoplistProfile : Profile
    {
        public ShoplistProfile()
        {
            CreateMap<ShoplistDto, Shoplist>();

            CreateMap<ShoplistAddDto, Shoplist>();

            CreateMap<ShoplistUpdateDto, Shoplist>();


            CreateMap<ShoplistUserDto, ShoplistUser>();

            CreateMap<ShoplistUserAddDto, ShoplistUser>();

            CreateMap<ShoplistUserUpdateDto, ShoplistUser>();


            CreateMap<ShoplistProductDto, ShoplistProduct>();

            CreateMap<ShoplistProductUpdateDto, ShoplistProduct>();


            CreateMap<ShoplistCategoryDto, ShoplistCategory>();

            CreateMap<ShoplistCategoryAddDto, ShoplistCategory>();

            CreateMap<ShoplistAddDto, ShoplistCategory>();
        }
    }
}
