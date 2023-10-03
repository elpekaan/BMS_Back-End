// IMapperHelper arayüzü, nesne eşleme işlemlerini yönetmek için kullanılır
public interface IMapperHelper
{
    // Belirtilen kaynak nesnesini hedef türüne eşler
    TDestination Map<TDestination>(object? source);

    // Belirtilen kaynak nesnesini belirtilen hedef nesnesine eşler
    void Map(object? source, object? destination);
}
