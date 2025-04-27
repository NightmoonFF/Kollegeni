using Kollegeni.DTOs;
using Kollegeni.Models;
using AutoMapper;


namespace Kollegeni.Mappings
{
    public class BookingMap : Profile
    {
        public BookingMap() 
        {
            CreateMap<BookingRequestDto, Booking>();
            CreateMap<Booking, BookingResponseDto>();  
            
            
        }
    }
}
