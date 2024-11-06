using KanyeRestAPI.Response;
using Refit;

namespace KanyeRestAPI.Service.Interface;

public interface IKanyeRestService
{
    Task<KanyeRestResponse> GetKanyeRestRandom();
}
