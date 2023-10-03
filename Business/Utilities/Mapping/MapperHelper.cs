// AutoMapper kütüphanesini kullanarak nesne eşleme işlemlerini yönetmek için kullanılan MapperHelper sınıfı
using AutoMapper;

public class MapperHelper : IMapperHelper
{
    private readonly IMapper _mapper;

    // Constructor, AutoMapper'ın yapılandırılması ve profillerin eklenmesi işlemlerini gerçekleştirir
    public MapperHelper()
    {
        // AutoMapper profilleri
        var profiles = new List<Profile>
        {
            new Profiles()
        };

        // AutoMapper konfigürasyonu
        var config = new MapperConfiguration(config =>
        {
            foreach (var profile in profiles)
            {
                config.AddProfile(profile);
            }
        });

        // IMapper örneği oluşturulması
        _mapper = config.CreateMapper();
    }

    // Belirtilen kaynak nesnesini hedef türüne eşler
    public TDestination Map<TDestination>(object? source)
    {
        return _mapper.Map<TDestination>(source);
    }

    // Belirtilen kaynak nesnesini belirtilen hedef nesnesine eşler
    public void Map(object? source, object? destination)
    {
        _mapper.Map(source, destination);
    }
}
