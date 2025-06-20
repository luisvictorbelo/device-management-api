using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DeviceManager.Application.DTOs;
using DeviceManager.Domain.Entities;
using DeviceManager.Domain.Enums;

namespace DeviceManager.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, UserDto>().ReverseMap();

            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<CreateClienteDto, Cliente>().ReverseMap();
            CreateMap<CreateClienteDto, ClienteDto>().ReverseMap();
            CreateMap<UpdateClienteDto, Cliente>().ReverseMap();

            CreateMap<Dispositivo, DispositivoDto>().ReverseMap();
            CreateMap<Dispositivo, CreateDispositivoDto>().ReverseMap();
            CreateMap<Dispositivo, UpdateDispositivoDto>().ReverseMap();

            CreateMap<Evento, CreateEventoDto>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.Tipo, opt => opt.Ignore());
            CreateMap<Evento, EventoDto>()
                .ReverseMap()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => Enum.Parse<TipoEvento>(src.Tipo)));

        }
    }
}