using LectorNet.Contracts.Books;
using LectorNet.Domain.Models.Books;
using Mapster;

namespace LectorNet.Api.MappingsProfiles;

public class BookMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Book, BookResponse>()
            .Map(dest => dest.UserInfos, src => new UserInfoResponse(src.User!.FirstName, src.User.LastName));
    }
}