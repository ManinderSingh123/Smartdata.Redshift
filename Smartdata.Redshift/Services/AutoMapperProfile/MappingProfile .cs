using AutoMapper;
using Microsoft.Extensions.Configuration;
using Redmap.Redshift.DTO;
using Redmap.Redshift.Model;

namespace Redmap.Events.Services.AutoMapperProfile
{
    /// <summary>
    ///Mapping Profile Class
    /// </summary>
    public class MappingProfile : Profile
    {
       
        /// <summary>
        /// Constructor
        /// </summary>
        public MappingProfile()
        {  
            // Add as many of these lines as you need to map your objects
            CreateMap<TableColumnDto, TableColumnModel>().ReverseMap();     
        }
    }
}
