using AutoMapper;
using SwiftCart.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCart.Models.Profiles {
    public  class ProductProfile : Profile {
        public ProductProfile() {
            CreateMap<Product, ProductModel>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
                .ForMember(destinationMember: dest => dest.Name, memberOptions: opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => Convert.ToDouble(src.ListPrice))) // Convert decimal to double
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => ConvertImageToBase64(src.ThumbNailPhoto)));
        }

        private static string ConvertImageToBase64(byte[] imageData) {
            if (imageData == null || imageData.Length == 0)
                return string.Empty;

            return $"data:image/png;base64,{Convert.ToBase64String(imageData)}";
        }
    }
}
