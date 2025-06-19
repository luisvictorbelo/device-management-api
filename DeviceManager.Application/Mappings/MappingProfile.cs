using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DeviceManager.Application.DTOs;
using DeviceManager.Domain.Entities;

namespace DeviceManager.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Dispositivo, DispositivoDto>().ReverseMap();
            // CreateMap<Evento, EventoDto>().ReverseMap();
        }
    }
}