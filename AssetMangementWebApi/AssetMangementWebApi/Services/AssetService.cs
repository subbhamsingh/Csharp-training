using AssetMangementWebApi.Models;

namespace AssetMangementWebApi.Services
{
    public class AssetService
    {
        private List<Asset> assets = new List<Asset>();
        public List<Asset> GetALL()
        {
            return assets;
        }


        public Asset? GetById(int id)
        {
            return assets.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Asset asset)
        {
            assets.Add(asset);
        }

        public bool Update(int id , Asset updatedAsset)
        {
            var existingAsset = assets.FirstOrDefault(a => a.Id == id);
            if (existingAsset == null)
                return false;
            existingAsset.Name = updatedAsset.Name;
            existingAsset.Category = updatedAsset.Category;
            existingAsset.Value = updatedAsset.Value;

            return true;
        }
        public bool Delete(int id)
        {
            var asset = GetById(id);
            if (asset != null)
            {
                assets.Remove(asset);
                return true;
            }
            return false;
        }


        // new method to for assign
        public bool assign(int id, string userName)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);
            if (asset == null)
                return false;
            if (!string.IsNullOrEmpty(asset.AssignedTo))
                return false;
            asset.AssignedTo = userName;
            return true;
        }

        // unassign 
        public bool Unassign(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);

            if (asset == null)
                return false;

            if (string.IsNullOrEmpty(asset.AssignedTo))
                return false;

            asset.AssignedTo = null;
            return true;
        }

    }
}
