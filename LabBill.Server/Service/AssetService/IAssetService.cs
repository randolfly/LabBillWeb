using LabBill.Shared;
using LabBill.Shared.Model;

namespace LabBill.Server.Service.AssetService;

public interface IAssetService {
    Task<ServiceResponse<Asset>> GetAssetById(int assetId);
    Task AddAsset(Asset asset);
}