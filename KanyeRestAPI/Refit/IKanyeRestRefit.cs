using KanyeRestAPI.Response;
using Refit;

namespace KanyeRestAPI.Refit;

public interface IKanyeRestRefit
{
    [Get("")]
    Task<ApiResponse<KanyeRestResponse>> GetKanyeRest();
}
