using LabBill.Server.Data;
using LabBill.Shared;
using LabBill.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace LabBill.Server.Service.AssetService;

public class AssetService : IAssetService {
    private readonly DataContext _dataContext;

    public AssetService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ServiceResponse<Asset>> GetAssetById(int assetId)
    {
        var response = new ServiceResponse<Asset>();
        var asset = await _dataContext.Assets.FirstOrDefaultAsync(a => a.Id.Equals(assetId));
        if (asset == null)
        {
            response.Success = false;
            response.Message = "Sorry, asset not exists.";
        }
        else
        {
            response.Data = asset;
            response.Success = true;
        }
        return response;
    }
    public async Task AddAsset(Asset asset)
    {
        await _dataContext.Assets.AddAsync(asset);
    }
}