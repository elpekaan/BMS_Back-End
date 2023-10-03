// AutoMapper profillerini tanımlayan sınıf
using Business.Models.Request.Create;
using Business.Models.Request.Functional;
using Business.Models.Request.Update;
using Business.Models.Response;
using Infrastructure.Data.Postgres.Entities;

public class Profiles : AutoMapper.Profile
{
    // Constructor, profillerin konfigürasyonunu gerçekleştirir
    public Profiles()
    {
        // Kullanıcı ekleme işlemi için eşleme
        CreateMap<RegisterDto, User>().ReverseMap();

        // Kullanıcı güncelleme işlemi için eşleme
        CreateMap<UserUpdateDto, User>().ReverseMap();

        // Kullanıcı görüntüleme işlemi için eşleme
        CreateMap<User, UserProfileDto>().ReverseMap();

        // MyTask ile ilgili eşlemeler
        CreateMap<MyTask, MyTaskCreateDto>().ReverseMap();
        CreateMap<MyTask, MyTaskUpdateDto>().ReverseMap();
        CreateMap<MyTask, MyTaskInfoDto>().ReverseMap();

        // Project ile ilgili eşlemeler
        CreateMap<Project, ProjectCreateDto>().ReverseMap();
        CreateMap<Project, ProjectUpdateDto>().ReverseMap();
        CreateMap<Project, ProjectInfoDto>().ReverseMap();

        // Room ile ilgili eşlemeler
        CreateMap<Room, RoomCreateDto>().ReverseMap();
        CreateMap<Room, RoomUpdateDto>().ReverseMap();
        CreateMap<Room, RoomInfoDto>().ReverseMap();

        // Ticket ile ilgili eşlemeler
        CreateMap<Ticket, TicketCreateDto>().ReverseMap();
        CreateMap<Ticket, TicketUpdateDto>().ReverseMap();
        CreateMap<Ticket, TicketInfoDto>().ReverseMap();
    }
}
