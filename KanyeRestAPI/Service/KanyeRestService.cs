using KanyeRestAPI.Refit;
using KanyeRestAPI.Response;
using KanyeRestAPI.Service.Interface;
using Refit;

namespace KanyeRestAPI.Service;

public class KanyeRestService : IKanyeRestService
{
    private readonly IKanyeRestRefit _kanyeRestRefit;

    public KanyeRestService(IKanyeRestRefit kanyeRestRefit)
    {
        _kanyeRestRefit = kanyeRestRefit;
    }

    public async Task<KanyeRestResponse> GetKanyeRestRandom()
    {
        var kanyeRest = await _kanyeRestRefit.GetKanyeRest();

        if (kanyeRest.IsSuccessStatusCode)
        {
            return kanyeRest.Content;
        }
        else
        {
            return null;
        }
    }


}
