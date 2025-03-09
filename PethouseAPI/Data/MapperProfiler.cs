using AutoMapper;
using PethouseAPI.Data.DTO;
using PethouseAPI.Data.Models;

namespace PethouseAPI.Data;

public class MapperProfiler : Profile
{
    public MapperProfiler()
    {
        CreateMap<Pet, PetDTO>();
        CreateMap<PetDTO, Pet>();

        CreateMap<Owner,OwnerDTO>();
        CreateMap<OwnerDTO, Owner>();

        CreateMap<Appointment, AppointmentDTO>();
        CreateMap<AppointmentDTO, Appointment>();

        CreateMap<BreedSize, BreedSizeDTO>();
        CreateMap<BreedSizeDTO, BreedSize>();

        CreateMap<PetAppointment, PetAppointmentDTO>();
        CreateMap<PetAppointmentDTO, PetAppointment>();

        CreateMap<PeakSeason, PeakSeasonDTO>();
        CreateMap<PeakSeasonDTO, PeakSeason>();
    }
}
