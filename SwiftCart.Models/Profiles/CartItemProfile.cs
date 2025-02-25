using AutoMapper;
using SwiftCart.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCart.Models.Profiles {
    public class CartItemProfile : Profile {
        public CartItemProfile() {
            CreateMap<ProductModel, CartItemModel>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => Convert.ToDouble(src.Price))) // Convert decimal to double
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
        }
    }
}
