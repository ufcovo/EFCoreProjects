﻿using AutoMapper;
using EFCore.CodeFirst.DAL;
using EFCore.CodeFirst.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.Mappers
{
    internal class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper> (() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomMapping>();
            });
            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }

    internal class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}
