using AutoMapper;
using Kollegeni.DTOs;
using Kollegeni.Interface;
using Kollegeni.Models;
using Kollegeni.Repositories;

namespace Kollegeni.Service
{
    public class BookingService
    {
            private readonly IBookingRepository _repository;
            private readonly IMapper _mapper;

            public BookingService(IBookingRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public void BookRoom(BookingRequestDto dto)
            {
                var booking = _mapper.Map<Booking>(dto);
                _repository.AddBooking(booking);
            }

            public IEnumerable<BookingResponseDto> GetAllBookings()
            {
                var bookings = _repository.GetAllBookings();
                return _mapper.Map<IEnumerable<BookingResponseDto>>(bookings);
            }
        }
    }
